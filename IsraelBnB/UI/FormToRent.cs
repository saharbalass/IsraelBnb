﻿using System;
using ClientSahar;
using ClientSahar.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IsraelBnB.UI;

namespace IsraelBnB
{
    public partial class FormToRent : Form
    {
        public FormToRent(Client client, Product product)
        {
            InitializeComponent();
            CurrentProductToForm(client, product);
            InitializeClientProduct();
        }

        private void FormToRent_Load(object sender, EventArgs e)
        {

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
        private void InitializeClientProduct()
        {
            ClientProductArr clientProductArr = new ClientProductArr();
            clientProductArr.Fill();
            Client client = GetClientFromForm();
            Product product = GetProductFromForm();
            ClientProduct clientProductForId = clientProductArr.FindClientProduct(client, product);

            if (clientProductForId.Id != 0)
            {
                labelClientProductID.Text = Convert.ToString(clientProductForId.Id);
            }
            else
            {
                labelClientProductID.Text = "0";
            }

        }
        private void CurrentProductToForm(Client clientWantToBuy, Product product)
        {
            Client client = new Client();
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            pictureBoxProperty0.ImageLocation = FindPicturePath() + product.Picture1;
            pictureBoxProperty1.ImageLocation = FindPicturePath() + product.Picture1;
            pictureBoxProperty2.ImageLocation = FindPicturePath() + product.Picture2;
            pictureBoxProperty3.ImageLocation = FindPicturePath() + product.Picture3;

            if (product.Catagory.ID == 1)
            {
                richTextBox2.Text = product.Adress + " מספר רחוב:" + Convert.ToInt32(product.StreetNo) + " מספר קומות:" + Convert.ToInt32(product.Floor);
            }
            else
            {
                richTextBox2.Text = product.Adress + " מספר רחוב:" + Convert.ToString(product.StreetNo) + " מספר קומה:" + Convert.ToString(product.Floor + " מספר דירה:" + Convert.ToString(product.AptNo));
            }
            if (product.IsSold == 1)
            {
                buttonWantToBuy.Visible = false;
            }
            else
            {
                buttonWantToBuy.Visible = true;
            }
            labelCity.Text = product.City.Name;
            richTextBox1.Text = product.Descreption;
            labelProductID.Text = Convert.ToString(product.ID);
            labelClientID.Text = Convert.ToString(clientWantToBuy.ID);
            labelSize.Text = " מ''ר " + Convert.ToString(product.Size);
            labelPrice.Text = Convert.ToString(product.Price);

            client = clientArr.ReturnClientWithID(product.Client);
            labelCleintEmail.Text = client.Mail;
            labelCleintName.Text = client.FirstName + " " + client.LastName;
            labelCleintPhone.Text = client.CellPhone_AreaCode + client.PhoneNumber;

            labelCatagory.Text = Convert.ToString(product.Catagory.ID);

        }


        private void Forword1_Click(object sender, EventArgs e)
        {
            //אם מקבל את הפקודה מכפתור קדימה אז...
            if ((sender as Button).Name == Forword1.Name)
            {
                //אם התמונה הגדולה שווה לתמונה הראשונה אז שים את התמונה השנייה 
                if (IsSamePicture(pictureBoxProperty0, pictureBoxProperty1))
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty2.ImageLocation;
                }
                // אם התמונה הגדולה שווה לתמונה השנייה שים את השלישית
                else if (IsSamePicture(pictureBoxProperty0, pictureBoxProperty2))
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty3.ImageLocation;
                }
                // אם זו השלישית אז שים את הראשונה 
                else
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty1.ImageLocation;
                }
            }
            // אותו דבר בסדר הפוך
            else if ((sender as Button).Name == backWords2.Name)
            {
                if (IsSamePicture(pictureBoxProperty0, pictureBoxProperty1))
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty3.ImageLocation;
                }
                else if (IsSamePicture(pictureBoxProperty0, pictureBoxProperty2))
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty1.ImageLocation;
                }
                else
                {
                    pictureBoxProperty0.ImageLocation = pictureBoxProperty2.ImageLocation;
                }
            }
        }

        private bool IsSamePicture(PictureBox pic1, PictureBox pic2)
        {
            return (pic1.ImageLocation == pic2.ImageLocation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show("האם אתה בטוח רוצה לקנות את הנכס?", "מכירת נכס", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            if (result == DialogResult.Yes)
            {
                Client client = GetClientFromForm();

                Product product = GetProductFromForm();
                product.IsSold = 1;
                if (product.Update())
                {
                    MessageBox.Show("עודכן בהצלחה", "עידכון משתמש", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

                    FormAgreement formAgreement = new FormAgreement(client, product);
                    formAgreement.ShowDialog();
                }
                else
                    MessageBox.Show("בעיה בעידכון", "עידכון פרטים", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
              
            }
        }
        //because To open the formAgreement i needed the product from current form, but the function is a button type so i needed to do another function to get current product.(threw the Id Label)
        private Product GetProductFromForm()
        {
            ProductArr productArr = new ProductArr();
            productArr.Fill();

            Product product = new Product();

            for (int i = 0; i < productArr.Count; i++)
            {
                if ((productArr[i] as Product).ID == Convert.ToInt32(labelProductID.Text))
                {
                    product = productArr[i] as Product;
                }
            }
            return product;
        }

        private Client GetClientFromForm()
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client = new Client();

            for (int i = 0; i < clientArr.Count; i++)
            {
                if ((clientArr[i] as Client).ID == Convert.ToInt32(labelClientID.Text))
                {
                    client = clientArr[i] as Client;
                }
            }
            return client;

        }

        private void pictureBoxProperty1_Click(object sender, EventArgs e)
        {
            pictureBoxProperty0.ImageLocation = pictureBoxProperty1.ImageLocation;
        }

        private void pictureBoxProperty2_Click(object sender, EventArgs e)
        {
            pictureBoxProperty0.ImageLocation = pictureBoxProperty2.ImageLocation;
        }

        private void pictureBoxProperty3_Click(object sender, EventArgs e)
        {
            pictureBoxProperty0.ImageLocation = pictureBoxProperty3.ImageLocation;
        }
        private ClientProduct FormtoClientProduct()
        {
            ClientProduct clientProduct = new ClientProduct();
            clientProduct.Id = Convert.ToInt32(labelClientProductID.Text);
            clientProduct.Client = GetClientFromForm();
            clientProduct.Product = GetProductFromForm();
            clientProduct.DateIntrestedSince = DateTime.Now;

            return clientProduct;
        }
        private void label5_Click(object sender, EventArgs e)
        {
            FormIntrestInProperty formDialog = new FormIntrestInProperty();

            ClientProductArr clientProductArr = new ClientProductArr();
            clientProductArr.Fill();
            ClientProduct clientProduct = new ClientProduct();

            //פותח את הדיאלוג ואז בודק האם סגר אותו
            if (formDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                clientProduct = FormtoClientProduct();
                clientProduct.Intrest = formDialog.intrest;

                if (Convert.ToInt32(labelClientProductID.Text) == 0)
                {
                    if (clientProduct.Intrest == 0)
                    {
                        clientProduct.ISIntrested = 0;
                    }
                    else
                    {
                        clientProduct.ISIntrested = 1;
                    }
                    if (clientProduct.Insert())
                    {
                        MessageBox.Show("הוסף בהצלחה", "הוספת עידוכן", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        MessageBox.Show("בעיה בהוספה", "הוספת עידכון", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }

                }
                else
                {

                    //עדכון לקוח קיים
                    if (clientProduct.Update())
                    {
                        MessageBox.Show("עודכן בהצלחה", "עידכון משתמש", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                    else
                        MessageBox.Show("בעיה בעידכון", "עידכון פרטים", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }
    }
}
