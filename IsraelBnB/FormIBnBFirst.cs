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
using System.IO;

namespace IsraelBnB
{
    public partial class FormIBnBFirst : Form
    {
        public FormIBnBFirst()
        {
            InitializeComponent();
            CityArrToForm(null, comboBox_City);
            CityArrToForm(null, comboBoxCityToRent);
            CatagoryArrToForm(null, comboBoxCatagoryToRent, true);
            UploadPictures();
        }

        const string DEFAULT_PIC = "DefaultPic.png";
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //tabPageSignUp for signing up a Client
        bool IsValidEmail(string email)
        {
            //Defines a var (non specefic class), checks if a valid mail from the class MailAddress (System.FormatException:
            //     address is not in a recognized format.-or- address contains non-ASCII characters.)
            //if valid return true else return false
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckWantToRent()
        {
            //ClientArr clientArr = new ClientArr();
            bool flag = true;
            //if (!clientArr.FilterMailAndPassWord(textBoxSignInMail.Text,textBox1.Text))
            //{
            //    mess
            //}
            if ((int)comboBoxCityToRent.SelectedValue == -1)
            {
                flag = false;
                label21.Visible = true;
            }
            else
            {
                label21.Visible = false;
            }
            if (textBoxAdressToRent.Text.Length < 2)
            {
                flag = false;
                label22.Visible = true;
            }
            else
            {
                label22.Visible = false;
            }
            if ((int)comboBoxCatagoryToRent.SelectedValue == -1)
            {
                flag = false;
                label23.Visible = true;
            }
            else
            {
                label23.Visible = false;
            }
            if (richTextBoxDescreptionToRent.Text.Length < 4)
            {
                flag = false;
                label23.Visible = true;
            }
            else
            {
                label24.Visible = false;
            }
            return flag;
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
        private bool CheckForm()
        {

            //מחזירה האם הטופס תקין מבחינת שדות החובה

            bool flag = true;

            //בדיקת שם פרטי

            if (textBox_FirstName.Text.Length < 2)
            {
                flag = false;
                errorFirstNameLabel.Visible = true;
            }
            else
                errorFirstNameLabel.Visible = false;

            //בדיקת שם משפחה

            if (textBox_LastName.Text.Length < 2)
            {
                flag = false;
                errorLastNameLabel.Visible = true;
            }
            else
                errorLastNameLabel.Visible = false;

            //בדיקת מספר סלולרי

            if (textBox_CellPhone.Text.Length != 7)
            {
                flag = false;
                errorPhoneNumLabel.Visible = true;
            }
            else
                errorPhoneNumLabel.Visible = false;

            //בדיקת דואל אלקטרוני

            if (!IsValidEmail(emailTextBox4.Text))
            {
                flag = false;
                errorEmailLabel.Visible = true;
            }
            else
                errorEmailLabel.Visible = false;

            //בדיקת ת"ז

            if (IDtextBox1.Text.Length != 9)
            {
                flag = false;
                errorIDLabel.Visible = true;
            }
            else
                errorIDLabel.Visible = false;
            if (comboBox_CellPhone.Text.Length != 3)
            {
                flag = false;
                errorPhoneNumLabel.Visible = true;
            }
            else
                errorPhoneNumLabel.Visible = false;
            if ((int)comboBox_City.SelectedValue < 1)
            {
                flag = false;
                label8.Visible = true;
                comboBox_City.ForeColor = Color.Red;
            }
            else
                label8.Visible = false;
            if (textBoxPassWordNew.Text.Length < 4)
            {
                flag = false;
                labelPassTrue.Visible = true;
                MessageBox.Show("הסיסמא חייבת להכיל מעל לשלושה תווים", "רישום", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                labelPassTrue.Visible = false;
            return flag;
        }
        private Client FormToClient()
        {
            Client client = new Client();

            client.FirstName = textBox_FirstName.Text;
            client.LastName = textBox_LastName.Text;
            client.PhoneNumber = textBox_CellPhone.Text;
            client.CellPhone_AreaCode = comboBox_CellPhone.Text;
            client.ID_FromClient = IDtextBox1.Text;
            client.Mail = emailTextBox4.Text;
            client.ID = int.Parse(label_Id.Text);
            client.City = (comboBox_City.SelectedItem as City);
            client.PassWord = textBoxPassWordNew.Text;

            return client;
        }

        //Picture realated code
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
        private string GetPicfileName(PictureBox pictureBox)
        {

            //מחזירה את שם הקובץ של התמונה - ללא התיקיה

            int k = pictureBox.ImageLocation.LastIndexOf(@"\") + 1;
            return pictureBox.ImageLocation.Substring(k);
        }
        //מסדר את השמות של התמונות כדי למצוא תמונות לפי ערך
        public void ChangeNameToSeries(Product product)
        {
            product.Picture1 = "A" + product.ID.ToString();
            product.Picture2 = "B" + product.ID.ToString();
            product.Picture3 = "C" + product.ID.ToString();
        }
        private int FindLastIntInName(string name)
        {
            //מציאת המספר שהוא התו האחרון בשם תמונת הקלף

            return int.Parse(name.Substring(name.Length - 1));
        }
        private void Add_Picture_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            //פתיחת תיבת דו-שיח לבחירת קובץ התמונה - לקבצים מסוג תמונה בלבד - והצגת התמונה
            openFileDialog_Picture1.Filter = "תמונות.*) png)|*.png|תמונות.*) jpg)|*.jpg|All files (*.*)|*.*";
            int k = FindLastIntInName(pictureBox.Name);

            if (openFileDialog_Picture1.ShowDialog() == DialogResult.OK)
            {
                switch (k)
                {
                    case 1:
                        pictureBoxAdd1.Visible = false;
                        changePic1.Visible = true;
                        label15.Visible = false;
                        break;
                    case 2:
                        pictureBoxAdd2.Visible = false;
                        changePic2.Visible = true;
                        label16.Visible = false;
                        break;
                    case 3:
                        pictureBoxAdd3.Visible = false;
                        changePic3.Visible = true;
                        label17.Visible = false;
                        break;
                }

            }


            switch (k)
            {
                case 1:
                    pictureBox7.ImageLocation = openFileDialog_Picture1.FileName;
                    break;
                case 2:
                    pictureBox6.ImageLocation = openFileDialog_Picture1.FileName;
                    break;
                case 3:
                    pictureBox5.ImageLocation = openFileDialog_Picture1.FileName;
                    break;
            }
        }
        public bool SaveFile(string fileName, string prevFileName, string filePath)
        {
            //  מעתיק את קובץ התמונה למקום
            // ואם זהו קובץ זהה למקור )עבור עדכון(או קובץ שזהה לברירת המחדל -הקובץ לא יועתק
            if (fileName == DEFAULT_PIC || fileName == prevFileName)
                return true;
            if (!File.Exists(FindPicturePath() + fileName))
                File.Copy(filePath, FindPicturePath() + fileName);
            else
            {

                //התמונה כבר קיימת - נאפשר למשתמש להחליט האם הוא רוצה לבחור תמונה אחרת או להמשיך
                if (MessageBox.Show("File already exist, Do you want to choose another one ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return true;
                else
                    return false;
            }
            return true;
        }

        //buttons and textchange
        private void buttonSaveSignUp_Click(object sender, EventArgs e)
        {
            if (tabHouses.SelectedTab == tabPageSignUp)
            {
                if (!CheckForm())
                {
                    MessageBox.Show("נא מלא את הפרטים החסרים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    Client client = FormToClient();
                    //if (client.Insert())
                    //    MessageBox.Show("Added Successfully");

                    if (client.ID == 0)
                    {
                        //ללקוח יש מזהה אפס – זהו לקוח חדש )טרם נוצרה לו רשומה באקסס ולכן עדיין לא קיבל מספור אוטומטי של המזהה(.
                        //הוספת לקוח חדש

                        if (client.Insert())
                        {
                            MessageBox.Show("הוסף בהצלחה", "הוספת משתמש", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                            MessageBox.Show("בעיה בהוספה", "הוספת משתמש", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    }
                    else
                    {

                        //עדכון לקוח קיים

                        if (client.Update())
                        {
                            MessageBox.Show("עודכן בהצלחה", "עידכון משתמש", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                            MessageBox.Show("בעיה בהוספה", "הוספת משתמש", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
            }
            else if (tabHouses.SelectedTab == tabPageWantToHost)
            {
                if (!CheckWantToRent())
                {
                    MessageBox.Show("נא מלא את הפרטים החסרים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
                else
                {
                    Product product = FormToProduct();
                    if (product.ID == 0)
                    {
                        if (product.Insert())
                        {
                            //העתקת קובץ התמונה - אם לא תקינה הפסקת הפעולה ואי ביצוע השמירה 
                            if (!SaveFile(GetPicfileName(pictureBox5), "", pictureBox5.ImageLocation))
                                return;
                            if (!SaveFile(GetPicfileName(pictureBox6), "", pictureBox6.ImageLocation))
                                return;
                            if (!SaveFile(GetPicfileName(pictureBox7), "", pictureBox7.ImageLocation))
                                return;
                            //לשנות את השם לפי הסידור
                            ChangeNameToSeries(product);
                            MessageBox.Show("הוסף בהצלחה", "הוספת פריט", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                            MessageBox.Show("בעיה בהוספה", "הוספת פריט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        if (product.Update())
                        {
                            //אם העלו תמונה חדשה ושינו את שם הקובץ
                            ChangeNameToSeries(product);
                            MessageBox.Show("עודכן בהצלחה", "עידכון פריט", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                            //כיוון שמדובר על ישוב חדש, ניעזר במזהה הגבוה ביותר = הישוב האחרון שנוסף לטבלה
                            ProductArr productArr = new ProductArr();
                            productArr.Fill();
                            product = productArr.GetproductWithMaxID();
                        }
                        else
                            MessageBox.Show("בעיה בעידכון", "עדכון פריט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
            }

        }



        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageSignUp;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageSignIn;
        }

        private void pictureBoxEnterSignIn_Click(object sender, EventArgs e)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            Client client;
            if (clientArr.FilterMailAndPassWord(textBoxSignInMail.Text, textBox1.Text) && clientArr.FilterMailAndPassWord(textBoxSignInMail.Text, textBox1.Text))
            {
                client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);
                //buttonSaveSignUp.Enabled = false;
                labelWelcome.Visible = true;
                labelWelcome.Text = "ברוך שובך " + client.FirstName;
                buttonSignUp.Visible = false;
                buttonExitLogIn.Visible = true;
                tabHouses.SelectedTab = tabPageApartments;
            }
            else
            {
                MessageBox.Show("מייל או סיסמא שגויים", "כניסת משתמש", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBox1.PasswordChar = char.MinValue;
        }

        private void buttonExitLogIn_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            buttonSaveSignUp.Enabled = true;
            labelWelcome.Text = "";
            buttonExitLogIn.Visible = false;
            buttonSignUp.Visible = true;
        }

        private void buttonWantToHost_Click(object sender, EventArgs e)
        {
            ClientArr clientArr = new ClientArr();
            if (labelWelcome.Visible == false)
            {
                MessageBox.Show("חובה להירשם לפני השכרה", "רישום", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
                tabHouses.SelectedTab = tabPageWantToHost;
        }

        //tab "want to rent"
        private Product FormToProduct()
        {
            Product product = new Product();
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            product.Adress = textBoxAdressToRent.Text;
            product.Catagory = comboBoxCatagoryToRent.SelectedItem as Catagory;
            product.Client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text).ID;
            product.Picture1 = GetPicfileName(pictureBox7);
            product.Picture2 = GetPicfileName(pictureBox6);
            product.Picture3 = GetPicfileName(pictureBox5);
            product.Descreption = richTextBoxDescreptionToRent.Text;
            product.City = comboBoxCityToRent.SelectedItem as City;

            return product;
        }
        //private Product fdsfs()
        //{
        //    Product product = new Product();
        //    ClientArr clientArr = new ClientArr();
        //    clientArr.Fill();

        //    product.Client = clientArr.ReturnClientWithMail(textBox2.Text).ID;
        //    return product;

        //}
        public void CatagoryArrToForm(Catagory curCatagory, ComboBox comboBox, bool isMustChoose)
        {
            CatagoryArr catagoryArr = new CatagoryArr();

            //הוספת חברת ברירת מחדל - בחר חברה/ כל החברות

            Catagory catagoryDefault = new Catagory();
            catagoryDefault.ID = -1;
            if (isMustChoose)
                catagoryDefault.Name = "בחר קטגוריה";
            else
                catagoryDefault.Name = "כל הקטגוריות";
            catagoryArr.Add(catagoryDefault);
            catagoryArr.Fill();
            comboBox.DataSource = catagoryArr;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";

            //אם נשלח לפעולה טיפוס , הצבתו בתיבת הבחירה של הטיפוס בטופס

            if (curCatagory != null)
                comboBox.SelectedValue = curCatagory.ID;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageApartments;
        }

        //tab apartments
        private void button9_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageApartments;
        }
        private void buttonHouses_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageHouses;
        }

        private void UploadPictures()
        {
            int a = 0;
            int h = 0;
            ProductArr productArr = new ProductArr();
            productArr.Fill();

            PictureBox pictureBox = new PictureBox();
            for (int i = 0; i < 6; i++)
            {
                if ((productArr[a + h] as Product).Catagory.ID == 1)
                {
                    //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
                    pictureBox = NumberToPictureBox(a + 1, (productArr[a + h] as Product).Catagory.ID);
                    productToForm(productArr[a] as Product, pictureBox);
                    a++;
                }
                else
                {
                    //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
                    pictureBox = NumberToPictureBox(h + 1, (productArr[h + a] as Product).Catagory.ID);
                    productToForm(productArr[h + a] as Product, pictureBox);
                    h++;
                } 
            }
            //while (a < 3 && a < productArr.GetNumberOfProducts())
            //{
            //    if ((productArr[a + h] as Product).Catagory.ID == 1)
            //    {
            //        //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
            //        pictureBox = NumberToPictureBox(a + 1, (productArr[a+h] as Product).Catagory.ID);
            //        productToForm(productArr[a] as Product, pictureBox);
            //        a++;

            //    }
            //    else
            //    {
            //        while (h < 3 && h < productArr.GetNumberOfProducts() && (productArr[h + a] as Product).Catagory.ID == 2)
            //        {
            //            //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
            //            pictureBox = NumberToPictureBox(h + 1, (productArr[h+a] as Product).Catagory.ID);
            //            productToForm(productArr[h + a] as Product, pictureBox);
            //            h++;
            //        }

            //    }

            //}
            
        }
        private void productToForm(Product product, PictureBox pictureBox)
        {
            if (product != null)
            {


                ////לבדוק אם צריך


                //אם אין תמונה ליישות, הצגת תמונת ברירת המחדל
                //אם ללקוח יש דירה אז לשים את התמונות בTAB של הדירות
                productToPicture(pictureBox, product);

            }
            else
            {

                //הצגת תמונת ברירת המחדל
                pictureBoxApr1.ImageLocation = FindPicturePath() + @"\" + DEFAULT_PIC;
            }
        }
        private void productToPicture(PictureBox pictureBox, Product product)
        {
            if (product.Picture1 == "")
            {
                pictureBox.ImageLocation = FindPicturePath() + @"\" + DEFAULT_PIC;
            }
            else
                pictureBox.ImageLocation = FindPicturePath() + product.Picture1;
        }

        private PictureBox NumberToPictureBox(int location, int Catagory)
        {

            PictureBox pictureBox = new PictureBox();
            if (Catagory == 2)
            {
                if (int.Parse(pictureBoxApr1.Name.Substring(pictureBoxApr1.Name.Length - 1)) == location)
                {
                    pictureBox = pictureBoxApr1;
                }
                else if (int.Parse(pictureBoxApr2.Name.Substring(pictureBoxApr2.Name.Length - 1)) == location)
                {
                    pictureBox = pictureBoxApr2;
                }
                //אנו יודעים שהוא נפעל רק שלוש פעמים בגלל הלולאה בפנוקצייה פרודקט טו פורם
                else
                    pictureBox = pictureBoxApr3;
            }
             if (Catagory == 1)
            {
                if (int.Parse(pictureBoxHouse1.Name.Substring(pictureBoxHouse1.Name.Length - 1)) == location)
                {
                    pictureBox = pictureBoxHouse1;
                }
                else if (int.Parse(pictureBoxHouse2.Name.Substring(pictureBoxHouse2.Name.Length - 1)) == location)
                {
                    pictureBox = pictureBoxHouse2;
                }
                //אנו יודעים שהוא נפעל רק שלוש פעמים בגלל הלולאה בפנוקצייה פרודקט טו פורם
                else
                    pictureBox = pictureBoxHouse3;

            }

            return pictureBox;

        }
        //בגלל שפעולת ה"מלא" משנה את הסדר בפרודקט, נסה לשלוח לתכונה הריקה את הזהות של אותו פרודקט.
        private void pictureBoxApr_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            ClientArr clientArr = new ClientArr();
            Client client = new Client();
            ProductArr productArr = new ProductArr();

            productArr.Fill();
            clientArr.Fill();

            client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);


            int k = FindLastIntInName(((PictureBox)sender).Name);
            //k-1 בגלל שהמערך מתחיל ב0 ואילו המספר של הפיקטר בוקס מתחיל ב1
            product = productArr[k - 1] as Product;
            if (labelWelcome.Visible == false)
            {
                MessageBox.Show("חובה להירשם לפני השכרה", "רישום", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                //שולח את הנכס ואת הלקוח שרוצה להשכיר
                FormToRent formToRent = new FormToRent(client, product);
                formToRent.ShowDialog();
            }

        }

        private void buttonAddCity_Click_1(object sender, EventArgs e)
        {
            FormAddCity formAddCity = new FormAddCity();

            formAddCity.ShowDialog();
        }

        private void changePic1_Click(object sender, EventArgs e)
        {
            Add_Picture_Click(pictureBoxAdd1, null);
        }

        private void changePic2_Click(object sender, EventArgs e)
        {
            Add_Picture_Click(pictureBoxAdd2, null);
        }

        private void changePic3_Click(object sender, EventArgs e)
        {
            Add_Picture_Click(pictureBoxAdd3, null);
        }
    }
}
