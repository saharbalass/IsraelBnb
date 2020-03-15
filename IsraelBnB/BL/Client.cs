using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSahar.DAL;
using System.Data;

namespace ClientSahar.BL
{
    public class Client
    {

        private string m_FirstName; // שם פרטי
        public string FirstName { get => m_FirstName; set => m_FirstName = value; }

        private string m_LastName; //שם משפחה
        public string LastName { get => m_LastName; set => m_LastName = value; }

        //private int m_ZipCode;
        //public int ZipCode { get => m_ZipCode; set => m_ZipCode = value; }

        private string m_CellPhoneAreaCode; //קידומת של מספר הטלפון
        public string CellPhone_AreaCode { get => m_CellPhoneAreaCode; set => m_CellPhoneAreaCode = value; }
        
        //מוגדר בתור ערך מספרי מכיוון שאין מספר המתחיל ב0
        private string m_CellPhoneNumber; // מספר הטלפון
        public string PhoneNumber { get => m_CellPhoneNumber; set => m_CellPhoneNumber = value; }

        private string m_Mail; // אימייל הלקוח
        public string Mail { get => m_Mail; set => m_Mail = value; }

        private string m_ID_FromClient; //תעודת זהות של הלקוח
        public string ID_FromClient { get => m_ID_FromClient; set => m_ID_FromClient = value; }
        
        private City m_City;
        public City City { get => m_City; set => m_City = value; }

        private int m_ID; //מספר סידורי (לא ת"ז)
        public int ID { get => m_ID; set => m_ID= value; }

        private string m_FullName;
        public string FullName { get => m_FullName; set => m_FullName = value; }
        private string m_PassWord;
        public string PassWord { get => m_PassWord; set => m_PassWord = value; }

        public bool Insert()
        {
            return Client_Dal.Insert(m_FirstName, m_LastName, m_CellPhoneAreaCode, m_CellPhoneNumber,/*m_ZipCode*/ m_Mail, m_ID_FromClient,m_City.ID,m_PassWord);
        }

        public Client() { }

        public Client(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח

            this.m_ID_FromClient = dataRow["ID_FromClient"].ToString();
            this.m_FirstName = dataRow["FirstName"].ToString();
            this.m_LastName = dataRow["LastName"].ToString();
            this.m_CellPhoneNumber = dataRow["CellPhoneNumber"].ToString();
            this.m_CellPhoneAreaCode = dataRow["CellPhoneAreaCode"].ToString();
            //this.m_ZipCode = (int)dataRow["ZipCode"];
            this.m_Mail = dataRow["Email"].ToString();
            this.m_City = new City(dataRow.GetParentRow("ClientCity"));
            this.m_ID = (int)dataRow["ID"];
            this.m_PassWord = dataRow["PassWord"].ToString();
            this.m_FullName = dataRow["FirstName"].ToString() + " " + dataRow["LastName"].ToString();
        }

        public override string ToString()
        {
            return m_FirstName + " " + m_LastName;
        }

        

        public bool Update()
        {
            return Client_Dal.Update(m_FirstName, m_LastName, m_CellPhoneAreaCode, m_CellPhoneNumber,/*m_ZipCode,*/

            m_Mail,m_ID,m_ID_FromClient,m_City.ID,m_PassWord);

        }
        public bool Delete()
        {
            return Client_Dal.Delete(m_ID);
        }

    }

}
