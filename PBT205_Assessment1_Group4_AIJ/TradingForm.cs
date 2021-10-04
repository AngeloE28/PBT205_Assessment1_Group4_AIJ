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
/// This is the trading system 
/// </summary>

namespace PBT205_Assessment1_Group4_AIJ
{
    public partial class TradingForm : Form
    {
        // RabbitMQ setup variables
        private String userName = "";
        private String password = "";
        private String tradeRoomName = "trade.stock";
        private String queueName;
        private String exchangeName = "trades";
        private IModel channel;
        private IConnection connection;

        // Stock variables
        private int stocksForSale = 1000;
        private const int stocksPerOrder = 100;
        private const double pricePerOrder = 1000;

        public TradingForm()
        {
            InitializeComponent();
        }

        private void TradingForm_Load(object sender, EventArgs e)
        {
            // Get the values from form1
            userName = LoginForm.username;
            password = LoginForm.pass;

            // Get user details
            user userDetails;
            ChatForm.users.TryGetValue(userName, out userDetails);

            // Display the users values
            lblUserName.Text = LoginForm.username;
            lblStockCount.Text = userDetails.stockCount.ToString();
            lblMoneyCount.Text = "$" + userDetails.balance.ToString();

            // Display the inital stock availability
            lblStockForSaleCount.Text = stocksForSale.ToString();

            // Setup rabbitmq            
            queueName = Guid.NewGuid().ToString();

            var factory = new ConnectionFactory();
            factory.Uri = new Uri($"amqp://{this.userName}:{password}@localhost:5672");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            // Declare exchange and queues
            channel.ExchangeDeclare(exchange: this.exchangeName,
                                    type: ExchangeType.Topic);

            channel.QueueDeclare(queue: this.queueName,
                                 durable: true,
                                 exclusive: true,
                                 autoDelete: true);

            channel.QueueBind(queue: this.queueName,
                              exchange: this.exchangeName,
                              routingKey: tradeRoomName);

            StartConsume();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            // Only if user has stock to sell
            if (CheckUserStockCount())
            {
                // Update the stock and user values
                stocksForSale += stocksPerOrder;
                SendOrder(stocksForSale.ToString());
                UserDetailsAfterStockExchange(pricePerOrder, -stocksPerOrder);
            }
            else // Exit, No more stock to sell 
                return; 
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            // Only allow if user has money and there is stock to buy
            if (CheckUserBalance() && CheckStockForSale())
            {
                // Update the stock and user values
                stocksForSale -= stocksPerOrder;
                SendOrder(stocksForSale.ToString());
                UserDetailsAfterStockExchange(-pricePerOrder, stocksPerOrder);
            }
            else // Exit, No more money to spend or stock to buy
                return; 
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            // Hides the trading form
            LoginForm.tradeForm.Hide();

            // Shows the chat form
            LoginForm.chatForm.Show();
        }

        private void btnTracing_Click(object sender, EventArgs e)
        {
            // Do for task 3
        }
        public void SendOrder(String message)
        {
            // Send order
            var body = Encoding.UTF8.GetBytes(message);
            var props = channel.CreateBasicProperties();
            channel.BasicPublish(exchange: this.exchangeName,
                                 routingKey: this.tradeRoomName,
                                 basicProperties: props,
                                 body: body);
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());

                // Update the stocks
                stocksForSale = int.Parse(text);
                HandleOrder();
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private void HandleOrder()
        {
            // Shows the current available stocks
            lblStockForSaleCount.Text = stocksForSale.ToString();
        }

        private void UserDetailsAfterStockExchange(double pricePerOrder, int stocksPerOrder)
        {
            // Get the user details
            user userDetails;
            ChatForm.users.TryGetValue(userName, out userDetails);

            // Update the value
            userDetails.stockCount += stocksPerOrder;
            userDetails.balance += pricePerOrder;
            ChatForm.users[userName] = userDetails;

            // Display the texts
            lblStockCount.Text = ChatForm.users[userName].stockCount.ToString();
            lblMoneyCount.Text = "$" + ChatForm.users[userName].balance.ToString();
        }

        private bool CheckUserStockCount()
        {
            // Get the user details
            user userDetails;
            ChatForm.users.TryGetValue(userName, out userDetails);

            // Check if user still has stock
            if (userDetails.stockCount <= 0)
                return false;
            else
                return true;
        }

        private bool CheckUserBalance()
        {
            // Get the user details
            user userDetails;
            ChatForm.users.TryGetValue(userName, out userDetails);

            // Check if user still has money
            if (userDetails.balance <= 0)
                return false;
            else
                return true;
        }

        private bool CheckStockForSale()
        {
            // Check if there is stock for sale
            if (stocksForSale <= 0)
                return false;
            else
                return true;
        }
    }
}
