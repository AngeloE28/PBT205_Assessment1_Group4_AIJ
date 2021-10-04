using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBT205_Assessment1_Group4_AIJ
{
    public struct user
    {
        // Variables of a user        
        public int stockCount;
        public double balance;

        // Add more for task 3 later
    }

    public partial class LoginForm : Form
    {
        // Rabbitmq variables
        public static String username = "";
        public static String pass = "";
        public static String chatroom = "";

        // Create instances to control which system to show
        public static ChatForm chatForm;
        public static TradingForm tradeForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Hide form 1
            this.Hide();

            // Get the values to pass to form2
            username = txtbxUserName.Text;
            pass = txtbxPassword.Text;
            chatroom = txtbxChatRoomName.Text;

            // Show and create the instance of chat form
            chatForm = new ChatForm();
            chatForm.Show();

            // Create instance of trading form
            tradeForm = new TradingForm();
        }
    }
}
