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
    public class House
    {

        #region Memmbers
        private string m_Adress; // שם פרטי
        public string Adress { get => m_Adress; set => m_Adress = value; }

        private int m_ID; //מספר סידורי (לא ת"ז)
        public int ID { get => m_ID; set => m_ID = value; }

        private int m_Client;
        public int Client { get => m_Client; set => m_Client = value; }

        private string m_Picture1;
        public string Picture1 { get => m_Picture1; set => m_Picture1 = value; }

        private string m_Picture2;
        public string Picture2 { get => m_Picture2; set => m_Picture2 = value; }

        private string m_Picture3;
        public string Picture3 { get => m_Picture3; set => m_Picture3 = value; }

        private string m_Descreption;
        public string Descreption { get => m_Descreption; set => m_Descreption = value; }

        private City m_City;
        public City City { get => m_City; set => m_City = value; }

        private int m_Size;
        public int Size { get => m_Size; set => m_Size = value; }

        #endregion

        public bool Insert()
        {
            return Houses_Dal.Insert(m_Adress, m_Client, m_Picture1, m_Picture2, m_Picture3, m_Descreption, m_City.ID, m_Size);
        }

        public House() { }

        public House(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח

            this.m_Adress = dataRow["Adress"].ToString();
            this.m_ID = (int)dataRow["ID"];
            this.m_Client = (int)dataRow["Client"];
            this.m_Picture1 = dataRow["Picture1"].ToString();
            this.m_Picture2 = dataRow["Picture2"].ToString();
            this.m_Picture3 = dataRow["Picture3"].ToString();
            this.m_Descreption = dataRow["Descreption"].ToString();
            this.m_City = new City(dataRow.GetParentRow("ProductCity"));
            this.m_Size = (int)dataRow["Size"];
        }

        public override string ToString()
        {
            return m_Adress;
        }

        public bool Update()
        {
            return Houses_Dal.Update(m_Adress, m_ID, m_Client, m_Picture1, m_Picture2, m_Picture3, m_Descreption, m_City.ID,m_Size);

        }
        public bool Delete()
        {
            return Houses_Dal.Delete(m_ID);
        }

    }

}

