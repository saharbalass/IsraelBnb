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
    public class Product
    {

        #region Memmbers
        private string m_Adress; // שם פרטי
        public string Adress { get => m_Adress; set => m_Adress = value; }

        private int m_ID; //מספר סידורי (לא ת"ז)
        public int ID { get => m_ID; set => m_ID = value; }

        private Catagory m_Catagory;
        public Catagory Catagory { get => m_Catagory; set => m_Catagory = value; }

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

        private int m_StreetNo;
        public int StreetNo { get => m_StreetNo; set => m_StreetNo = value; }

        private int m_Floor;
        public int Floor { get => m_Floor; set => m_Floor = value; }

        private int m_AptNo;
        public int AptNo { get => m_AptNo; set => m_AptNo = value; }

        private DateTime m_DateFrom;
        public DateTime DateFrom { get => m_DateFrom; set => m_DateFrom = value; }

        private int m_IsSold;
        public int IsSold { get => m_IsSold; set => m_IsSold = value; }

        private int m_Price;
        public int Price { get => m_Price; set => m_Price = value; }

        #endregion

        public bool Insert()
        {
            return Product_Dal.Insert(m_Adress, m_Catagory.ID, m_Client, m_Picture1, m_Picture2, m_Picture3, m_Descreption, m_City.ID, m_Size, m_StreetNo, m_Floor, m_AptNo,m_DateFrom,IsSold, m_Price);
        }

        //מייצר טנ"ם ריק
        public Product() { }

        public Product(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח
            //ממלאת את התכונות באופן ישיר או עקיף אם יש קשר גומלין
            this.m_Adress = dataRow["Adress"].ToString();
            this.m_ID = (int)dataRow["ID"];
            this.m_Catagory = new Catagory(dataRow.GetParentRow("ProductCatagory"));
            this.m_Client = (int)dataRow["Client"];
            this.m_Picture1 = dataRow["Picture1"].ToString();
            this.m_Picture2 = dataRow["Picture2"].ToString();
            this.m_Picture3 = dataRow["Picture3"].ToString();
            this.m_Descreption = dataRow["Descreption"].ToString();
            this.m_City = new City(dataRow.GetParentRow("ProductCity"));
            this.m_Size = (int)dataRow["Size"];
            this.m_StreetNo = (int)dataRow["Street.No"];
            this.m_Floor = (int)dataRow["Floor"];
            this.m_AptNo = (int)dataRow["Apt.No"];
            this.m_DateFrom = (DateTime)dataRow["DateFrom"];
            this.m_IsSold = (int)dataRow["IsSold"];
            this.m_Price = (int)dataRow["Price"];
        }

        public override string ToString()
        {
            return m_Adress;
        }

        public bool Update()
        {
            return Product_Dal.Update(m_ID, m_Adress, m_Catagory.ID, m_Client, m_Picture1, m_Picture2, m_Picture3, m_Descreption, m_City.ID, m_Size, m_StreetNo, m_Floor, m_AptNo,m_IsSold, m_Price);

        }
        public bool Delete()
        {
            return Product_Dal.Delete(m_ID);
        }

    }

}

