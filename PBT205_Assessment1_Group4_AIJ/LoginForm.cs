using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace PBT205_Assessment1_Group4_AIJ
{
    public struct tradeUser
    {
        // Variables of a user for trading
        public int stockCount;
        public double balance;        
    }    

    public partial class LoginForm : Form
    {
        // Rabbitmq variables instances
        public static String userName = "";
        public static String pass = "";
        public String chatRoomName = "";

        // Create instances to control which system to show
        public static ChatForm chatForm;
        public static TradingForm tradeForm;
        public static ContactTracingForm contactTracingForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Hide form 1
            this.Hide();

            // Get the values to pass to form2
            userName = txtbxUserName.Text;
            pass = txtbxPassword.Text;
            chatRoomName = txtbxChatRoomName.Text;

            // Show and create the instance of the chat form
            chatForm = new ChatForm();
            chatForm.Location = Program.loginForm.Location;
            chatForm.Show();

            // Create instance of the trading form
            tradeForm = new TradingForm();
            tradeForm.Location = chatForm.Location;

            // Create instance of the contact tracing form
            contactTracingForm = new ContactTracingForm();
            contactTracingForm.Location = chatForm.Location;
        }
    }
}
