using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Numerics;

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
            String item = listbxMsgHistory.Items[e.Index].ToString();            
            float textSize = 10.0f;            
            int textlength = 0;
            Brush textColor = Brushes.Black;
            Font font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular);            
            String[] items = item.Split('&');
            for (int part = 0; part < items.Length; part++)
            {
                String msg = items[part];
                if (part > 0)
                {
                    msg = items[part].Substring(1, items[part].Length - 1);
                    switch (items[part][0])
                    {
                        case 'l': font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Bold); break;
                        case 'o': font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Italic); break;
                        case 'n': font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Underline); break;
                        case 'm': font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Strikeout); break;
                        case 'r': font = new Font(FontFamily.GenericSansSerif, textSize, FontStyle.Regular); break;
                        case '0': textColor = Brushes.Black; break;
                        case '1': textColor = Brushes.DarkBlue; break;
                        case '2': textColor = Brushes.Green; break;
                        case '3': textColor = Brushes.Cyan; break;
                        case '4': textColor = Brushes.Brown; break;
                        case '5': textColor = Brushes.Purple; break;
                        case '6': textColor = Brushes.Orange; break;
                        case '7': textColor = Brushes.LightGray; break;
                        case '8': textColor = Brushes.DarkGray; break;
                        case '9': textColor = Brushes.Blue; break;
                        case 'a': textColor = Brushes.Lime; break;
                        case 'b': textColor = Brushes.LightBlue; break;
                        case 'c': textColor = Brushes.Red; break;
                        case 'd': textColor = Brushes.Magenta; break;
                        case 'e': textColor = Brushes.Yellow; break;
                        case 'f': textColor = Brushes.White; break;
                    }
                }
                e.Graphics.DrawString(msg, font, textColor, textlength, e.Bounds.Y);
                textlength += TextRenderer.MeasureText(msg, font).Width;
            }
        }
    }
}
