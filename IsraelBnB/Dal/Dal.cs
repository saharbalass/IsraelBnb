using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;

class Dal
{
    // הDB שמירה /עדכון
    //מבצע את הSQL ומחזיר אמת אם עבר ושקר אם לא
    public static bool ExecuteSql(string sql)
    {
        //מקשר
        SqlConnection connection = new SqlConnection();
        //הצבת מחרוזת הקישור במקשר - שימוש בפעולת עזר למציאת מחרוזת זאת
        connection.ConnectionString = GetConnectionString();


        //ההוראה
        SqlCommand command = new SqlCommand();
        //מקשר ל-DB
        command.Connection = connection;
        //הפעולה לביצוע
        command.CommandText = sql;

        //בגלל שיש גישה לקבצים חיצוניים וכן בגלל פתיחת קשר לקובץ חיצוני - "עוטפים" במנגנון טיפול בשגיאות"
        try
        {
            //פתיחת הקשר
            connection.Open();

            //הפעלת הפקודה
            command.ExecuteNonQuery();

            //סגירת הקשר
            connection.Close();

            return true;
        }
        catch (Exception e)
        {
            //משמש רק לצרכי בקרה במקרה של תקלה - חשוב להשאיר כאן נקודת עצירה
            e.ToString();
        }

        return false;
    }

    //פעולה שבנינו המבצעת את מילוי הדאטא סט מתוך הטבלה במסד נתונים 
    public static void FillDataSet(DataSet dataSet, string tableName, string orderBy)
    {
        //מקשר
        SqlConnection connection = new SqlConnection();
        //הצבת מחרוזת הקישור במקשר
        connection.ConnectionString = GetConnectionString();

        //מבצע פעולה
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        if (orderBy != "")
            command.CommandText = "SELECT * FROM " + tableName + " ORDER BY " + orderBy;
        else
            command.CommandText = "SELECT * FROM " + tableName;

        //מתאם
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = command;
        adapter.Fill(dataSet, tableName);
    }

    private static string GetConnectionString()
    {
        //בניית מחרוזת הקישור
        //סוג הDB
        SqlConnectionStringBuilder cString = new SqlConnectionStringBuilder();
        //מיקום הDB
        cString.DataSource = @"(localdb)\.";
        cString.AttachDBFilename = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"\IsraelBnBDataBase.mdf";
        return cString.ToString();
    }
}