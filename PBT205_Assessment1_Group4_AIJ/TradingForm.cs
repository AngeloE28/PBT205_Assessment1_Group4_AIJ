using System;
using System.Collections;
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
        private const int stocksPerOrder = 100;
        //private const double pricePerOrder = 1000;

        private int stocksForSale = 1000;
        private static int currentStonkValue = 1000;

        List<int> list = new List<int>();

        // Initializer i think
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
            Send(CreateMsg());
            StartConsume();

            // Setup stock value graph

            // Set Size of graph
            var objChart = stockValueGraph.ChartAreas[0];

            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 0;
            objChart.AxisX.Maximum = 10;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 1000;

            // Random start to graph

/*            if (userDetails.lTest.Count == 0)
            {
                Random rand = new Random();


                int count = stockValueGraph.Series["$$$"].Points.Count;

                stockValueGraph.Series["$$$"].Points.AddXY(0, currentStonkValue);



                for (int i = 1; i < 8; i++)
                {
                    int newStonkValue = currentStonkValue + rand.Next(-200, 200);

                    if (newStonkValue < 100)
                        newStonkValue = 100;
                    else if (newStonkValue > objChart.AxisY.Maximum - 100)
                        objChart.AxisY.Maximum = newStonkValue + 100;

                    currentStonkValue = newStonkValue;
                    userDetails.lTest.Add(newStonkValue);
                    stockValueGraph.Series["$$$"].Points.AddXY(i, newStonkValue);

                    lblPrice.Text = "$" + newStonkValue;
                }

            }*/

            //lblPrice.Text = userDetails.test + userDetails.lTest.Count;
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
                UpdateGraph();

                Send(CreateMsg());
                UserDetailsAfterStockExchange(currentStonkValue, -stocksPerOrder);
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
                stocksForSale -= stocksPerOrder; // Lower Stock Count
                UpdateGraph();

                Send(CreateMsg()); // Push new Stock Count to the system
                UserDetailsAfterStockExchange(-currentStonkValue, stocksPerOrder); // This does the stuff in the user account
            }
            else // Exit, No more money to spend or stock to buy
                return;
        }

        String CreateMsg()
        {
            String message = "[" + stocksForSale + ", " + currentStonkValue + ", " + list.Count;

            for (int i = 0; i < list.Count; i++)
            {
                message += ", " + list[i];
            }

            message += "]";

            return message;
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

        void ConvertMsg2Things(String message)
        {
            // Converting a string to this method
            // found in https://stackoverflow.com/questions/11170541/c-sharp-parsing-a-vector2-from-string
            // By: GETah, Date: 23/06/2012

            // Remove all the non numeric values besides the space inbetween
            message = message.Replace("[", "")
                             .Replace(",", "")
                             .Replace("]", "");

            // Store the message into seperate strings to parse to a float
            String[] vals = message.Split(' ');
            // Store the values in the vector


            // Update Graph
            stocksForSale = int.Parse(vals[0]);
            currentStonkValue = int.Parse(vals[1]);

            int graphCount = int.Parse(vals[2]);

            for (int i = 0; i < graphCount; i++)
            {
                if (i >= list.Count)
                {
                    list.Add(int.Parse(vals[i + 3]));
                }
                else
                {
                    list[i] = int.Parse(vals[i + 3]);
                }
            }
        }


        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(tradeRBMQ.GetModel());

            // Updates values on the users end
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray()); // Convert weird sequence into a string

                // Update the stocks
                //stocksForSale = int.Parse(text); // If Stock value has changed then update stocks for sale
                ConvertMsg2Things(text);
                HandleOrder();
            };
            // IDK what this does but when i remove this it crashes
            tradeRBMQ.GetModel().BasicConsume(queue: tradeRBMQ.GetQueueName(),
                                              autoAck: true, // I didnt notice this doing anything
                                              consumer: consumer);
        }

        private void HandleOrder()
        {
            // Shows the current available stocks
            lblStockForSaleCount.Text = stocksForSale.ToString();
            lblPrice.Text = "$" + currentStonkValue.ToString();

            //stockValueGraph.Series["$$$"].Points.AddXY(stockValueGraph.Series["$$$"].Points.Count, newStonkValue);

            for (int i = 0; i < list.Count; i++)
            {
                if (i < stockValueGraph.Series["$$$"].Points.Count)
                    stockValueGraph.Series["$$$"].Points[i].SetValueXY(i, list[i]);
                else
                {
                    // Set Size of graph
                    var objChart = stockValueGraph.ChartAreas[0];

                    objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

                    objChart.AxisX.Maximum++;

                    if (list[i] > objChart.AxisY.Maximum - 100)
                        objChart.AxisY.Maximum = list[i] + 100;

                    stockValueGraph.Series["$$$"].Points.AddXY(i, list[i]);
                }
            }
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

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        // The Update Button
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateGraph();
            Send(CreateMsg()); // Push new Stock Count to the system
        }

        private void UpdateGraph()
        {
            // Set Size of graph
            var objChart = stockValueGraph.ChartAreas[0];

            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            // Setup stock value graph

            Random rand = new Random();

            int newStonkValue = currentStonkValue + rand.Next(-200, 200);

            if (newStonkValue < 100)
                newStonkValue = 100;

            currentStonkValue = newStonkValue;

            list.Add(newStonkValue);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var objChart = stockValueGraph.ChartAreas[0];

            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            objChart.AxisX.Minimum = objChart.AxisX.Maximum - 10;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            var objChart = stockValueGraph.ChartAreas[0];

            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;

            objChart.AxisX.Minimum = 0;
        }
    }
}
 