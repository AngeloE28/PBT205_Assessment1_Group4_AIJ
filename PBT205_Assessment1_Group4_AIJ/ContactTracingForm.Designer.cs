
namespace PBT205_Assessment1_Group4_AIJ
{
    partial class ContactTracingForm
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
            LoginForm.tradeForm.Close();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridPosSystem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblUserNameLocation = new System.Windows.Forms.Label();
            this.listBxContactTrace = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTrade = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnInfected = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBxTitle = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPosSystem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpBxTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridPosSystem
            // 
            this.dataGridPosSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPosSystem.Location = new System.Drawing.Point(12, 12);
            this.dataGridPosSystem.Name = "dataGridPosSystem";
            this.dataGridPosSystem.ReadOnly = true;
            this.dataGridPosSystem.RowTemplate.Height = 25;
            this.dataGridPosSystem.Size = new System.Drawing.Size(468, 404);
            this.dataGridPosSystem.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRight);
            this.groupBox1.Controls.Add(this.btnDown);
            this.groupBox1.Controls.Add(this.btnLeft);
            this.groupBox1.Controls.Add(this.btnUp);
            this.groupBox1.Location = new System.Drawing.Point(36, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movement Controls";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(139, 62);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(50, 25);
            this.btnRight.TabIndex = 3;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(83, 62);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 25);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "v";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(27, 62);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(50, 25);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(83, 31);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(50, 25);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLocation);
            this.groupBox2.Controls.Add(this.lblUserNameLocation);
            this.groupBox2.Location = new System.Drawing.Point(268, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Location";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(57, 62);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(46, 15);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "located";
            // 
            // lblUserNameLocation
            // 
            this.lblUserNameLocation.AutoSize = true;
            this.lblUserNameLocation.Location = new System.Drawing.Point(42, 31);
            this.lblUserNameLocation.Name = "lblUserNameLocation";
            this.lblUserNameLocation.Size = new System.Drawing.Size(61, 15);
            this.lblUserNameLocation.TabIndex = 0;
            this.lblUserNameLocation.Text = "userName";
            // 
            // listBxContactTrace
            // 
            this.listBxContactTrace.FormattingEnabled = true;
            this.listBxContactTrace.ItemHeight = 15;
            this.listBxContactTrace.Location = new System.Drawing.Point(495, 12);
            this.listBxContactTrace.Name = "listBxContactTrace";
            this.listBxContactTrace.Size = new System.Drawing.Size(217, 394);
            this.listBxContactTrace.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTrade);
            this.groupBox3.Controls.Add(this.btnChat);
            this.groupBox3.Location = new System.Drawing.Point(495, 472);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 77);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Torrens Systems";
            // 
            // btnTrade
            // 
            this.btnTrade.Location = new System.Drawing.Point(125, 33);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(75, 23);
            this.btnTrade.TabIndex = 1;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = true;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(18, 33);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(75, 23);
            this.btnChat.TabIndex = 0;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnInfected
            // 
            this.btnInfected.Location = new System.Drawing.Point(125, 19);
            this.btnInfected.Name = "btnInfected";
            this.btnInfected.Size = new System.Drawing.Size(75, 23);
            this.btnInfected.TabIndex = 5;
            this.btnInfected.Text = "Infected";
            this.btnInfected.UseVisualStyleBackColor = true;
            this.btnInfected.Click += new System.EventHandler(this.btnInfected_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Show Infected";
            // 
            // grpBxTitle
            // 
            this.grpBxTitle.Controls.Add(this.btnInfected);
            this.grpBxTitle.Controls.Add(this.label1);
            this.grpBxTitle.Location = new System.Drawing.Point(495, 413);
            this.grpBxTitle.Name = "grpBxTitle";
            this.grpBxTitle.Size = new System.Drawing.Size(217, 53);
            this.grpBxTitle.TabIndex = 7;
            this.grpBxTitle.TabStop = false;
            this.grpBxTitle.Text = "Users Infected";
            // 
            // ContactTracingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 561);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listBxContactTrace);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridPosSystem);
            this.Controls.Add(this.grpBxTitle);
            this.Name = "ContactTracingForm";
            this.Text = "Torrens Cube Co. Contact Tracing Application";
            this.Load += new System.EventHandler(this.ContactTracingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPosSystem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.grpBxTitle.ResumeLayout(false);
            this.grpBxTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridPosSystem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblUserNameLocation;
        private System.Windows.Forms.ListBox listBxContactTrace;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnInfected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBxTitle;
    }
}