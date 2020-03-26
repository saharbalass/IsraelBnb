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
    public partial class FormAgreement : Form
    {
        Bitmap m_bitmap;
        public FormAgreement(Client client, Product product/*,House house, Apartment apartment*/)
        {
            InitializeComponent();
            FillListView(client, product);


        }
        private void FillListViewHouse(Client client, House house)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client1 = new Client();
            client1 = clientArr.ReturnClientWithID(house.Client);
            //מוסיף נתונים לפקד תיבת התצוגה
            //יצירת מקור הנתונים

            ListViewItem listViewItem;

            //יצירת פריט-תיבת-תצוגה
            listViewItem = new ListViewItem(new[] { client.FullName, "", client.City.Name, "" });
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewProducts.Items.Add(listViewItem);
            listViewItem = new ListViewItem(new[] { client1.FullName, "בית", house.City.Name, house.Adress +" "+house.StreetNo, Convert.ToString(house.Size) });
            listViewProducts.Items.Add(listViewItem);


        }

        private void FillListViewApartment(Client client, Apartment apartment)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client1 = new Client();
            client1 = clientArr.ReturnClientWithID(apartment.Client);
            //מוסיף נתונים לפקד תיבת התצוגה
            //יצירת מקור הנתונים

            ListViewItem listViewItem;

            //יצירת פריט-תיבת-תצוגה
            listViewItem = new ListViewItem(new[] { client.FullName, "", client.City.Name, "" });
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewProducts.Items.Add(listViewItem);
            listViewItem = new ListViewItem(new[] { client1.FullName, "דירה", apartment.City.Name, apartment.Adress + " " + apartment.StreetNo+ " מספר דירה:"+ apartment.AptNo,Convert.ToString(apartment.Size) });
            listViewProducts.Items.Add(listViewItem);


        }
        private void FillListView(Client client, Product product)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client1 = new Client();
            client1 = clientArr.ReturnClientWithID(product.Client);
            //מוסיף נתונים לפקד תיבת התצוגה
            //יצירת מקור הנתונים

            ListViewItem listViewItem;

            //יצירת פריט-תיבת-תצוגה
            listViewItem = new ListViewItem(new[] { client.FullName, "", client.City.Name, "" });
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewProducts.Items.Add(listViewItem);
            if (product.Catagory.ID == 1)
            {
                listViewItem = new ListViewItem(new[] { client1.FullName, "בית", product.City.Name, product.Adress + " " + product.StreetNo, Convert.ToString(product.Size) });
            }
            else
            {
                listViewItem = new ListViewItem(new[] { client1.FullName, "דירה", product.City.Name, product.Adress + " " + product.StreetNo + " מספר דירה:" + product.AptNo, Convert.ToString(product.Size) });
            }
            listViewProducts.Items.Add(listViewItem);


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
