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

namespace IsraelBnB.UI
{
    public partial class FormPersenolProperty : Form
    {
        public FormPersenolProperty(Client client)
        {
            InitializeComponent();
            InitializeListView(client);
        }

        public void InitializeListView(Client client)
        {
            ProductArr productArr = new ProductArr();
            productArr.Fill();

            ProductArr productArrToReturn = new ProductArr();
            Product product;
            ListViewItem listViewItem;

            for (int i = 0; i < productArr.Count; i++)
            {
                product = productArr[i] as Product;

                if (product.Client == client.ID)
                {
                    productArrToReturn.Add(product);
                }
            }

            for (int i = 0; i < productArrToReturn.Count; i++)
            {
                product = productArrToReturn[i] as Product;
                if ((productArrToReturn[i] as Product).Catagory.ID == 1)
                {
                    listViewItem = new ListViewItem(new[] { "בתים", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor) });
                    listViewProducts.Items.Add(listViewItem);
                }
                else
                {
                    listViewItem = new ListViewItem(new[] { "דירות", product.City.Name, product.Adress + " " + product.StreetNo, product.Descreption, Convert.ToString(product.Size), Convert.ToString(product.Floor) });
                    listViewProducts.Items.Add(listViewItem);
                }
            }
        }
    }
}
