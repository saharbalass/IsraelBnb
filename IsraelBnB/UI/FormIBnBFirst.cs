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
using System.Windows.Forms.DataVisualization.Charting;
using IsraelBnB.UI;

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
            CatagoryArrToForm(null, comboBoxSearch, true);
            UploadPictures();
            InizializeChartPropertyCity();
            InizializeChartIntrestForTime();
            InizializeChartSales();
        }

        const string DEFAULT_PIC = "DefaultPic.jfif";
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
        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.KeyChar = char.MinValue;
            }
        }
        public bool CheckWantToRent()
        {
            bool flag = true;

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
                label24.Visible = true;
            }
            else
            {
                label24.Visible = false;
            }
            //אם נבחר קטגוריית דירות
            if ((int)comboBoxCatagoryToRent.SelectedValue == 2)
            {
                if (textBoxAprtNo.Text.Length < 1)
                {
                    flag = false;
                    label29.Visible = true;
                }
                else
                {
                    label29.Visible = false;
                }
            }
            if (textBoxSize.Text.Length < 2)
            {
                flag = false;
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }
            if (textBoxFloor.Text.Length < 1)
            {
                flag = false;
                label31.Visible = true;
            }
            else
            {
                label31.Visible = false;
            }
            if (richTextBoxDescreptionToRent.Text.Length < 5)
            {
                flag = false;
                label24.Visible = true;
            }
            else
            {
                label24.Visible = false;
            }
            if ((int)comboBoxCatagoryToRent.SelectedValue == 2)
            {
                if (textBoxAprtNo.Text.Length < 1)
                {
                    flag = false;
                    label29.Visible = true;
                }
                else
                {
                    label29.Visible = false;
                }
            }
            if (textBoxStreetNo.Text.Length < 1)
            {
                flag = false;
                label27.Visible = true;
            }
            else
            {
                label27.Visible = false;
            }
            if (textBoxPrice.Text.Length < 1)
            {
                flag = false;
                label44.Visible = true;
            }
            else
            {
                label44.Visible = false;
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
        private bool CheckFormForClient()
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
            {
                label8.Visible = false;
                comboBox_City.ForeColor = Color.White;
            }
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
            client.ID_Number = IDtextBox1.Text;
            client.Mail = emailTextBox4.Text;
            client.ID = int.Parse(labelIDClient.Text);
            client.City = (comboBox_City.SelectedItem as City);
            client.PassWord = textBoxPassWordNew.Text;

            return client;
        }

        private void ClientToForm(Client client)
        {
            labelIDClient.Text = Convert.ToString(client.ID);
            textBox_FirstName.Text = client.FirstName;
            textBox_LastName.Text = client.LastName;
            comboBox_CellPhone.Text = client.CellPhone_AreaCode;
            textBox_CellPhone.Text = client.PhoneNumber;
            emailTextBox4.Text = client.Mail;
            textBoxPassWordNew.Text = client.PassWord;
            IDtextBox1.Text = client.ID_Number;
            comboBox_City.SelectedValue = client.City.ID;
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
                if (!CheckFormForClient())
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
                            tabHouses.SelectedTab = tabPageSignIn;
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
                            MessageBox.Show("הוסף בהצלחה", "הוספת פריט", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        }
                        else
                            MessageBox.Show("בעיה בהוספה", "הוספת פריט", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        if (product.Update())
                        {
                            //העתקת קובץ התמונה - אם לא תקינה הפסקת הפעולה ואי ביצוע השמירה 
                            if (!SaveFile(GetPicfileName(pictureBox5), "", pictureBox5.ImageLocation))
                                return;
                            if (!SaveFile(GetPicfileName(pictureBox6), "", pictureBox6.ImageLocation))
                                return;
                            if (!SaveFile(GetPicfileName(pictureBox7), "", pictureBox7.ImageLocation))
                                return;
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
            if (clientArr.FilterMailAndPassWord(textBoxSignInMail.Text, textBoxPassWord.Text) && clientArr.FilterMailAndPassWord(textBoxSignInMail.Text, textBoxPassWord.Text))
            {
                client = GetClientFromForm();
                //buttonSaveSignUp.Enabled = false;
                labelWelcome.Visible = true;
                labelWelcome.Text = "ברוך שובך " + client.FirstName;
                buttonSignUp.Visible = false;
                buttonExitLogIn.Visible = true;
                tabHouses.SelectedTab = tabPageApartments;
                buttonUpdate.Visible = true;
                buttonSignIn.Visible = false;
                buttonUpdatePersenol.Visible = true;
                label2.Visible = true;
                buttonCharts.Visible = true;
            }
            else
            {
                MessageBox.Show("מייל או סיסמא שגויים", "כניסת משתמש", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBoxPassWord.PasswordChar = '*';
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBoxPassWord.PasswordChar = char.MinValue;
        }

        private void buttonExitLogIn_Click(object sender, EventArgs e)
        {
            LogOut();
            ResetTabToRent();
        }

        private void ResetTabToRent()
        {
            comboBoxCatagoryToRent.SelectedValue = -1;
            comboBoxCityToRent.SelectedValue = -1;
            textBoxAdressToRent.Text = "";
            textBoxStreetNo.Text = "";
            textBoxAprtNo.Text = "";
            richTextBoxDescreptionToRent.Text = "";
            textBoxSize.Text = "";
            textBoxFloor.Text = "";
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox5.ImageLocation = "";
            pictureBox6.ImageLocation = "";
            pictureBox7.ImageLocation = "";
            pictureBoxAdd1.Visible = true;
            pictureBoxAdd2.Visible = true;
            pictureBoxAdd3.Visible = true;
        }

        private void LogOut()
        {
            tabHouses.SelectedTab = tabPageSignIn;
            buttonSaveSignUp.Enabled = true;
            labelWelcome.Text = "";
            buttonExitLogIn.Visible = false;
            buttonSignUp.Visible = true;
            buttonUpdate.Visible = false;
            buttonSignIn.Visible = true;
            buttonUpdatePersenol.Visible = false;
            label2.Visible = false;
            buttonCharts.Visible = true;
            buttonCharts.Visible = false;
            ResetTabToRent();
        }

        private void buttonWantToHost_Click(object sender, EventArgs e)
        {
            ClientArr clientArr = new ClientArr();
            if (labelWelcome.Visible == false || labelWelcome.Text == "")
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

            product.DateFrom = DateTime.Now;

            product.ID = Convert.ToInt32(label39.Text);
            product.Adress = textBoxAdressToRent.Text;
            product.Catagory = comboBoxCatagoryToRent.SelectedItem as Catagory;
            product.Client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text).ID;
            product.Picture1 = GetPicfileName(pictureBox7);
            product.Picture2 = GetPicfileName(pictureBox6);
            product.Picture3 = GetPicfileName(pictureBox5);
            product.Descreption = richTextBoxDescreptionToRent.Text;
            product.City = comboBoxCityToRent.SelectedItem as City;
            product.StreetNo = Convert.ToInt32(textBoxStreetNo.Text);
            //בגלל שמדובר בבית אז אין מספר דירה
            if ((int)comboBoxCatagoryToRent.SelectedValue == 1)
            {
                product.AptNo = 0;
            }
            else
            {
                product.AptNo = Convert.ToInt32(textBoxAprtNo.Text);
            }
            product.Price = Convert.ToInt32(textBoxPrice.Text);
            product.Size = Convert.ToInt32(textBoxSize.Text);
            product.Floor = Convert.ToInt32(textBoxFloor.Text);
            product.IsSold = Convert.ToInt32(labelIsSold.Text);
            return product;
        }

        public void CatagoryArrToForm(Catagory curCatagory, ComboBox comboBox, bool isMustChoose)
        {
            //כדי להבדיל באיזו קטגוריה מדובר להשכרה
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
            tabHouses.SelectedTab = tabPageSearch;
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
            //יש את המשתנים בגלל שאיי משתנה לא ביחס לנכס אלא ללולאה
            int a = 1; // for apartments
            int h = 1; //for houses
            ProductArr productArr = new ProductArr();
            productArr.Fill();
            //he
            PictureBox pictureBox = new PictureBox();
            for (int i = 0; i < productArr.Count; i++)
            {
                if ((productArr[i] as Product).IsSold == 0)
                {
                    if ((productArr[i] as Product).Catagory.ID == 1)
                    {
                        //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
                        pictureBox = NumberToPictureBox(h, (productArr[i] as Product).Catagory.ID);
                        ProductToFormPictureOnly(productArr[i] as Product, pictureBox);
                        h++;
                    }
                    else if ((productArr[i] as Product).Catagory.ID == 2)
                    {
                        //שם את השם של הפיקטר בוקס בהתאם לקטגוריה
                        pictureBox = NumberToPictureBox(a, (productArr[i] as Product).Catagory.ID);
                        ProductToFormPictureOnly(productArr[i] as Product, pictureBox);
                        a++;
                    }
                }
            }
        }
        private void ProductToForm(Product product)
        {
            textBoxAdressToRent.Text = product.Adress;
            //house.Client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text).ID;
            pictureBox5.ImageLocation = FindPicturePath() + product.Picture1;
            pictureBox6.ImageLocation = FindPicturePath() + product.Picture2;
            pictureBox7.ImageLocation = FindPicturePath() + product.Picture3;
            richTextBoxDescreptionToRent.Text = product.Descreption;
            textBoxStreetNo.Text = Convert.ToString(product.StreetNo);
            textBoxSize.Text = Convert.ToString(product.Size);
            textBoxFloor.Text = Convert.ToString(product.Floor);
            comboBoxCityToRent.SelectedValue = product.City.ID;
            pictureBoxAdd1.Visible = false;
            pictureBoxAdd2.Visible = false;
            pictureBoxAdd3.Visible = false;

            changePic1.Visible = true;
            changePic2.Visible = true;
            changePic3.Visible = true;
            label39.Text = Convert.ToString(product.ID);
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBoxAprtNo.Text = Convert.ToString(product.AptNo);
            labelIsSold.Text = Convert.ToString(product.IsSold);
            textBoxPrice.Text = Convert.ToString(product.Price);
            if (product.Catagory.ID == 1)
            {

                comboBoxCatagoryToRent.SelectedValue = 1;
                label30.Visible = false;
                textBoxAprtNo.Visible = false;
                labelFloor.Text = "מספר קומות";
            }
            else
            {
                comboBoxCatagoryToRent.SelectedValue = 2;
                textBoxAprtNo.Visible = true;
                label30.Visible = true;
            }
        }



        private void ProductToFormPictureOnly(Product product, PictureBox pictureBox)
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
                pictureBoxApr2.ImageLocation = FindPicturePath() + @"\" + DEFAULT_PIC;
                pictureBoxApr3.ImageLocation = FindPicturePath() + @"\" + DEFAULT_PIC;
            }
        }

        private void productToPicture(PictureBox pictureBox, Product product)
        {
            if (product.Picture1 == "")
            {
                pictureBox.ImageLocation = FindPicturePath() + @"\" + DEFAULT_PIC;
            }
            else
            {
                pictureBox.ImageLocation = FindPicturePath() + product.Picture1;
                //הכנסת הזהות של הבית כדי "לקשר" אותו לתמונה
                pictureBox.Tag = product.ID;
            }
        }


        private PictureBox NumberToPictureBox(int location, int catagory)
        {

            PictureBox pictureBox = new PictureBox();
            if (catagory == 1)
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
            else
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
                {
                    pictureBox = pictureBoxApr3;
                }
            }


            return pictureBox;

        }

        private void pictureBoxProperty_Click(object sender, EventArgs e)
        {
            ClientArr clientArr = new ClientArr();
            ProductArr productArr = new ProductArr();

            productArr.Fill();
            clientArr.Fill();

            Client client = GetClientFromForm();

            Product product = productArr.FilterWithID(Convert.ToInt32(((PictureBox)sender).Tag));
            if (labelWelcome.Visible == false || labelWelcome.Text == "")
            {
                MessageBox.Show("חובה להירשם לפני השכרה", "רישום", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else if(product == null)
            {
                MessageBox.Show("אין נכס", "בחירה שגויה", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
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
            CityArrToForm(formAddCity.SelectedCity, comboBox_City);
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

        private void comboBoxCatagoryToRent_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCatagoryToRent.Text == "בתים")
            {
                label29.Visible = false;
                label30.Visible = false;
                textBoxAprtNo.Visible = false;
                labelFloor.Text = "מספר קומות";
            }
            if (comboBoxCatagoryToRent.Text == "דירות")
            {
                label28.Visible = true;
                label30.Visible = true;
                textBoxAprtNo.Visible = true;
                labelFloor.Text = "מספר קומה";
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!CheckFormToSearch())
            {
                MessageBox.Show("נא מלא את הפרטים החסרים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                ProductArr productArr = new ProductArr();
                productArr.Fill();
                //houses


                productArr = productArr.Filter(textBoxSearch.Text, (int)(comboBoxSearch.SelectedValue),Convert.ToInt32(textBoxPriceFrom.Text),Convert.ToInt32(textBoxPriceTill.Text));

                listBoxProperties.DataSource = productArr;
                if (listBoxProperties.Items.Count < 1)
                {
                    if ((int)(comboBoxSearch.SelectedValue) == 1)
                    {
                        MessageBox.Show("אין בית מתאים", "סינון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("אין דירה מתאימה", "סינון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }

                }
            }
        }

        private bool CheckFormToSearch()
        {
            bool flag = true;

            if ((int)comboBoxSearch.SelectedValue < 1)
            {
                flag = false;
                label34.Visible = true;
            }
            else
            {
                label34.Visible = false;
            }
            if (textBoxSearch.Text.Length < 2)
            {
                label35.Visible = true;
                flag = false;
            }
            else
            {
                label35.Visible = false;
            }

            return flag;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageIntro;
        }

        private void labelShowAllHouses_Click(object sender, EventArgs e)
        {
            FormAllProperties formAllProperties = new FormAllProperties(true);
            formAllProperties.ShowDialog();
        }

        private void labelShowAllAparments_Click(object sender, EventArgs e)
        {
            FormAllProperties formAllProperties = new FormAllProperties(false);
            formAllProperties.ShowDialog();
        }

        private void labelDochForRent_Click(object sender, EventArgs e)
        {
            if (!CheckWantToRent())
            {
                MessageBox.Show("נא מלא את הפרטים החסרים", "השלמת פרטים", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                if (Convert.ToInt32(label39.Text) != 0)
                {
                    Product product = FormToProduct();
                    FormSumToProperty formSumToProperty = new FormSumToProperty(product);

                    formSumToProperty.ShowDialog();
                }
                else
                {
                    MessageBox.Show(" חובה לסיים את תהליך הוספת הנכס!ולצאת מהעמוד הנוכחי", "סיום תהליך", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void InitializeUpdateForClient()
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            Client client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);

            ProductArr productArr = new ProductArr();
            productArr = productArr.Filter(client);

            int a = 0; // for apartments
            int h = 0; // for houses;

            if (productArr.Count < 1)
            {
                MessageBox.Show("אין נכסים לעדכן", "עידכון נכס", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
            else
            {
                //שש מקרים בגלל שיש שש מקומות לשים את התמונות של הדירות
                for (int i = 0; i < productArr.Count && i < 5; i++)
                {
                    if ((productArr[i] as Product).Catagory.ID == 1)
                    {
                        switch (h)
                        {
                            case 0:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox8);
                                pictureBox8.Tag = (productArr[i] as Product).ID;
                                break;

                            case 1:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox9);
                                pictureBox9.Tag = (productArr[i] as Product).ID;
                                break;
                            case 2:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox10);
                                pictureBox10.Tag = (productArr[i] as Product).ID;
                                break;
                        }
                        h++;
                    }
                    else
                    {
                        switch (a)
                        {
                            case 0:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox13);
                                pictureBox13.Tag = (productArr[i] as Product).ID;
                                break;

                            case 1:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox12);
                                pictureBox12.Tag = (productArr[i] as Product).ID;
                                break;
                            case 2:
                                ProductToFormPictureOnly(productArr[i] as Product, pictureBox11);
                                pictureBox11.Tag = (productArr[i] as Product).ID;
                                break;
                        }
                        a++;
                    }
                }


                tabHouses.SelectedTab = tabPageUpdateProperty;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            InitializeUpdateForClient();
        }

        private void pictureBoxUpdateProduct(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageWantToHost;

            ProductArr productArr = new ProductArr();
            productArr.Fill();

            Product product = productArr.FilterWithID(Convert.ToInt32((sender as PictureBox).Tag));

            ProductToForm(product);
        }


        private void buttonUpdatePersenol_Click(object sender, EventArgs e)
        {
            tabHouses.SelectedTab = tabPageSignUp;
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            Client client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);
            ClientToForm(client);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();
            Client client = new Client();
            if (Convert.ToInt32(labelIDClient.Text) != 0)
            {
                client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);

                FormSumeryClient formSumeryClient = new FormSumeryClient(client);

                formSumeryClient.ShowDialog();
            }
            else
            {
                MessageBox.Show("חובה להירשם לפני", "רישום", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void listBoxProperties_DoubleClick(object sender, EventArgs e)
        {
            ProductToFormPictureOnly(listBoxProperties.SelectedItem as Product, pictureBoxPropertySearch);
        }

        private void InizializeChartPropertyCity()
        {
            //// פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chartPropertyCitys.Palette = ChartColorPalette.SeaGreen;
            // מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2//
            chartPropertyCitys.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //     כותרת הגרף -1//
            chartPropertyCitys.Titles.Clear();
            chartPropertyCitys.Titles.Add("התפלגות");
            //  הוספת הערכים למשתנה מסוג מילון ממוין//
            ProductArr curProductArr = new ProductArr();
            curProductArr.Fill();
            SortedDictionary<string, int> dictionary = curProductArr.GetSortedDictionary();
            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות ", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Column;
            
            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //   שם - VALX//#
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {
            //     P0{
            //  PERCENT//#
            series.Label = "#VALX [#VAL = #PERCENT{P0}]";
            // הוספת הערכים מתוך משתנה המילון לסדרה//
            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chartPropertyCitys.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chartPropertyCitys.Series.Add(series);
        }

        private void InizializeChartIntrestForTime()
        {
            //// פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chartIntrestForTime.Palette = ChartColorPalette.SeaGreen;
            // מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2//
            chartIntrestForTime.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //     כותרת הגרף -1//
            chartIntrestForTime.Titles.Clear();
            chartIntrestForTime.Titles.Add("התפלגות");
            //  הוספת הערכים למשתנה מסוג מילון ממוין//
            ClientProductArr clientProductArr= new ClientProductArr();
            clientProductArr.Fill();
            SortedDictionary<string, int> dictionary = clientProductArr.GetSortedDictionaryAvrgWaitForIntrest();
           // CityArr clientsCityArr = clientProductArr.GetCityArr();
            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות ", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Column;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //   שם - VALX//#
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {
            //     P0{
            //  PERCENT//#
            series.Label = "#VALX [#VAL = #Days{P0}]";
            // הוספת הערכים מתוך משתנה המילון לסדרה//
            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chartIntrestForTime.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chartIntrestForTime.Series.Add(series);
        }

        private void InizializeChartSales()
        {
            //// פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chartSales.Palette = ChartColorPalette.SeaGreen;
            // מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2//
            chartSales.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //     כותרת הגרף -1//
            chartSales.Titles.Clear();
            chartSales.Titles.Add("התפלגות");
            //  הוספת הערכים למשתנה מסוג מילון ממוין//
            ProductArr productArr= new ProductArr();
            productArr.Fill();
            SortedDictionary<string, int> dictionary = productArr.GetSortedDictionaryForSales();
            // CityArr clientsCityArr = clientProductArr.GetCityArr();
            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות ", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Column;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //   שם - VALX//#
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {
            //     P0{
            //  PERCENT//#
            series.Label = "#VALX [#VAL = #מחירות{P0}]";
            // הוספת הערכים מתוך משתנה המילון לסדרה//
            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chartSales.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chartSales.Series.Add(series);
        }

        private void buttonCharts_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("תוכן הטבלאות ניתנות רק לרשומים, ניתן לחשב מקום מומלץ למכור דירה לפי ערכים אלו!", "מידע ללקוחות", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            tabHouses.SelectedTab = tabPageDochot;
        }

        private void label37_Click(object sender, EventArgs e)
        {
            Client client = GetClientFromForm();
            FormPersenolProperty formPersenolProperty = new FormPersenolProperty(client);
            formPersenolProperty.Show();
        }

        private Client GetClientFromForm()
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client = clientArr.ReturnClientWithMail(textBoxSignInMail.Text);
            return client;
        }

        //item size = close tabs in tabpage
    }
}
