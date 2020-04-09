namespace IsraelBnB
{
    partial class FormAllProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAllProperties));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdresscolumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CitycolumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FiltiringLabelName = new System.Windows.Forms.Label();
            this.FiltiringLabelCompany = new System.Windows.Forms.Label();
            this.textBox_FilterName = new System.Windows.Forms.TextBox();
            this.comboBox_FilterCity = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBoxPriceTill = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBoxPriceFrom = new System.Windows.Forms.TextBox();
            this.buttonFillter = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.document_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(116)))), ((int)(((byte)(216)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 86);
            this.panel2.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(105, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 57);
            this.label1.TabIndex = 66;
            this.label1.Text = "Israel BnB";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrint.Image")));
            this.buttonPrint.Location = new System.Drawing.Point(0, 0);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(162, 100);
            this.buttonPrint.TabIndex = 4;
            this.buttonPrint.Text = "הורד פרטים";
            this.buttonPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(211)))));
            this.panel1.Controls.Add(this.buttonPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 100);
            this.panel1.TabIndex = 3;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "גודל";
            // 
            // AdresscolumnHeader4
            // 
            this.AdresscolumnHeader4.Text = "כתובת";
            this.AdresscolumnHeader4.Width = 198;
            // 
            // CitycolumnHeader3
            // 
            this.CitycolumnHeader3.Text = "עיר";
            this.CitycolumnHeader3.Width = 95;
            // 
            // listViewProducts
            // 
            this.listViewProducts.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewProducts.HideSelection = false;
            this.listViewProducts.Location = new System.Drawing.Point(0, 161);
            this.listViewProducts.Margin = new System.Windows.Forms.Padding(4);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.RightToLeftLayout = true;
            this.listViewProducts.Size = new System.Drawing.Size(652, 208);
            this.listViewProducts.TabIndex = 61;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "עיר";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "כתובת";
            this.columnHeader2.Width = 198;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "גודל";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "מחיר";
            this.columnHeader4.Width = 76;
            // 
            // FiltiringLabelName
            // 
            this.FiltiringLabelName.AutoSize = true;
            this.FiltiringLabelName.Location = new System.Drawing.Point(587, 88);
            this.FiltiringLabelName.Name = "FiltiringLabelName";
            this.FiltiringLabelName.Size = new System.Drawing.Size(25, 17);
            this.FiltiringLabelName.TabIndex = 31;
            this.FiltiringLabelName.Text = "שם";
            // 
            // FiltiringLabelCompany
            // 
            this.FiltiringLabelCompany.AutoSize = true;
            this.FiltiringLabelCompany.Location = new System.Drawing.Point(368, 88);
            this.FiltiringLabelCompany.Name = "FiltiringLabelCompany";
            this.FiltiringLabelCompany.Size = new System.Drawing.Size(27, 17);
            this.FiltiringLabelCompany.TabIndex = 33;
            this.FiltiringLabelCompany.Text = "עיר";
            // 
            // textBox_FilterName
            // 
            this.textBox_FilterName.Location = new System.Drawing.Point(470, 85);
            this.textBox_FilterName.Name = "textBox_FilterName";
            this.textBox_FilterName.Size = new System.Drawing.Size(111, 22);
            this.textBox_FilterName.TabIndex = 32;
            // 
            // comboBox_FilterCity
            // 
            this.comboBox_FilterCity.FormattingEnabled = true;
            this.comboBox_FilterCity.Location = new System.Drawing.Point(251, 85);
            this.comboBox_FilterCity.Name = "comboBox_FilterCity";
            this.comboBox_FilterCity.Size = new System.Drawing.Size(111, 24);
            this.comboBox_FilterCity.TabIndex = 66;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(368, 110);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(54, 17);
            this.label48.TabIndex = 85;
            this.label48.Text = "עד מחיר";
            // 
            // textBoxPriceTill
            // 
            this.textBoxPriceTill.Location = new System.Drawing.Point(223, 110);
            this.textBoxPriceTill.Name = "textBoxPriceTill";
            this.textBoxPriceTill.Size = new System.Drawing.Size(139, 22);
            this.textBoxPriceTill.TabIndex = 84;
            this.textBoxPriceTill.Text = "0";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(587, 113);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(43, 17);
            this.label46.TabIndex = 82;
            this.label46.Text = "ממחיר";
            // 
            // textBoxPriceFrom
            // 
            this.textBoxPriceFrom.Location = new System.Drawing.Point(442, 113);
            this.textBoxPriceFrom.Name = "textBoxPriceFrom";
            this.textBoxPriceFrom.Size = new System.Drawing.Size(139, 22);
            this.textBoxPriceFrom.TabIndex = 81;
            this.textBoxPriceFrom.Text = "0";
            // 
            // buttonFillter
            // 
            this.buttonFillter.Location = new System.Drawing.Point(0, 86);
            this.buttonFillter.Name = "buttonFillter";
            this.buttonFillter.Size = new System.Drawing.Size(75, 30);
            this.buttonFillter.TabIndex = 86;
            this.buttonFillter.Text = "סנן";
            this.buttonFillter.UseVisualStyleBackColor = true;
            this.buttonFillter.Click += new System.EventHandler(this.buttonFillter_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.Color.Red;
            this.label47.Location = new System.Drawing.Point(617, 88);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(13, 17);
            this.label47.TabIndex = 87;
            this.label47.Text = "*";
            this.label47.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(633, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 88;
            this.label2.Text = "*";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(401, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 17);
            this.label3.TabIndex = 89;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(423, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 17);
            this.label4.TabIndex = 90;
            this.label4.Text = "*";
            this.label4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 91;
            this.button1.Text = "הראה נכסים ללא סינון";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "נכסים";
            // 
            // FormAllProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.buttonFillter);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.textBoxPriceTill);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.textBoxPriceFrom);
            this.Controls.Add(this.comboBox_FilterCity);
            this.Controls.Add(this.textBox_FilterName);
            this.Controls.Add(this.FiltiringLabelCompany);
            this.Controls.Add(this.FiltiringLabelName);
            this.Controls.Add(this.listViewProducts);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAllProperties";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "FormAllHouses";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.ColumnHeader AdresscolumnHeader4;
        private System.Windows.Forms.ColumnHeader CitycolumnHeader3;
        private System.Windows.Forms.ListView listViewProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label FiltiringLabelName;
        private System.Windows.Forms.Label FiltiringLabelCompany;
        private System.Windows.Forms.TextBox textBox_FilterName;
        private System.Windows.Forms.ComboBox comboBox_FilterCity;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBoxPriceTill;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBoxPriceFrom;
        private System.Windows.Forms.Button buttonFillter;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}