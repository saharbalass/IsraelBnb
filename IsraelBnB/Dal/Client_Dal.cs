using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClientSahar.DAL
{
    class Client_Dal
    {
        public static bool Insert(string firstName, string lastName, string cellPhoneAreaCode, string cellPhoneNumber, /*int zipCode,*/ string email,string ID,int city,string passWord)
        {

            //מוסיפה את הלקוח למסד הנתונים
            //בניית הוראת ה-SQL

            string str = "INSERT INTO Table_Client"
            + "("
            + " [FirstName]"
            + ",[LastName]"
            //+ ",[ZipCode]"
            + ",[CellPhoneAreaCode]"
            + ",[CellPhoneNumber]"
            + ",[Email]"
            + ",[City]"
            + ",[ID_FromClient]"
            + ",[PassWord]"
            + ")"
            + " VALUES "
            + "("
                  + "N'"    + firstName           + "'"
            + "," + "N'"    + lastName            + "'"
            + "," + "'"    + cellPhoneAreaCode   + "'"
            + "," + ""     + cellPhoneNumber     + ""
            + "," + "N'"    + email               + "'"
            + "," + ""     + city                + ""
            + "," + "'"    + ID                  + "'"
            + "," + "N'"   + passWord            + "'"
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
            dataTable = dataSet.Tables["Table_Client"];
            return dataTable;
        }
        public static void FillDataSet(DataSet dataSet)
        {
            if (!dataSet.Tables.Contains("Table_CLient"))
            {
               // Dal.FillDataSet(dataSet, "Table_Client", "[FirstName]");

                //ממלאת את אוסף הטבלאות בטבלת הלקוחות
                Dal.FillDataSet(dataSet, "Table_Client", "[FirstName]");/*"[LastName],[FirstName]"*/
                                                             //בהמשך יהיו כאן הוראות נוספות הקשורות לקשרי גומלין...
                City_Dal.FillDataSet(dataSet);
                DataRelation dataRelation = null;
                dataRelation = new DataRelation(

                //שם קשר הגומלין

                "ClientCity"

                //עמודת הקשר בטבלת האב )המפתח הראשי של טבלת האב(

                , dataSet.Tables["Table_City"].Columns["ID"]

                //עמודת הקשר בטבלת הבן )המפתח הזר בטבלת הבן(

                , dataSet.Tables["Table_Client"].Columns["City"]);

                //הוספת קשר הגומלין לאוסף הטבלאות

                dataSet.Relations.Add(dataRelation);
            }
        }



        public static bool Update(string firstName, string lastName, string cellPhoneAreaCode, string cellPhoneNumber, /*int zipCode,*/ string email, int id, string ID_FromClient,int city,string passWord)
        {

            //מעדכנת את הלקוח במסד הנתונים

            string str = "UPDATE Table_Client SET"
            + " " + "[FirstName] = " + "'" + firstName + "'"
            + "," + "[LastName] = " + "'" + lastName + "'"
            + "," + "[CellPhoneNumber] = " + "" + cellPhoneNumber + ""
            + "," + "[CellPhoneAreaCode] = " + "'" + cellPhoneAreaCode + "'"
            + "," + "[ID_FromClient] =" + "'" + ID_FromClient + "'"
            + "," + "[Email] =" + "'" + email + "'"
            + "," + "[City] = " + "" + city + ""
            + "," + "[PassWord] =" + "'" + passWord + "'"
            //+ "," + "[ZipCode] = " + "" + zipCode + ""
            + " WHERE ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה

            return Dal.ExecuteSql(str);
        }

        public static bool Delete(int id)
        {
            //מוחקת את הלקוח ממסד הנתונים
            string str = "DELETE FROM Table_Client"
                + " Where ID = " + id;

            //הפעלת פעולת הSQL -תוך שימוש בפעולה המוכנה ExecuteSql במחלקה Dal והחזרה האם הפעולה הצליחה
            return Dal.ExecuteSql(str);
        }
    }
}
