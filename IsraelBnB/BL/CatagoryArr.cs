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
   public class CatagoryArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Catagory_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            Catagory Catagory;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                Catagory = new Catagory(dataRow);
                this.Add(Catagory);
            }
        }

        public CatagoryArr Filter(int id, string Name)
        {
            CatagoryArr catagoryArr= new CatagoryArr();
            Catagory catagory;
            for (int i = 0; i < this.Count; i++)
            {

                //הצבת העיר הנוכחי במשתנה עזר - עיר

                catagory = (this[i] as Catagory);
                if
                (

                // מזהה 0 – כלומר, לא נבחר מזהה בסינון

               (id == 0 || catagory.ID == id)
                && catagory.Name.StartsWith(Name))

                    //הלקוח ענה לדרישות הסינון - הוספת הלקוח לאוסף הלקוחות המוחזר

                    catagoryArr.Add(catagory);
            }
            return catagoryArr;
        }

        public bool IsContain(string catagoryName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            catagoryName = catagoryName.Replace("י","");
            catagoryName = catagoryName.Replace("ו","");
            string curCatagoryName;
            for (int i = 0; i < this.Count; i++)
            {
                curCatagoryName = (this[i] as Catagory).Name;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                catagoryName = catagoryName.Replace("י", "");
                catagoryName = catagoryName.Replace("ו", "");
                if (curCatagoryName == catagoryName)
                    return true;

            }
            return false;
        }
        public Catagory GetCatagoryWithMaxId()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Catagory maxCatagory = new Catagory();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Catagory).ID > maxCatagory.ID)
                    maxCatagory = (this[i] as Catagory);

            }
            return maxCatagory;
        }
    }

}
