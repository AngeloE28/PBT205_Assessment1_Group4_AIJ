using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

/// <summary>
/// This is the chat system
/// </summary>

namespace PBT205_Assessment1_Group4_AIJ
{
    public partial class ChatForm : Form, IRabbitMQ
    {
        // RabbitMQ setup variables                        
        private String exchangeName = "chat2";
        private static SetupRabbitMQ chatRBMQ;
        private String userID;

        // Store all the users and their data here
        public static SortedDictionary<String, tradeUser> users;

        public ChatForm()
        {
            InitializeComponent();

            // Custom listbox draw mode for bold text
            // Subscribe to the function
            listbxMsgHistory.DrawMode = DrawMode.OwnerDrawFixed;
            listbxMsgHistory.DrawItem += new DrawItemEventHandler(listbxMsgHistory_DrawItem);

            // Store the users            
            users = new SortedDictionary<String, tradeUser>();

            // Send welcome message
            String welcomeMsg = "Welcome " + LoginForm.userName + " to " + Program.loginForm.chatRoomName + " room!";
            listbxMsgHistory.Items.Add(welcomeMsg);

            // Add user
            AddUser(LoginForm.userName);

            // Setup rabbitmq
            chatRBMQ = new SetupRabbitMQ(userName: LoginForm.userName,
                                         password: LoginForm.pass,
                                         roomName: Program.loginForm.chatRoomName,
                                         exchangeName: exchangeName,
                                         exchangeType: ExchangeType.Direct);

            // Send an initial joining message similar to a handshake
            Send("Joined!");
            StartConsume();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Get input
            Send(txtbxInput.Text);
            txtbxInput.Text = "";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Get and display the name
            listbxMsgHistory.Items.Add("Users are:");
            SortedDictionary<String, tradeUser>.KeyCollection names = users.Keys;

            // Loops through the list to print the names of the users
            foreach (String name in names)
            {
                listbxMsgHistory.Items.Add(name);
            }
        }


        public void handleMessage(String message)
        {
            // Display the message
            listbxMsgHistory.Items.Add(message.ToString());
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(chatRBMQ.GetModel());
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());
                var userID = ea.BasicProperties.UserId;
                handleMessage(userID + ": " + text);
                this.userID = userID;
                // Add the user to the dictionary if its not in there          
                AddUser(userID);
            };
            chatRBMQ.GetModel().BasicConsume(queue: chatRBMQ.GetQueueName(),
                                             autoAck: true,
                                             consumer: consumer);
        }

        public void Send(String message)
        {
            // Send message with name
            var body = Encoding.UTF8.GetBytes(message);
            var props = chatRBMQ.GetModel().CreateBasicProperties();
            props.UserId = LoginForm.userName;
            chatRBMQ.GetModel().BasicPublish(exchange: this.exchangeName,
                                             routingKey: chatRBMQ.GetRoomName(),
                                             basicProperties: props,
                                             body: body);
        }

        private void AddUser(String userName)
        {
            // Create the struct to add details
            tradeUser userDetails;
            userDetails.balance = 10000.0f;
            userDetails.stockCount = 1000;            

            // Add the user
            users.Add(userName, userDetails);
        }
        private void btnTrade_Click(object sender, EventArgs e)
        {
            // Hide the chat form
            LoginForm.chatForm.Hide();

            // Show the trading form
            LoginForm.tradeForm.Location = LoginForm.chatForm.Location;
            LoginForm.tradeForm.Show();
        }

        private void btnContactTrace_Click(object sender, EventArgs e)
        {
            // Hide the chat form
            LoginForm.chatForm.Hide();

            // Show the contact tracing form
            LoginForm.contactTracingForm.Location = LoginForm.chatForm.Location;
            LoginForm.contactTracingForm.Show();
        }

        private void listbxMsgHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            float textSize = 10.0f;
            float textSpacing = 9.5f;
            //  String to hold the message to display
            String item = listbxMsgHistory.Items[e.Index].ToString();
            String boldMsg;            

            // Finding the substring inbetween two special characters
            // found in https://stackoverflow.com/questions/12108582/extracting-string-between-two-characters
            // By: name, Date: dd/mm/yyyy            
            int posFrom = item.IndexOf("/*");
            if (posFrom != -1) // Found the first special character
            {
                int posTo = item.IndexOf("*/", posFrom + 1);
                if (posTo != -1) // Found the second special character
                {
                    boldMsg = item.Substring(posFrom + 2, posTo - posFrom - 2); // Gets the substring between the two special characters,
                                                                                // adjusting the size according to the size of the special characters                    
                                                                                                                        
                    // Check if the bold text is at the start of the string
                    if (posFrom != userID.Length + 2)
                    {
                        // Display regular text first
                        e.Graphics.DrawString(item.Substring(0, posFrom),
                                              new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular),
                                              Brushes.Black,
                                              e.Bounds.X,
                                              e.Bounds.Y);

                        // Get the width of the text
                        float startingPos = TextRenderer.MeasureText(item.Substring(0, posFrom),
                                                                 new Font(FontFamily.GenericSansSerif, textSpacing, FontStyle.Regular)).Width;

                        // Display the bold message with the proper position
                        e.Graphics.DrawString(boldMsg,
                                              new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Bold),
                                              Brushes.Black,
                                              startingPos,
                                              e.Bounds.Y);

                        float boldPos = TextRenderer.MeasureText(boldMsg,
                                                                 new Font(FontFamily.GenericSansSerif, textSpacing, FontStyle.Bold)).Width;

                        String lastChar = item.Substring(item.Length - 1);
                        float remainingMsgPos = item.IndexOf(lastChar);

                        // Check and show if there is text after the bold texts
                        if(remainingMsgPos != posTo)
                        {
                            e.Graphics.DrawString(item.Substring(posTo + 2),
                                                  new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular),
                                                  Brushes.Black,
                                                  startingPos + boldPos,
                                                  e.Bounds.Y);
                        }
                    }
                    else
                    {                          
                        String startSring = userID + ":";
                        // Display the regular message with the proper position
                        e.Graphics.DrawString(startSring,
                                              new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular),
                                              Brushes.Black,
                                              e.Bounds.X,
                                              e.Bounds.Y);

                        // Get the userID width
                        float userPos = TextRenderer.MeasureText(userID,
                                                                 new Font(FontFamily.GenericSansSerif, textSpacing, FontStyle.Regular)).Width;
                        // Display bold text first
                        e.Graphics.DrawString(boldMsg,
                                              new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Bold),
                                              Brushes.Black,
                                              userPos,
                                              e.Bounds.Y);

                        // Get the width of the text
                        float boldPos = TextRenderer.MeasureText(boldMsg,
                                                             new Font(FontFamily.GenericSansSerif, textSpacing, FontStyle.Bold)).Width;

                        // Display the regular message with the proper position
                        e.Graphics.DrawString(item.Substring(posTo + 2),
                                              new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular),
                                              Brushes.Black,
                                              userPos + boldPos,
                                              e.Bounds.Y);

                    }
                    return;
                }
            }

            // No bold text, draw string normally
            e.Graphics.DrawString(item,
                                  new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular),
                                  Brushes.Black,
                                  e.Bounds);
        }

    }
}
