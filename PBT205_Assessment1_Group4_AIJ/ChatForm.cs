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
    public partial class ChatForm : Form
    {
        // RabbitMQ setup variables
        private String userName = "";
        private String password = "";
        private String chatRoomName = "";
        private String queueName;
        private String exchangeName = "chat2";
        private IModel channel;
        private IConnection connection;

        // Store all the users and their data here
        public static SortedDictionary<String, user> users;

        public ChatForm()
        {
            InitializeComponent();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            // Store the users            
            users = new SortedDictionary<String, user>();

            // Get the values from form1
            userName = LoginForm.username;
            password = LoginForm.pass;
            chatRoomName = LoginForm.chatroom;
            String welcomeMsg = "Welcome " + userName + " to " + chatRoomName + " room!";
            listbxMsgHistory.Items.Add(welcomeMsg);

            // Add user
            AddUser(userName);

            // Setup rabbitmq            
            queueName = Guid.NewGuid().ToString();

            var factory = new ConnectionFactory();
            factory.Uri = new Uri($"amqp://{this.userName}:{password}@localhost:5672");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            // Declare exchange and queues
            channel.ExchangeDeclare(exchange: this.exchangeName,
                                    type: ExchangeType.Direct);

            channel.QueueDeclare(queue: this.queueName,
                                 durable: true,
                                 exclusive: true,
                                 autoDelete: true);

            channel.QueueBind(queue: this.queueName,
                              exchange: this.exchangeName,
                              routingKey: this.chatRoomName);

            StartConsume();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Get input
            SendMessage(txtbxInput.Text);
            txtbxInput.Text = "";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            listbxMsgHistory.Items.Add("Users are:");
            // Get and display the name
            SortedDictionary<String, user>.KeyCollection names = users.Keys;

            // Loops through the list to print the names of the users
            foreach (String name in names)
            {
                listbxMsgHistory.Items.Add(name);
            }
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            // Hide the chat form
            LoginForm.chatForm.Hide();

            // Show trading form         
            LoginForm.tradeForm.Show();
        }

        public void handleMessage(String message)
        {
            // Display the message
            listbxMsgHistory.Items.Add(message.ToString());
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());
                var userID = ea.BasicProperties.UserId;
                handleMessage(userID + ": " + text);

                // Add the user to the dictionary if its not in there          
                AddUser(userID);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void SendMessage(String message)
        {
            // Send message
            var body = Encoding.UTF8.GetBytes(message);
            var props = channel.CreateBasicProperties();
            props.UserId = this.userName;
            channel.BasicPublish(exchange: this.exchangeName,
                                 routingKey: this.chatRoomName,
                                 basicProperties: props,
                                 body: body);
        }

        private void AddUser(String userName)
        {
            // Create the struct to add details
            user userDetails;
            userDetails.balance = 10000.0f;
            userDetails.stockCount = 1000;

            // Add the user
            users.Add(userName, userDetails);
        }
    }
}
