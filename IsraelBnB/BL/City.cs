using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSahar.DAL;
using System.Data;

namespace ClientSahar.BL
{
    public class City
    {

        private string m_Name; // שם פרטי
        public string Name { get => m_Name; set => m_Name = value; }

        private int m_ID; //מספר סידורי (לא ת"ז)
        public int ID { get => m_ID; set => m_ID = value; }

        public bool Insert()
        {
            return City_Dal.Insert(m_Name);
        }

        public City() { }

        public City(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח

            this.m_Name = dataRow["Name"].ToString();
            this.m_ID = (int)dataRow["ID"];
        }

        public override string ToString()
        {
            return m_Name;
        }

        public bool Update()
        {
            return City_Dal.Update(m_Name, m_ID);

        }
        public bool Delete()
        {
            return City_Dal.Delete(m_ID);
        }

    }

}
