using ClientSahar.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsraelBnB
{
    public partial class FormSumToProperty : Form
    {
        Bitmap m_bitmap;
        public FormSumToProperty(Product product)
        {
            InitializeComponent();
            InitializeListViewForProduct(product);
        }

        private void InitializeListViewForProduct(Product product)
        {
            ListViewItem listViewItem;
            if (product.Catagory.ID == 1)
            {
                //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
                listViewItem = new ListViewItem(new[] { "בתים", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor) });
                //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
                listViewProducts.Columns[5].Text = "מספר קומות";
            }
            else
            {
                listViewItem = new ListViewItem(new[] { "דירות", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor) });
                //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
                listViewProducts.Columns[5].Text = "מספר קומה";
            }

            listViewProducts.Items.Add(listViewItem);
            pictureBox2.ImageLocation = FindPicturePath() + @"\" + product.Picture1;
            pictureBox3.ImageLocation = FindPicturePath() + @"\" + product.Picture2;
            pictureBox4.ImageLocation = FindPicturePath() + @"\" + product.Picture3;

        }


        private string FindPicturePath()
        {

            //מציאת הנתיב ממנו רץ היישום

            string path = Application.StartupPath;

            //מעבר לתיקייה בה שמורה התמונה

            path = path.Replace(@"bin\Debug", "");
            path = path.Replace(@"bin\Release", "");
            path = path + @"\Pictures\";
            return path;
        }
    }
}
