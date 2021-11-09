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
using System.Linq;

/// <summary>
/// This is the contact tracing system
/// </summary>

namespace PBT205_Assessment1_Group4_AIJ
{
    public partial class ContactTracingForm : Form, IRabbitMQ
    {
        // RabbitMQ setup variables        
        private String contactTraceRoomName = "contact.trace";        
        private String exchangeName = "trace";
        private static SetupRabbitMQ traceRBMQ;

        // Dictionary to keep track of the users
        private Dictionary<String, Vector2> contactTraceUsers;        

        // Variables to control the grid
        private int gridWidth = 10;
        private int gridHeight = 10;
        private int gridMinBoundary = -1;

        public ContactTracingForm()
        {
            InitializeComponent();

            // Create instance of the dictionary
            contactTraceUsers = new Dictionary<string, Vector2>();            

            // Initialize listbox
            listBxContactTrace.Items.Add("You Made Contact with: ");

            // Setup rabbitmq            
            traceRBMQ = new SetupRabbitMQ(userName: LoginForm.userName,
                                          password: LoginForm.pass,
                                          roomName: contactTraceRoomName,
                                          exchangeName: exchangeName,
                                          exchangeType: ExchangeType.Topic);

            // Initialize grid and dictionary
            InitializeGrid();

            // Give user a random position on the grid
            Random rand = new Random();
            float xPos = rand.Next(0, gridWidth);
            float yPos = rand.Next(0, gridHeight);

            // Add user
            AddUser(LoginForm.userName, new Vector2(xPos, yPos));
            lblUserNameLocation.Text = LoginForm.userName + " located at: ";
            lblLocation.Text = "[" + xPos + ", " + yPos + "]";            

            // Send an initial joining message similar to a handshake
            String messagePos = "[" + xPos + ", " + yPos + "]";
            Send(messagePos);
            StartConsume();
        }

        private void ContactTracingForm_Load(object sender, EventArgs e)
        {
            
        }

        public void Send(String message)
        {
            // Send Position with name
            var body = Encoding.UTF8.GetBytes(message);
            var props = traceRBMQ.GetModel().CreateBasicProperties();
            props.UserId = LoginForm.userName;
            traceRBMQ.GetModel().BasicPublish(exchange: this.exchangeName,
                                              routingKey: this.contactTraceRoomName,
                                              basicProperties: props,
                                              body: body);
        }

        public void StartConsume()
        {
            // Subscribe to incoming message
            var consumer = new EventingBasicConsumer(traceRBMQ.GetModel());
            consumer.Received += (sender, ea) =>
            {
                // Receive message
                var text = Encoding.UTF8.GetString(ea.Body.ToArray());
                var userID = ea.BasicProperties.UserId;                

                // Update the grid                
                Vector4 newPos = new Vector4();
                newPos = ConvertStringMsgToVector(text);
                HandlePos(userID, newPos);

                // Add user if its not added already
                AddUser(userID, new Vector2(newPos.X, newPos.Y));
            };
            traceRBMQ.GetModel().BasicConsume(queue: traceRBMQ.GetQueueName(),
                                              autoAck: true,
                                              consumer: consumer);
        }

        private Vector4 ConvertStringMsgToVector(String message)
        {
            // Converting a string to a vector 2 method
            // found in https://stackoverflow.com/questions/11170541/c-sharp-parsing-a-vector2-from-string
            // By: GETah, Date: 23/06/2012

            // Combined vector to return
            Vector4 vectorResult = new Vector4();            

            // Remove all the non numeric values besides the space inbetween
            message = message.Replace("[", "")
                             .Replace(",", "")
                             .Replace("]", "");

            // Store the message into seperate strings to parse to a float
            String[] vals = message.Split(' ');
            // Store the values in the vector
            if(vals.Length==2)
            {
                // Initial join, similar to a handshake
                // Old pos == new pos
                vectorResult.X = float.Parse(vals[0]);
                vectorResult.Y = float.Parse(vals[1]);
            }
            else if (vals.Length > 2)
            {
                // Old pos != new pos
                // Old pos and new pos get passed so theres two vector 2 to form
                vectorResult.X = float.Parse(vals[0]);
                vectorResult.Y = float.Parse(vals[1]);
                vectorResult.Z = float.Parse(vals[2]);
                vectorResult.W = float.Parse(vals[3]);
            }           

            // Return the resulting combined vector
            return vectorResult;
        }

        private void HandlePos(String name, Vector4 pos)
        {
            // Get the new and old pos from the combined vector
            Vector2 newPos = new Vector2();
            Vector2 oldPos = new Vector2();

            // X and Y of combined vector is new pos
            newPos.X = pos.X;
            newPos.Y = pos.Y;

            // Z and W of combined vector is old pos
            oldPos.X = pos.Z;
            oldPos.Y = pos.W;

            // Update the grid, user location
            UpdateGrid(newPos, oldPos, name);
            UpdateUserLocation(name, newPos);
            
            // Check if user made contact with other users
            ContactTraced(name);            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // User moves up
            Vector4 gridPos = PlayerMove(0.0f, -1.0f);

            // Make sure user doesn't go out of bounds
            if (gridPos.Y > gridMinBoundary)
            {
                String messagePos = "[" + gridPos.X + ", " + gridPos.Y + ", " + gridPos.Z + ", " + gridPos.W + "]";
                Send(messagePos);
            }
            else
                return; // User out of bounds, exit
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // User moves down            
            Vector4 gridPos = PlayerMove(0.0f, 1.0f);

            // Make sure user doesn't go out of bounds
            if (gridPos.Y < gridHeight)
            {
                String messagePos = "[" + gridPos.X + ", " + gridPos.Y + ", " + gridPos.Z + ", " + gridPos.W + "]";
                Send(messagePos);
            }
            else
                return; // User out of bounds, exit                   
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            // User moves to the left            
            Vector4 gridPos = PlayerMove(-1.0f, 0.0f);

            // Make sure user doesn't go out of bounds
            if (gridPos.X > gridMinBoundary)
            {
                String messagePos = "[" + gridPos.X + ", " + gridPos.Y + ", " + gridPos.Z + ", " + gridPos.W + "]";
                Send(messagePos);
            }
            else
                return; // User out of bounds, exit
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            // User moves to the right            
            Vector4 gridPos = PlayerMove(1.0f, 0.0f);

            // Make sure user doesn't go out of bounds
            if (gridPos.X < gridWidth)
            {
                String messagePos = "[" + gridPos.X + ", " + gridPos.Y + ", " + gridPos.Z + ", " + gridPos.W + "]";
                Send(messagePos);
            }
            else
                return; // User out of bounds, exit
        }

        private Vector4 PlayerMove(float x, float y)
        {
            // Get the new and old positions
            Vector2 newPos;
            Vector2 oldPos;

            // Update the new position
            oldPos = contactTraceUsers[LoginForm.userName];
            newPos = oldPos;            
            newPos.X += x;
            newPos.Y += y;            
            
            // Return a vector 4 formed from two vector 2
            return new Vector4(newPos.X, newPos.Y, oldPos.X, oldPos.Y);
        }

        private void UpdateGrid(Vector2 newPos, Vector2 oldPos, String name)
        {
            // Update the user position
            contactTraceUsers[name] = newPos;

            // Clear the old spot of the user by removing only its name
            // Don't clear the spot incase there are more than one user on the spot
            String oldGridVal = dataGridPosSystem[(int)oldPos.X, (int)oldPos.Y].Value.ToString();
            if (oldGridVal.Contains(name))
                oldGridVal = oldGridVal.Replace(name, "")
                                 .Replace("  ", "");
            dataGridPosSystem[(int)oldPos.X, (int)oldPos.Y].Value = oldGridVal;

            // Update the grid and position information
            var newGridVal = dataGridPosSystem[(int)contactTraceUsers[name].X, (int)contactTraceUsers[name].Y].Value;
            if (!String.Equals(newGridVal, " ") || !String.Equals(newGridVal, ""))
            {
                newGridVal = newGridVal + " " + name;
            }
            else
                newGridVal = name;
            dataGridPosSystem[(int)contactTraceUsers[name].X, (int)contactTraceUsers[name].Y].Value = newGridVal;            
        }

        private void UpdateUserLocation(String name, Vector2 newPos)
        {
            // Show the current location of this user
            if (String.Equals(name, LoginForm.userName))
                lblLocation.Text = "[" + newPos.X + ", " + newPos.Y + "]";
            else
                return; // Not this user, exit
        }    

        private void InitializeGrid()
        {
            // Create instance of the users
            contactTraceUsers = new Dictionary<string, Vector2>();

            // Initialize Grid Size
            dataGridPosSystem.ColumnCount = gridWidth;
            dataGridPosSystem.RowCount = gridHeight;

            // Add the numeric title values to both column and rows
            for(int i = 0; i < gridWidth; i++)
            {
                // Add numeric titles for column and rows
                dataGridPosSystem.Columns[i].Name = i.ToString();
                dataGridPosSystem.Rows[i].HeaderCell.Value = dataGridPosSystem.Rows[i].Index.ToString();

                // Initialize the cells
                for (int j = 0; j < gridHeight; j++)
                    dataGridPosSystem[i, j].Value = "";

                // Resize rows and columns
                dataGridPosSystem.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                dataGridPosSystem.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            
        }

        private void AddUser(String userName, Vector2 pos)
        {
            // Add the user if its not added yet
            if (contactTraceUsers.ContainsKey(userName))
                return; // Exit, user already in the dictionary
            else
                contactTraceUsers.Add(userName, pos);

        }

        private void ContactTraced(String name)
        {
            // Get duplicate values from keys in dictionary
            var contactDuplicates = contactTraceUsers.GroupBy(x => x.Value)
                                                     .Where(x => x.Count() > 1)
                                                     .Select(x => x.Key);

            // Create a list for filtering
            List<String> users = new List<string>();
                        
            // Add the traced to the listbox
            foreach (var contacts in contactDuplicates)
            {
                // Value is now key
                // Get the original key
                foreach (var keyValue in contactTraceUsers)
                {                    
                    // Find the actual key
                    if (keyValue.Value == contacts)
                    {                     
                        users.Add(keyValue.Key);
                     
                        // Check if this user is in the list
                        if (users.Contains(LoginForm.userName))
                        {
                            // Don't add the user itself
                            if (keyValue.Key != LoginForm.userName)
                            {
                                // Add it to the list box if item is not a duplicate
                                if (listBxContactTrace.Items.Contains(keyValue.Key + " at [" + keyValue.Value.X + ", " + keyValue.Value.Y + "]"))
                                    break; // Exit, it will just add a duplicate
                                else
                                    listBxContactTrace.Items.Add(keyValue.Key + " at [" + keyValue.Value.X + ", " + keyValue.Value.Y + "]");

                                // Remove the current user that was displayed
                                users.Remove(keyValue.Key);
                            }
                        }
                        else
                            return; // Name not in the list, exit
                    }                    
                }
            } 
            users.Clear(); // Clear the list, incase one name didn't get removed for the next tracing
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            // Hides the contact tracing form
            LoginForm.contactTracingForm.Hide();

            // Shows the chat from            
            LoginForm.chatForm.Location = LoginForm.contactTracingForm.Location;
            LoginForm.chatForm.Show();
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            // Hides the contact tracing form
            LoginForm.contactTracingForm.Hide();

            // Show the trading form
            LoginForm.tradeForm.Location = LoginForm.contactTracingForm.Location;
            LoginForm.tradeForm.Show();
        }
    }
}
