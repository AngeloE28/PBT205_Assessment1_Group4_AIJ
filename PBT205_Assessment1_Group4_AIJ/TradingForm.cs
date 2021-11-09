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
    public partial class TradingForm : Form, IRabbitMQ
    {
        // RabbitMQ setup variables
        private String tradeRoomName = "trade.stock";        
        private String exchangeName = "trades";
        private static SetupRabbitMQ tradeRBMQ;

        // Stock variables
        private int stocksForSale = 1000;
        private const int stocksPerOrder = 100;
        private const double pricePerOrder = 1000;

        public TradingForm()
        {
            InitializeComponent();

            // Get user details
            tradeUser userDetails;
            ChatForm.users.TryGetValue(LoginForm.userName, out userDetails);

            // Display the users values
            lblUserName.Text = LoginForm.userName;
            lblStockCount.Text = userDetails.stockCount.ToString();
            lblMoneyCount.Text = "$" + userDetails.balance.ToString();

            // Display the inital stock availability
            lblStockForSaleCount.Text = stocksForSale.ToString();

            // Setup rabbitmq
            tradeRBMQ = new SetupRabbitMQ(userName: LoginForm.userName,
                                          password: LoginForm.pass,
                                          roomName: tradeRoomName,
                                          exchangeName: exchangeName,
                                          exchangeType: ExchangeType.Topic);

            // Send an initial joining message similar to a handshake
            Send(stocksForSale.ToString());
            StartConsume();
        }

        private void TradingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            // Only if user has stock to sell
            if (CheckUserStockCount())
            {
                // Update the stock and user values
                stocksForSale += stocksPerOrder;
                Send(stocksForSale.ToString());
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
                Send(stocksForSale.ToString());
                UserDetailsAfterStockExchange(-pricePerOrder, stocksPerOrder);
            }
            else // Exit, No more money to spend or stock to buy
                return; 
        }


        public void Send(String message)
        {
            // Send order
            var body = Encoding.UTF8.GetBytes(message);            
            tradeRBMQ.GetModel().BasicPublish(exchange: this.exchangeName,
                                              routingKey: this.tradeRoomName,
                                              basicProperties: null,
                                              body: body);
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(tradeRBMQ.GetModel());
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());

                // Update the stocks
                stocksForSale = int.Parse(text);
                HandleOrder();
            };
            tradeRBMQ.GetModel().BasicConsume(queue: tradeRBMQ.GetQueueName(),
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
            tradeUser userDetails;
            ChatForm.users.TryGetValue(LoginForm.userName, out userDetails);

            // Update the value
            userDetails.stockCount += stocksPerOrder;
            userDetails.balance += pricePerOrder;
            ChatForm.users[LoginForm.userName] = userDetails;

            // Display the texts
            lblStockCount.Text = ChatForm.users[LoginForm.userName].stockCount.ToString();
            lblMoneyCount.Text = "$" + ChatForm.users[LoginForm.userName].balance.ToString();
        }

        private bool CheckUserStockCount()
        {
            // Get the user details
            tradeUser userDetails;
            ChatForm.users.TryGetValue(LoginForm.userName, out userDetails);

            // Check if user still has stock
            if (userDetails.stockCount <= 0)
                return false;
            else
                return true;
        }

        private bool CheckUserBalance()
        {
            // Get the user details
            tradeUser userDetails;
            ChatForm.users.TryGetValue(LoginForm.userName, out userDetails);

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
        private void btnChat_Click(object sender, EventArgs e)
        {
            // Hides the trading form
            LoginForm.tradeForm.Hide();

            // Shows the chat form
            LoginForm.chatForm.Location = LoginForm.tradeForm.Location;
            LoginForm.chatForm.Show();
        }

        private void btnTracing_Click(object sender, EventArgs e)
        {
            // Hides the trading form
            LoginForm.tradeForm.Hide();

            // Show the contact tracing form
            LoginForm.contactTracingForm.Location = LoginForm.chatForm.Location;
            LoginForm.contactTracingForm.Show();
        }
    }
}
