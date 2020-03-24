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

            pictureBox2.ImageLocation = FindPicturePath() + @"\" + house.Picture1;
            pictureBox3.ImageLocation = FindPicturePath() + @"\" + house.Picture2;
            pictureBox4.ImageLocation = FindPicturePath() + @"\" + house.Picture3;

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

        private void InitializeListViewForApartment(Apartment apartment)
        {
            ListViewItem listViewItem;
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewItem = new ListViewItem(new[] { "דירות", apartment.City.Name, apartment.Adress + " " + apartment.StreetNo, apartment.Descreption, Convert.ToString(apartment.Size), Convert.ToString(apartment.Floor) });
            //משנה את הטקסט בהתאם לנכס (אם מדובר בבית את כמה קומות) אם מדובר בדירה באיזו קומה
            listViewProducts.Columns[5].Text = "מספר קומה";
            listViewProducts.Items.Add(listViewItem);

            pictureBox2.ImageLocation = FindPicturePath() + @"\" + apartment.Picture1;
            pictureBox3.ImageLocation = FindPicturePath() + @"\" + apartment.Picture2;
            pictureBox4.ImageLocation = FindPicturePath() + @"\" + apartment.Picture3;
        }
    }
}
