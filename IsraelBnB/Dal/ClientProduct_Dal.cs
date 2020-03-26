using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClientSahar.DAL;

namespace ProductSahar.DAL
{
    class ClientProduct_Dal
    {
        public static bool Insert(int product, int client, int intrest, DateTime dateIntrstSince, int isIntrested)
        {

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_ClientProduct"
            + "("
            + " [Product]"
            + ",[Client]"
            + " ,[Intrest]"
            + " ,[DateIntrestedSince]"
            + " ,[IsIntrested]"
            + ")"
            + " VALUES "
            + "("
            + "" + product + ""
            + "," + "" + client + ""
            + "," + "" + intrest + ""
            + "," + "'" + dateIntrstSince + "'"
            + "," + "" + isIntrested + ""
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
            dataTable = dataSet.Tables["Table_ClientProduct"];
            return dataTable;
        }

        public static bool Update(int id,int product, int client, int intrest, DateTime dateIntrstSince, int isIntrested)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_ClientProduct"
            + " " + "[Product] = " + "" + product + ""
             + "," + "[Client] = " + "" + client + ""
              + "," + "[Intrest] = " + "" + intrest + ""
            + "," + "[DateIntrestedSince] = " + "'" + dateIntrstSince.ToString("yyyy-MM-dd") + "'"
            + "," + "[IsIntrested] = " + "" + isIntrested + ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }
        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_ClientProduct"))
            {
                //ממלאת את אוסף הטבלאות בטבלת הלקוחות
                Dal.FillDataSet(dataSet, "", "");

                DataRelation dataRelation = null;



                Order_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ClientProductProduct"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Product"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_OrderProduct"].Columns["Product"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);



                Product_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ClientProductClient"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Client"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_OrderProduct"].Columns["Client"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);
            }
        }


        public static bool Delete(int id)
        {
            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_OrderProduct"
                + " Where ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
