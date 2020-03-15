using System;
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

namespace IsraelBnB
{
    public partial class FormToRent : Form
    {
        public FormToRent(Client client, Product product)
        {
            InitializeComponent();
            CurrentProductToForm(client, product);
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
        private void CurrentProductToForm(Client clientWantToBuy, Product product)
        {
            Client client = new Client();

            pictureBoxProperty0.ImageLocation = FindPicturePath() + product.Picture1;
            pictureBoxProperty1.ImageLocation = FindPicturePath() + product.Picture1;
            pictureBoxProperty2.ImageLocation = FindPicturePath() + product.Picture2;
            pictureBoxProperty3.ImageLocation = FindPicturePath() + product.Picture3;

            label1.Text = "כתובת:" + " " + product.Adress;
            // labelAdress.Text = product.Adress;
            labelCity.Text = product.City.Name;
            // label2.Text = "תיאור:" + " " + product.Descreption;
            richTextBox1.Text = product.Descreption;
            labelProductID.Text = Convert.ToString(product.ID);
            labelClientID.Text = Convert.ToString(clientWantToBuy.ID);

            client = ReturnClientThrewID(product.Client);
            labelCleintEmail.Text = client.Mail;
            labelCleintName.Text = client.FirstName + " " + client.LastName;
            labelCleintPhone.Text = client.CellPhone_AreaCode + client.PhoneNumber;

        }

        private Client ReturnClientThrewID(int id)
        {
            ClientArr clientArr = new ClientArr();
            clientArr.Fill();

            Client client = new Client();

            client = clientArr.ReturnClientWithID(id);

            return client;
        }

        void removeBG(PictureBox pb, PictureBox pb2)
        {
            var pos = this.PointToScreen(pb2.Location);
            pos = pb.PointToClient(pos);
            pb2.Parent = pb;
            pb2.Location = pos;
            pb2.BackColor = Color.Transparent;
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
            Product product = new Product();
            product = GetProductFromForm();
            Client client = new Client();
            client = GetClientFromForm();
            FormAgreement formAgreement = new FormAgreement(client,product);

            formAgreement.ShowDialog();
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
    }
}
