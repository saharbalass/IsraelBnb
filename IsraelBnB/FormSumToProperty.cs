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
        public FormSumToProperty(House house,Apartment apartment)
        {
            InitializeComponent();
            if (house != null)
            {
                InitializeListViewForHouse(house);
            }
            if (apartment != null)
            {
                InitializeListViewForApartment(apartment);
            }
        }

        private void InitializeListViewForHouse(House house)
        {
            ListViewItem listViewItem;
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewItem = new ListViewItem(new[] { "בתים", house.City.Name, house.Adress + " " + house.StreetNo, house.Descreption,Convert.ToString(house.Size),Convert.ToString(house.Floors)});
            //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
            listViewProducts.Columns[5].Text = "מספר קומות";
            listViewProducts.Items.Add(listViewItem);

            pictureBox2.ImageLocation = house.Picture1;
            pictureBox3.ImageLocation = house.Picture2;
            pictureBox4.ImageLocation = house.Picture3;
        }

        private void InitializeListViewForApartment(Apartment apartment)
        {
            ListViewItem listViewItem;
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewItem = new ListViewItem(new[] { "דירות", apartment.City.Name, apartment.Adress + " " + apartment.StreetNo, apartment.Descreption, Convert.ToString(apartment.Size), Convert.ToString(apartment.Floor) });
            //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
            listViewProducts.Columns[5].Text = "מספר קומה";
            listViewProducts.Items.Add(listViewItem);

            pictureBox2.ImageLocation = apartment.Picture1;
            pictureBox3.ImageLocation = apartment.Picture2;
            pictureBox4.ImageLocation = apartment.Picture3;
        }
    }
}
