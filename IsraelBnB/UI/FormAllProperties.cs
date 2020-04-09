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
            CityArrToForm(null, comboBox_FilterCity);

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
            if (isHouse && listViewProducts.Columns[4].Text == "נכסים")
            {
                listViewProducts.Columns.RemoveAt(4);
                listViewProducts.Columns.Add("בתים");
            }
            else if(!isHouse && listViewProducts.Columns[4].Text == "נכסים")
            {
                listViewProducts.Columns.RemoveAt(4);
                listViewProducts.Columns.Add("דירות");
            }

        }
        public void CityArrToForm(City curCity, ComboBox comobox)
        {

            //ממירה את הטנ "מ אוסף ישובים לטופס

            CityArr cityArr = new CityArr();

            //הוספת ישוב ברירת מחדל - בחר ישוב
            //יצירת מופע חדש של ישוב עם מזהה מינוס 1 ושם מתאים

            City cityDefault = new City();
            cityDefault.ID = -1;
            cityDefault.Name = "בחר עיר";

            //הוספת הישוב לאוסף הישובים - אותו נציב במקור הנתונים של תיבת הבחירה
            cityArr.Add(cityDefault);

            cityArr.Fill();

            comobox.DataSource = cityArr;
            comobox.ValueMember = "Id";
            comobox.DisplayMember = "Name";

            if (curCity != null)
                comobox.SelectedValue = curCity.ID;
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
        private bool CheckFilter()
        {
            bool flag = true;
            if (textBox_FilterName.Text.Length < 1)
            {
                flag = false;
                label47.Visible = true;
            }
            else
            {
                label47.Visible = false;
            }
            if (Convert.ToInt32(textBoxPriceFrom.Text) != 0 && textBoxPriceFrom.Text.Length < 6)
            {
                flag = false;
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
            if (Convert.ToInt32(textBoxPriceTill.Text) != 0 && textBoxPriceTill.Text.Length < 6)
            {
                flag = false;
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
            return flag;
        }
        private void buttonFillter_Click(object sender, EventArgs e)
        {
            if (!CheckFilter())
            {
                MessageBox.Show("פרטים לא תקינים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
               
                ProductArr productArr = new ProductArr();
                productArr.Fill();
                Product product = new Product();

                if (GetIsHouses())
                {
                    productArr = productArr.Filter(textBox_FilterName.Text, 1, Convert.ToInt32(textBoxPriceFrom.Text), Convert.ToInt32(textBoxPriceTill.Text));
                    listViewProducts.Items.Clear();
                    FillListViewForFilter(productArr, true);
                    if (listViewProducts.Items.Count < 1)
                    {
                        MessageBox.Show("אין בית מתאים", "סינון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        FilllistViewProducts(GetIsHouses());
                    }
                }
                else
                {
                    productArr = productArr.Filter(textBox_FilterName.Text, 2, Convert.ToInt32(textBoxPriceFrom.Text), Convert.ToInt32(textBoxPriceTill.Text));
                    listViewProducts.Items.Clear();
                    FillListViewForFilter(productArr, false);
                    if (listViewProducts.Items.Count < 1)
                    {
                        MessageBox.Show("אין דירה מתאימה", "סינון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        FilllistViewProducts(GetIsHouses());
                    }
                }

              


            }

        }
        private void FillListViewForFilter(ProductArr productArr, bool isHouse)
        {
            ListViewItem listViewItem = new ListViewItem();
            Product product = new Product();
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
            if (isHouse && listViewProducts.Columns[4].Text == "נכסים")
            {
                listViewProducts.Columns.RemoveAt(4);
                listViewProducts.Columns.Add("בתים");
            }
            else if(!isHouse && listViewProducts.Columns[4].Text == "נכסים")
            {
                listViewProducts.Columns.RemoveAt(4);
                listViewProducts.Columns.Add("דירות");
            }
        }

        private bool GetIsHouses()
        {
            return listViewProducts.Columns[4].Text == "בתים";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewProducts.Items.Clear();
            FilllistViewProducts(GetIsHouses());
        }
    }
}

