namespace IsraelBnB.UserControls
{
    partial class SecondUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondUC));
            this.label2 = new System.Windows.Forms.Label();
            this.firstUC1 = new IsraelBnB.UserControls.FirstUC();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(149, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 57);
            this.label2.TabIndex = 4;
            // 
            // firstUC1
            // 
            this.firstUC1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.firstUC1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.firstUC1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("firstUC1.BackgroundImage")));
            this.firstUC1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.firstUC1.Location = new System.Drawing.Point(2, 0);
            this.firstUC1.Name = "firstUC1";
            this.firstUC1.Size = new System.Drawing.Size(665, 388);
            this.firstUC1.TabIndex = 0;
            // 
            // SecondUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstUC1);
            this.Name = "SecondUC";
            this.Size = new System.Drawing.Size(665, 388);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FirstUC firstUC1;
        private System.Windows.Forms.Label label2;
    }
}
