using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClientSahar.DAL
{
    class City_Dal
    {
        public static bool Insert(string name)
        {

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_City"
            + "("
            + " [Name]"
            + ")"
            + " VALUES "
            + "("
                  + "N'"   + name          + "'"
            + ")";
            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
        //function that returns a table of all the clients
        public static DataTable GetDataTable()
        {
            DataTable dataTable = null;
            DataSet dataSet = new DataSet();
            FillDataSet(dataSet);
            dataTable = dataSet.Tables["Table_City"];
            return dataTable;
        }
        public static void FillDataSet(DataSet dataSet)
        {

            //ממלאת את אוסף הטבלאות בטבלה הנוכחית - בתנאי שהטבלה לא נמצאת כבר באוסף

            if (!dataSet.Tables.Contains("Table_City"))
            {
                Dal.FillDataSet(dataSet, "Table_City", "[Name]");
            }

        }



        public static bool Update(string Name, int id)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_City SET"
            + " " + "[Name] = " + "'" + Name + "'"
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }

        public static bool Delete(int id)
        {
            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_City"
                + " Where ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
