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
    public partial class FormAddCity : Form
    {
        public FormAddCity()
        {
            InitializeComponent();
            CityArrToForm(null);
        }

        private void CityArrToForm(City curCity)
        {
            //ממירה את הטנ "מ אוסף לקוחות לטופס
            CityArr citytArr = new CityArr();
            citytArr.Fill();

            listBoxCity.DataSource = citytArr;

            listBoxCity.ValueMember = "Id";
            listBoxCity.DisplayMember = "Name";

            //אם נשלח לפעולה ישוב ,הצבתו בתיבת הבחירה של ישובים בטופס

            if (curCity != null)
                listBoxCity.SelectedValue = curCity.ID;
        }
        private City FormToCity()
        {
            City city = new City();

            city.Name = textBox_Name_City.Text;
            city.ID = int.Parse(Label_City_ID.Text);

            return city;
        }

        private void CityToFrom(City city)
        {

            //ממירה את המידע בטנ"מ לקוח לטופס
            if (city != null)
            {
                Label_City_ID.Text = city.ID.ToString();
                textBox_Name_City.Text = city.Name;
            }
            else
            {
                Label_City_ID.Text = "0";
                textBox_Name_City.Text = "";
            }
        }

        public City SelectedCity
        {
            get { return (listBoxCity.SelectedItem as City); }
        }

        private void listBox_Client_DoubleClick(object sender, EventArgs e)
        {
            CityToFrom(listBoxCity.SelectedItem as City);
        }

        private bool CheckForm()
        {

            //מחזירה האם הטופס תקין מבחינת שדות החובה

            bool flag = true;

            //בדיקת שם העיר

            if (textBox_Name_City.Text.Length < 2)
            {
                flag = false;
                errorCityNameLabel.Visible = true;
            }
            else
                errorCityNameLabel.Visible = false;

            return flag;
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            CityToFrom(null);
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            //Client client = new Client();

            if (!CheckForm())
            {
                MessageBox.Show("נא מלא את הפרטים החסרים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                City city = FormToCity();
                if (city.ID == 0)
                {
                    //ללקוח יש מזהה אפס – זהו לקוח חדש )טרם נוצרה לו רשומה באקסס ולכן עדיין לא קיבל מספור אוטומטי של המזהה(.
                    //הוספת לקוח חדש

                    if (city.Insert())
                    {
                        MessageBox.Show("הוסף בהצלחה", "הוספת עיר", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                        MessageBox.Show("שגיאה בהוספה", "הוספת עיר", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {

                    //עדכון לקוח קיים

                    if (city.Update())
                    {
                        MessageBox.Show("עודכן בהצלחה", "עידכון עיר", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //כיוון שמדובר על ישוב חדש, ניעזר במזהה הגבוה ביותר = הישוב האחרון שנוסף לטבלה
                        CityArr cityArr = new CityArr();
                        cityArr.Fill();
                        city = cityArr.GetCityWithMaxId();

                    }
                    else
                        MessageBox.Show("שגיאה בהוספה", "עידכון עיר", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CityArrToForm(null);

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            City city = FormToCity();
            if (city.ID <= 0)
                MessageBox.Show("חובה לבחור עיר", "אין בחירה", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (MessageBox.Show("אזהרה", "האם אתה בטוח שאתה רוצה למחוק את העיר?", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign |
                MessageBoxOptions.RtlReading) == DialogResult.Yes)
                {

                    //לפני המחיקה - בדיקה שהישוב לא בשימוש בישויות אחרות
                    //בדיקה עבור לקוחות

                    ClientArr clientArr = new ClientArr();
                    clientArr.Fill();
                    ApartmentArr apartmentArr = new ApartmentArr();
                    apartmentArr.Fill();
                    HouseArr houseArr = new HouseArr();
                    houseArr.Fill();
                    if (clientArr.DoesExist(city) || apartmentArr.DoesExist(city) || houseArr.DoesExist(city))
                        MessageBox.Show("אי אפשר למחוק עיר שקשורה ליישות קיימת", "יש חיבור בין יישות לעיר", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    if (city.Delete())
                    {
                        MessageBox.Show("נמחק", "נמחק", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        CityToFrom(null);
                        CityArrToForm(null);
                    }
                    else
                        MessageBox.Show("שגיאה");
                }
            }
        }
    }
}
