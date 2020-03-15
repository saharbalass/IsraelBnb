using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClientSahar.DAL
{
    class Order_Dal
    {
        public static bool Insert(int client,DateTime date,string note)
        {

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_Order"
            + "("
            + " [Client]"
            + ",[Date]"
            + ",[Note]"
            + ")"
            + " VALUES "
            + "("
                  + ""     + client          + ""
            + "," + "'"    + date.ToString("yyyy-MM-dd")           + "'" 
            + "," + "'"    + note            + "'"
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
            dataTable = dataSet.Tables["Table_Order"];
            return dataTable;
        }
        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_Order"))
            {

                //ממלאת את אוסף הטבלאות בטבלת הלקוחות
                Dal.FillDataSet(dataSet, "Table_Order", "[Client]");/*"[LastName],[FirstName]"*/
                                                             //בהמשך יהיו כאן הוראות נוספות הקשורות לקשרי גומלין...
                Client_Dal.FillDataSet(dataSet);
                DataRelation dataRelation = null;
                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "OrderClient"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Client"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_Order"].Columns["Client"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);
            }
        }



        public static bool Update(int client, DateTime date, string note,int id)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_Order SET"
            + " " + "[Client] = " + "" + client + ""
            + "," + "[Date] = " + "'" + date.ToString("yyyy-MM-dd") + "'"
            + "," + "[Note] = " + "'" + note + "'"
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }

        public static bool Delete(int id)
        {
            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_Order"
                + " Where ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
