using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClientSahar.DAL;

namespace ProductSahar.DAL
{
    class OrderProduct_Dal
    {
        public static bool Insert(int order, int product,int count)
        {

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_OrderProduct"
            + "("
            + " [Order]"
            + ",[Product]"
            +" ,[Count]"
            + ")"
            + " VALUES "
            + "("
            + "" + count + ""
                  + "'" + order + "'"
                  + "," + "" + product + ""
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
            dataTable = dataSet.Tables["Table_OrderProduct"];
            return dataTable;
        }
        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_OrderProduct"))
            {
                //ממלאת את אוסף הטבלאות בטבלת הלקוחות
                Dal.FillDataSet(dataSet, "Table_OrderProduct", "");/*"[LastName],[FirstName]"*/

                DataRelation dataRelation = null;



                Order_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "OrderProductOrder"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Order"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_OrderProduct"].Columns["Order"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);



                Product_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "OrderProductProduct"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Product"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_OrderProduct"].Columns["Product"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);
            }
        }




        //public static bool Update(string Name, int id)
        //{

        //    //מעדכנת את הלקוח במסד הנתונים

        //    string str = "UPDATE Table_OrderProduct SET"
        //    + " " + "[Name] = " + "'" + Name + "'"
        //    + " WHERE ID = " + id;

        //    //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

        //    return Dal.ExecuteSql(str);
        //}

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
