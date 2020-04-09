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
                listViewItem = new ListViewItem(new[] { "בתים", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor),Convert.ToString(product.Price)});
                //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
                listViewProducts.Columns[5].Text = "מספר קומות";
            }
            else
            {
                listViewItem = new ListViewItem(new[] { "דירות", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor), Convert.ToString(product.Price)});
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

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //מגדיר את העמוד שיודפס - כולל מרחק מהשמאל ומלמעלה
            e.Graphics.DrawImage(m_bitmap, 100, 100);
        }

        private void CaptureScreen()
        {

            //תפיסת החלק של הטופס להדפסה כולל הרשימה והכותרת שמעליה - לתוך תמונת הסיביות

            int addAboveListView = 30;
            int moveLeft = 150;
            Graphics graphics = listViewProducts.CreateGraphics();
            Size curSize = listViewProducts.Size;
            curSize.Height += addAboveListView;
            curSize.Width += moveLeft;
            m_bitmap = new Bitmap(curSize.Width, curSize.Height, graphics);
            graphics = Graphics.FromImage(m_bitmap);
            Point panelLocation = PointToScreen(listViewProducts.Location);
            graphics.CopyFromScreen(panelLocation.X, panelLocation.Y - addAboveListView,
            moveLeft, 0, curSize);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
