using ClientSahar;
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
    public partial class FormAllProperties : Form
    {
        Bitmap m_bitmap;
        public FormAllProperties(bool isHouse)
        {
            InitializeComponent();
            FilllistViewProducts(isHouse);
        }

        public void FilllistViewProducts(bool isHouse)
        {
            ProductArr productArr = new ProductArr();
            productArr.Fill();

            Product product;
            ListViewItem listViewItem;

            for (int i = 0; i < productArr.Count; i++)
            {
                product = productArr[i] as Product;
                if (!isHouse)
                {
                    if ((productArr[i] as Product).Catagory.ID == 2)
                    {
                        listViewItem = new ListViewItem(new[] { product.City.Name, product.Adress + " " + product.StreetNo, Convert.ToString(product.Size) + " מ''ר ", Convert.ToString(product.Price) });
                        listViewProducts.Items.Add(listViewItem);
                    }

                }
                else
                {
                    if ((productArr[i] as Product).Catagory.ID == 1)
                    {
                        listViewItem = new ListViewItem(new[] { product.City.Name, product.Adress + " " + product.StreetNo, Convert.ToString(product.Size) + " מ''ר ", Convert.ToString(product.Price) });
                        listViewProducts.Items.Add(listViewItem);
                    }
                }

            }
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
