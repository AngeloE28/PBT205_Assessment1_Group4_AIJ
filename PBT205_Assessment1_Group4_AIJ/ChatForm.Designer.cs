
namespace PBT205_Assessment1_Group4_AIJ
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            // Close all the forms
            Program.loginForm.Close();
            LoginForm.tradeForm.Close();
            LoginForm.contactTracingForm.Close();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbxInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnTrade = new System.Windows.Forms.Button();
            this.listbxMsgHistory = new System.Windows.Forms.ListBox();
            this.btnContactTrace = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbxInput
            // 
            this.txtbxInput.Location = new System.Drawing.Point(12, 439);
            this.txtbxInput.Name = "txtbxInput";
            this.txtbxInput.Size = new System.Drawing.Size(435, 23);
            this.txtbxInput.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(471, 439);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(471, 398);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(75, 23);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(33, 21);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(75, 23);
            this.btnTrade.TabIndex = 3;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // listbxMsgHistory
            // 
            this.listbxMsgHistory.FormattingEnabled = true;
            this.listbxMsgHistory.ItemHeight = 15;
            this.listbxMsgHistory.Location = new System.Drawing.Point(12, 13);
            this.listbxMsgHistory.Name = "listbxMsgHistory";
            this.listbxMsgHistory.Size = new System.Drawing.Size(534, 364);
            this.listbxMsgHistory.TabIndex = 4;
            // 
            // btnContactTrace
            // 
            this.btnContactTrace.Location = new System.Drawing.Point(141, 21);
            this.btnContactTrace.Name = "btnContactTrace";
            this.btnContactTrace.Size = new System.Drawing.Size(92, 23);
            this.btnContactTrace.TabIndex = 5;
            this.btnContactTrace.Text = "Contact Trace";
            this.btnContactTrace.UseVisualStyleBackColor = true;
            this.btnContactTrace.Click += new System.EventHandler(this.btnContactTrace_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnContactTrace);
            this.groupBox1.Controls.Add(this.btnTrade);
            this.groupBox1.Location = new System.Drawing.Point(109, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Torrens Systems";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listbxMsgHistory);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtbxInput);
            this.Name = "ChatForm";
            this.Text = "Torrens Cube Co. Chat Application";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.ListBox listbxMsgHistory;
        private System.Windows.Forms.Button btnContactTrace;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}