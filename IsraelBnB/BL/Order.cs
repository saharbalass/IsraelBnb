using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSahar.DAL;
using System.Data;

namespace ClientSahar.BL
{
    public class Order
    {

        private Client m_Client;
        public Client Client { get => m_Client; set => m_Client = value; }

        private DateTime m_Date;
        public DateTime Date { get => m_Date; set => m_Date = value; }

        private string m_Note;
        public string Note { get => m_Note; set => m_Note = value; }

        private int m_ID;

        public int ID { get => m_ID; set => m_ID = value; }
        public bool Insert()
        {
            return Order_Dal.Insert(m_Client.ID,m_Date,m_Note);
        }

        public Order() { }

        public Order(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח

            this.m_Date = (DateTime)dataRow["Date"];
            this.m_Note = dataRow["Note"].ToString();
            //what to do here?
            this.m_Client = new Client(dataRow.GetParentRow("OrderClient"));
            this.ID = (int)dataRow["ID"];
        }

        public override string ToString()
        {
            return m_Date + " "+ m_Client.FirstName + " " + m_Client.LastName;
        }

        public bool Update()
        {
            return Order_Dal.Update(m_Client.ID,m_Date,m_Note,m_ID);

        }
        public bool Delete()
        {
            return Order_Dal.Delete(ID);
        }

    }

}
