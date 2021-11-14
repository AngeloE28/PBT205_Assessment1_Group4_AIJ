
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.stockValueGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.updateStockButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.clearButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockValueGraph)).BeginInit();
            this.groupBox5.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(21, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Account";
            // 
            // lblStockCount
            // 
            this.lblStockCount.AutoSize = true;
            this.lblStockCount.Location = new System.Drawing.Point(135, 68);
            this.lblStockCount.Name = "lblStockCount";
            this.lblStockCount.Size = new System.Drawing.Size(33, 13);
            this.lblStockCount.TabIndex = 5;
            this.lblStockCount.Text = "value";
            // 
            // lblMoneyCount
            // 
            this.lblMoneyCount.AutoSize = true;
            this.lblMoneyCount.Location = new System.Drawing.Point(135, 43);
            this.lblMoneyCount.Name = "lblMoneyCount";
            this.lblMoneyCount.Size = new System.Drawing.Size(33, 13);
            this.lblMoneyCount.TabIndex = 4;
            this.lblMoneyCount.Text = "value";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(135, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(33, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "name";
            // 
            // lblStockCountTitle
            // 
            this.lblStockCountTitle.AutoSize = true;
            this.lblStockCountTitle.Location = new System.Drawing.Point(5, 68);
            this.lblStockCountTitle.Name = "lblStockCountTitle";
            this.lblStockCountTitle.Size = new System.Drawing.Size(118, 13);
            this.lblStockCountTitle.TabIndex = 2;
            this.lblStockCountTitle.Text = "XYZ Corp Stock Count:";
            // 
            // lblBalanceTitle
            // 
            this.lblBalanceTitle.AutoSize = true;
            this.lblBalanceTitle.Location = new System.Drawing.Point(5, 43);
            this.lblBalanceTitle.Name = "lblBalanceTitle";
            this.lblBalanceTitle.Size = new System.Drawing.Size(49, 13);
            this.lblBalanceTitle.TabIndex = 1;
            this.lblBalanceTitle.Text = "Balance:";
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Location = new System.Drawing.Point(5, 20);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(60, 13);
            this.lblNameTitle.TabIndex = 0;
            this.lblNameTitle.Text = "UserName:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStockForSaleCount);
            this.groupBox2.Controls.Add(this.lblPrice);
            this.groupBox2.Controls.Add(this.lblStockForSaleTitle);
            this.groupBox2.Controls.Add(this.lblPriceTitle);
            this.groupBox2.Location = new System.Drawing.Point(21, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 86);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stocks";
            // 
            // lblStockForSaleCount
            // 
            this.lblStockForSaleCount.AutoSize = true;
            this.lblStockForSaleCount.Location = new System.Drawing.Point(135, 57);
            this.lblStockForSaleCount.Name = "lblStockForSaleCount";
            this.lblStockForSaleCount.Size = new System.Drawing.Size(33, 13);
            this.lblStockForSaleCount.TabIndex = 3;
            this.lblStockForSaleCount.Text = "value";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(135, 27);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(37, 13);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "$1000";
            // 
            // lblStockForSaleTitle
            // 
            this.lblStockForSaleTitle.AutoSize = true;
            this.lblStockForSaleTitle.Location = new System.Drawing.Point(5, 57);
            this.lblStockForSaleTitle.Name = "lblStockForSaleTitle";
            this.lblStockForSaleTitle.Size = new System.Drawing.Size(127, 13);
            this.lblStockForSaleTitle.TabIndex = 1;
            this.lblStockForSaleTitle.Text = "XYZ Corp Stock for sale: ";
            // 
            // lblPriceTitle
            // 
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Location = new System.Drawing.Point(5, 27);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(114, 13);
            this.lblPriceTitle.TabIndex = 0;
            this.lblPriceTitle.Text = "XYZ Corp Stock Price:";
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(25, 19);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(64, 20);
            this.btnSell.TabIndex = 4;
            this.btnSell.Text = "Sell";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(135, 19);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(64, 20);
            this.btnBuy.TabIndex = 5;
            this.btnBuy.Text = "Buy";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(25, 19);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(64, 20);
            this.btnChat.TabIndex = 6;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnTracing
            // 
            this.btnTracing.Location = new System.Drawing.Point(121, 19);
            this.btnTracing.Name = "btnTracing";
            this.btnTracing.Size = new System.Drawing.Size(87, 20);
            this.btnTracing.TabIndex = 7;
            this.btnTracing.Text = "Contact Tracing";
            this.btnTracing.UseVisualStyleBackColor = true;
            this.btnTracing.Click += new System.EventHandler(this.btnTracing_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTracing);
            this.groupBox3.Controls.Add(this.btnChat);
            this.groupBox3.Location = new System.Drawing.Point(21, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 55);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Torrens Systems";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSell);
            this.groupBox4.Controls.Add(this.btnBuy);
            this.groupBox4.Location = new System.Drawing.Point(21, 227);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(235, 55);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trade Stock";
            // 
            // stockValueGraph
            // 
            this.stockValueGraph.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.stockValueGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stockValueGraph.Legends.Add(legend1);
            this.stockValueGraph.Location = new System.Drawing.Point(276, 23);
            this.stockValueGraph.Name = "stockValueGraph";
            this.stockValueGraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "$$$";
            series1.YValuesPerPoint = 6;
            this.stockValueGraph.Series.Add(series1);
            this.stockValueGraph.Size = new System.Drawing.Size(410, 259);
            this.stockValueGraph.TabIndex = 10;
            this.stockValueGraph.Text = "stockGraph";
            title1.Name = "Title1";
            title1.Text = "XYZ Corp Stock Value Over Time Chart";
            this.stockValueGraph.Titles.Add(title1);
            this.stockValueGraph.Click += new System.EventHandler(this.chart1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.showButton);
            this.groupBox5.Controls.Add(this.clearButton);
            this.groupBox5.Controls.Add(this.updateStockButton);
            this.groupBox5.Location = new System.Drawing.Point(276, 287);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(410, 55);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update Stocks";
            // 
            // updateStockButton
            // 
            this.updateStockButton.Location = new System.Drawing.Point(18, 19);
            this.updateStockButton.Name = "updateStockButton";
            this.updateStockButton.Size = new System.Drawing.Size(75, 23);
            this.updateStockButton.TabIndex = 0;
            this.updateStockButton.Text = "Update";
            this.updateStockButton.UseVisualStyleBackColor = true;
            this.updateStockButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(114, 19);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Hide";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(219, 18);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "Show All";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // TradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 352);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.stockValueGraph);
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
            ((System.ComponentModel.ISupportInitialize)(this.stockValueGraph)).EndInit();
            this.groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart stockValueGraph;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button updateStockButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button showButton;
    }
}