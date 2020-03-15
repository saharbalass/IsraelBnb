namespace IsraelBnB
{
    partial class FormAddCity
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddCity));
            this.errorCityNameLabel = new System.Windows.Forms.Label();
            this.listBoxCity = new System.Windows.Forms.ListBox();
            this.Label_City_ID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Name_City = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSaveSignUp = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorCityNameLabel
            // 
            this.errorCityNameLabel.AutoSize = true;
            this.errorCityNameLabel.ForeColor = System.Drawing.Color.Red;
            this.errorCityNameLabel.Location = new System.Drawing.Point(437, 145);
            this.errorCityNameLabel.Name = "errorCityNameLabel";
            this.errorCityNameLabel.Size = new System.Drawing.Size(13, 17);
            this.errorCityNameLabel.TabIndex = 56;
            this.errorCityNameLabel.Text = "*";
            this.errorCityNameLabel.Visible = false;
            // 
            // listBoxCity
            // 
            this.listBoxCity.FormattingEnabled = true;
            this.listBoxCity.ItemHeight = 16;
            this.listBoxCity.Location = new System.Drawing.Point(150, 185);
            this.listBoxCity.Name = "listBoxCity";
            this.listBoxCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxCity.Size = new System.Drawing.Size(196, 148);
            this.listBoxCity.TabIndex = 53;
            this.listBoxCity.DoubleClick += new System.EventHandler(this.listBox_Client_DoubleClick);
            // 
            // Label_City_ID
            // 
            this.Label_City_ID.AutoSize = true;
            this.Label_City_ID.Location = new System.Drawing.Point(296, 106);
            this.Label_City_ID.Name = "Label_City_ID";
            this.Label_City_ID.Size = new System.Drawing.Size(16, 17);
            this.Label_City_ID.TabIndex = 52;
            this.Label_City_ID.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 51;
            this.label10.Text = "שם העיר";
            // 
            // textBox_Name_City
            // 
            this.textBox_Name_City.Location = new System.Drawing.Point(212, 143);
            this.textBox_Name_City.Name = "textBox_Name_City";
            this.textBox_Name_City.Size = new System.Drawing.Size(100, 22);
            this.textBox_Name_City.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(318, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 17);
            this.label9.TabIndex = 49;
            this.label9.Text = "מספר סידורי של העיר";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(116)))), ((int)(((byte)(216)))));
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 49);
            this.panel1.TabIndex = 58;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(116)))), ((int)(((byte)(216)))));
            this.buttonExit.FlatAppearance.BorderSize = 0;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(884, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(50, 49);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonSaveSignUp
            // 
            this.buttonSaveSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.buttonSaveSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveSignUp.FlatAppearance.BorderSize = 0;
            this.buttonSaveSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveSignUp.ForeColor = System.Drawing.Color.White;
            this.buttonSaveSignUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveSignUp.Image")));
            this.buttonSaveSignUp.Location = new System.Drawing.Point(0, 339);
            this.buttonSaveSignUp.Name = "buttonSaveSignUp";
            this.buttonSaveSignUp.Size = new System.Drawing.Size(174, 130);
            this.buttonSaveSignUp.TabIndex = 59;
            this.buttonSaveSignUp.Text = "שמור";
            this.buttonSaveSignUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSaveSignUp.UseVisualStyleBackColor = false;
            this.buttonSaveSignUp.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(171, 339);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(151, 130);
            this.button6.TabIndex = 60;
            this.button6.Text = "רענן";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.RefreshButtonClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(321, 339);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 130);
            this.button3.TabIndex = 62;
            this.button3.Text = "מחק";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(116)))), ((int)(((byte)(216)))));
            this.label1.Location = new System.Drawing.Point(101, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 57);
            this.label1.TabIndex = 64;
            this.label1.Text = "Israel BnB";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // FormAddCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 470);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonSaveSignUp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.errorCityNameLabel);
            this.Controls.Add(this.listBoxCity);
            this.Controls.Add(this.Label_City_ID);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_Name_City);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormAddCity";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FormAddCity";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label errorCityNameLabel;
        private System.Windows.Forms.ListBox listBoxCity;
        private System.Windows.Forms.Label Label_City_ID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Name_City;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSaveSignUp;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}