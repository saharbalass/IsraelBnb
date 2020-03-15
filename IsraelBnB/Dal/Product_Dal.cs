using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClientSahar.DAL;

namespace ProductSahar.DAL
{
    class Product_Dal
    {
        public static bool Insert(string adress, int catagory, int client, string picture1, string picture2, string picture3,string descreption,int city)
        { 

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_Product"
            + "("
            + " [Adress]"
            + ",[Catagory]"
            + ",[Client]"
            + ",[Picture1]"
            + ",[Picture2]"
            + ",[Picture3]"
            + ",[Descreption]"
            + ",[City]"
            + ")"
            + " VALUES "
            + "("
                  + "N'" + adress + "'"
                  + "," + "" + catagory + ""
                  + "," + "" + client + ""
                  + "," + "N'" + picture1 + "'"
                  + "," + "N'" + picture2 + "'"
                  + "," + "N'" + picture3 + "'"
                  + "," + "N'" + descreption + "'"
                  + "," + "" + city + ""
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
            dataTable = dataSet.Tables["Table_Product"];
            return dataTable;
        }
        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_Product"))
            {
                //ממלאת את אוסף הטבלאות בטבלת הלקוחות
                Dal.FillDataSet(dataSet, "Table_Product", "[Adress]");/*"[LastName],[FirstName]"*/

                DataRelation dataRelation = null;



                City_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ProductCity"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_City"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_Product"].Columns["City"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);



                Catagory_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ProductCatagory"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Catagory"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_Product"].Columns["Catagory"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);




                Client_Dal.FillDataSet(dataSet);

                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ProductClient"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_Client"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_Product"].Columns["Client"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);
            }
        }

        public static bool Update(string adress, int id,int catagory,int client,string picture1, string picture2, string picture3,string descreption, int city)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_Product SET"
            + " " + "[Adress] = " + "'" + adress + "'"
            + "," + "[Catagory] = " + "" + catagory + ""            
            + "," + "[Client] = " + "" + client + ""
            + " " + "[Picture1] = " + "'" + picture1 + "'"
            + " " + "[Picture2] = " + "'" + picture2 + "'"
            + " " + "[Picture3] = " + "'" + picture3 + "'"
            + " " + "[Descreption] = " + "'" + descreption + "'"
            + "," + "[City] = " + "" + city+ ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }

        public static bool Delete(int id)
        {
            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_Product"
                + " Where ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
