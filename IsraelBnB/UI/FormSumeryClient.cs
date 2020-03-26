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
    public partial class FormSumeryClient : Form
    {
        Bitmap m_bitmap;
        public FormSumeryClient(Client client)
        {
            InitializeComponent();
            InitializeListViewForClient(client);
        }

        private void InitializeListViewForClient(Client client)
        {
            ListViewItem listViewItem;
            //הוספת פריט-תיבת-תצוגה לתיבת תצוגה
            listViewItem = new ListViewItem(new[] {client.FirstName,client.LastName,client.CellPhone_AreaCode + client.PhoneNumber,client.Mail,client.PassWord,client.ID_Number,client.City.Name });
            listViewProducts.Items.Add(listViewItem);

        }


    }
}
