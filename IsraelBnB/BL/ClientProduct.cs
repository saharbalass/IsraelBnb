using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSahar.DAL;
using System.Data;
using ProductSahar.DAL;

namespace ClientSahar.BL
{
    public class ClientProduct
    {
        private int m_id;
        public int Id { get => m_id; set => m_id = value; }

        private Product m_Product;
        public Product Product { get => m_Product; set => m_Product = value; }

        private Client m_Client;
        public Client Client { get => m_Client; set => m_Client = value; }

        private int m_Intrest;
        public int Intrest { get => m_Intrest; set => m_Intrest = value; }

        private DateTime m_DateIntrestedSince;
        public DateTime DateIntrestedSince { get => m_DateIntrestedSince; set => m_DateIntrestedSince = value; }

        private int m_IsIntrested;
        public int ISIntrested { get => m_IsIntrested; set => m_IsIntrested = value; }

        public bool Insert()
        {
            return ClientProduct_Dal.Insert(m_Product.ID, m_Client.ID, m_Intrest, m_DateIntrestedSince, m_IsIntrested);
        }

        public ClientProduct() { }

        public ClientProduct(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח
            this.m_Product = new Product(dataRow.GetParentRow("ClientProductProduct"));
            this.m_Client = new Client(dataRow.GetParentRow("ClientProductClient"));
            this.m_Intrest = (int)dataRow["Intrest"];
            this.m_DateIntrestedSince = (DateTime)dataRow["DateIntrestedSince"];
            this.m_IsIntrested = (int)dataRow["IsIntrested"];
        }
        public bool Update()
        {
            return ClientProduct_Dal.Update(m_id,m_Product.ID, m_Client.ID, m_Intrest, m_DateIntrestedSince, m_IsIntrested);

        }
        public bool Delete()
        {
            return ClientProduct_Dal.Delete(m_id);
        }
    }

}

