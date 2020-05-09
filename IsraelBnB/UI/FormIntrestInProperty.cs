using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsraelBnB.UI
{
    public partial class FormIntrestInProperty : Form
    {
        public int intrest;
        public FormIntrestInProperty()
        {
            InitializeComponent();
        }

        private bool CheckFormDialog()
        {
            return radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton0.Checked;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((sender) as RadioButton).Name == "radioButton0")
            {
                intrest = 0;
            }
            if (((sender) as RadioButton).Name == "radioButton1")
            {
                intrest = 1;
            }
            if (((sender) as RadioButton).Name == "radioButton2")
            {
                intrest = 2;
            }
            if (((sender) as RadioButton).Name == "radioButton3")
            {
                intrest = 3;
            }
            if (((sender) as RadioButton).Name == "radioButton4")
            {
                intrest = 4;
            }
            if (((sender) as RadioButton).Name == "radioButton5")
            {
                intrest = 5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckFormDialog())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("חובה לבחור באחת מהאופציות", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}
