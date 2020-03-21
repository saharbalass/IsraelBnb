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
            if (isHouse)
            {
                FilllistViewHouses();
            }
            else if (!isHouse)
            {
                FilllistViewApartments();
            }
        }

        public void FilllistViewHouses()
        {
            HouseArr houseArr = new HouseArr();
            houseArr.Fill();

            House house;
            ListViewItem listViewItem;

            for (int i = 0; i < houseArr.Count; i++)
            {
                house = houseArr[i] as House;
                listViewItem = new ListViewItem(new[] { house.City.Name, house.Adress + " " + house.StreetNo, Convert.ToString(house.Size) + " מ''ר "});
                listViewProducts.Items.Add(listViewItem);
            }
        }

        public void FilllistViewApartments()
        {
            ApartmentArr apartmentArr = new ApartmentArr();
            apartmentArr.Fill();

            Apartment apartment;
            ListViewItem listViewItem;

            for (int i = 0; i < apartmentArr.Count; i++)
            {
                apartment = apartmentArr[i] as Apartment;
                listViewItem = new ListViewItem(new[] { apartment.City.Name, apartment.Adress + " " + apartment.StreetNo, Convert.ToString(apartment.Size) + " מ''ר " });
                listViewProducts.Items.Add(listViewItem);
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
