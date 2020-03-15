using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using ClientSahar.DAL;
using ClientSahar.BL;

namespace ClientSahar
{
    public class CompanyArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Company_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            Company company;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                company = new Company(dataRow);
                this.Add(company);
            }
        }

        public CompanyArr Filter(int id, string Name)
        {
            CompanyArr companyArr = new CompanyArr();
            Company company;
            for (int i = 0; i < this.Count; i++)
            {

                //הצבת העיר הנוכחי במשתנה עזר - עיר

                company = (this[i] as Company);
                if
                (

                // מזהה 0 – כלומר, לא נבחר מזהה בסינון

               (id == 0 || company.ID == id)
                && company.Name.StartsWith(Name))

                    //הלקוח ענה לדרישות הסינון - הוספת הלקוח לאוסף הלקוחות המוחזר

                    companyArr.Add(company);
            }
            return companyArr;
        }

        public bool IsContain(string companyName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            companyName = companyName.Replace("י", "");
            companyName = companyName.Replace("ו", "");
            string curcompanyName;
            for (int i = 0; i < this.Count; i++)
            {
                curcompanyName = (this[i] as Company).Name;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                companyName = companyName.Replace("י", "");
                companyName = companyName.Replace("ו", "");
                if (curcompanyName == companyName)
                    return true;

            }
            return false;
        }
        public Company GetcompanyWithMaxId()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Company maxcompany = new Company();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Company).ID > maxcompany.ID)
                    maxcompany = (this[i] as Company);

            }
            return maxcompany;
        }
    }

}