
namespace PBT205_Assessment1_Group4_AIJ
{
    partial class TradingForm
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
            LoginForm.chatForm.Close();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStockCount = new System.Windows.Forms.Label();
            this.lblMoneyCount = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblStockCountTitle = new System.Windows.Forms.Label();
            this.lblBalanceTitle = new System.Windows.Forms.Label();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStockForSaleCount = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStockForSaleTitle = new System.Windows.Forms.Label();
            this.lblPriceTitle = new System.Windows.Forms.Label();
            this.btnSell = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnTracing = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStockCount);
            this.groupBox1.Controls.Add(this.lblMoneyCount);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblStockCountTitle);
            this.groupBox1.Controls.Add(this.lblBalanceTitle);
            this.groupBox1.Controls.Add(this.lblNameTitle);
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Account";
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(157, 79);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(35, 15);
            this.lblStockCount.TabIndex = 5;
            this.lblStockCount.Text = "value";
            // 
            // lblMoneyCount
            // 
            this.lblMoneyCount.AutoSize = true;
            this.lblMoneyCount.Location = new System.Drawing.Point(157, 50);
            this.lblMoneyCount.Name = "lblMoneyCount";
            this.lblMoneyCount.Size = new System.Drawing.Size(35, 15);
            this.lblMoneyCount.TabIndex = 4;
            this.lblMoneyCount.Text = "value";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(157, 23);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(37, 15);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "name";
            // 
            // lblStockCountTitle
            // 
            this.lblStockCountTitle.AutoSize = true;
            this.lblStockCountTitle.Location = new System.Drawing.Point(6, 79);
            this.lblStockCountTitle.Name = "lblStockCountTitle";
            this.lblStockCountTitle.Size = new System.Drawing.Size(128, 15);
            this.lblStockCountTitle.TabIndex = 2;
            this.lblStockCountTitle.Text = "XYZ Corp Stock Count:";
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Location = new System.Drawing.Point(6, 50);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(51, 15);
            this.lblBalanceTitle.TabIndex = 1;
            this.lblBalanceTitle.Text = "Balance:";
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Location = new System.Drawing.Point(6, 23);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(65, 15);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "UserName:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStockForSaleCount);
            this.groupBox2.Controls.Add(this.lblPrice);
            this.groupBox2.Controls.Add(this.lblStockForSaleTitle);
            this.groupBox2.Controls.Add(this.lblPriceTitle);
            this.groupBox2.Location = new System.Drawing.Point(25, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 99);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stocks";
            // 
            // lblStockForSaleCount
            // 
            this.lblStockForSaleCount.AutoSize = true;
            this.lblStockForSaleCount.Location = new System.Drawing.Point(157, 66);
            this.lblStockForSaleCount.Name = "lblStockForSaleCount";
            this.lblStockForSaleCount.Size = new System.Drawing.Size(35, 15);
            this.lblStockForSaleCount.TabIndex = 3;
            this.lblStockForSaleCount.Text = "value";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(157, 31);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 15);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "$1000";
            // 
            // lblStockForSaleTitle
            // 
            this.lblStockForSaleTitle.AutoSize = true;
            this.lblStockForSaleTitle.Location = new System.Drawing.Point(6, 66);
            this.lblStockForSaleTitle.Name = "lblStockForSaleTitle";
            this.lblStockForSaleTitle.Size = new System.Drawing.Size(136, 15);
            this.lblStockForSaleTitle.TabIndex = 1;
            this.lblStockForSaleTitle.Text = "XYZ Corp Stock for sale: ";
            // 
            // lblPriceTitle
            // 
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Location = new System.Drawing.Point(6, 31);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(121, 15);
            this.lblPriceTitle.TabIndex = 0;
            this.lblPriceTitle.Text = "XYZ Corp Stock Price:";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(29, 22);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(75, 23);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(157, 22);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(29, 22);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(75, 23);
            this.btnChat.TabIndex = 6;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnTracing
            // 
            this.btnTracing.Location = new System.Drawing.Point(141, 22);
            this.btnTracing.Name = "btnTracing";
            this.btnTracing.Size = new System.Drawing.Size(101, 23);
            this.btnTracing.TabIndex = 7;
            this.btnTracing.Text = "Contact Tracing";
            this.btnTracing.UseVisualStyleBackColor = true;
            this.btnTracing.Click += new System.EventHandler(this.btnTracing_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTracing);
            this.groupBox3.Controls.Add(this.btnChat);
            this.groupBox3.Location = new System.Drawing.Point(25, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 63);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Torrens Systems";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSell);
            this.groupBox4.Controls.Add(this.btnBuy);
            this.groupBox4.Location = new System.Drawing.Point(25, 262);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 63);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trade Stock";
            // 
            // TradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 406);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TradingForm";
            this.Text = "Torrens Cube Co. Trading Application";
            this.Load += new System.EventHandler(this.TradingForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStockCount;
        private System.Windows.Forms.Label lblMoneyCount;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblStockCountTitle;
        private System.Windows.Forms.Label lblBalanceTitle;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblStockForSaleCount;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStockForSaleTitle;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnTracing;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}