using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using ClientSahar.DAL;
using ClientSahar.BL;
using ProductSahar.DAL;

namespace ClientSahar
{
    public class ClientProductArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = ClientProduct_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            ClientProduct clientProduct;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                clientProduct = new ClientProduct(dataRow);
                this.Add(clientProduct);
            }
        }

        public ClientProductArr Filter(int id, Client client, Product product)
        {
            ClientProductArr clientProductArr = new ClientProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                ClientProduct clientProduct = (this[i] as ClientProduct);
                if (

                //סינון לפי מזהה המוצר

                (id <= 0 || clientProduct.Id == id)

                //סינון לפי החברה
                && (client == null || client.ID == -1 || clientProduct.Client.ID == client.ID)
                //סינון לפי קטגוריה
                && (product == null || product.ID == -1 || clientProduct.Product.ID == product.ID)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    clientProductArr.Add(clientProduct);
                    if (id > 0)
                        break;

                }
            }
            return clientProductArr;
        }
        public ClientProductArr Filter(Client client, Product product)
        {
            ClientProductArr clientProductArr = new ClientProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                ClientProduct clientProduct = (this[i] as ClientProduct);
                if (
                    (client == null || client.ID == -1 || clientProduct.Client.ID == client.ID)
                //סינון לפי קטגוריה
                && (product == null || product.ID == -1 || clientProduct.Product.ID == product.ID))
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    clientProductArr.Add(clientProduct);
                }
            }
            return clientProductArr;
        }

        public ClientProduct FindClientProduct(Client client, Product product)
        {
            ClientProduct clientProduct1 = new ClientProduct();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                ClientProduct clientProduct = (this[i] as ClientProduct);
                if (
                    !(client == null || client.ID == -1 || clientProduct.Client.ID != client.ID)
                //סינון לפי קטגוריה
                && !(product == null || product.ID == -1 || clientProduct.Product.ID != product.ID))
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    clientProduct1 = clientProduct;
                }
            }
            return clientProduct1;
        }

        public ClientProductArr Filter(Product product)
        {
            ClientProductArr clientProductArr = new ClientProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                ClientProduct clientProduct = (this[i] as ClientProduct);
                if (product == clientProduct.Product)
                {
                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר
                    clientProductArr.Add(clientProduct);

                }
            }
            return clientProductArr;
        }
        public Product GetorderProductWithMaxID()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Product maxorderProduct = new Product();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Product).ID > maxorderProduct.ID)
                    maxorderProduct = (this[i] as Product);

            }
            return maxorderProduct;
        }
        public bool Insert()
        {

            //מוסיפה את אוסף המוצרים להזמנה למסד הנתונים

            ClientProduct clientProduct = null;
            for (int i = 0; i < this.Count; i++)
            {
                clientProduct = (this[i] as ClientProduct);
                if (!clientProduct.Insert())
                    return false;

            }
            return true;
        }

        public bool Delete()
        {

            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            ClientProduct clientProduct = null;
            for (int i = 0; i < this.Count; i++)
            {
                clientProduct = (this[i] as ClientProduct);
                if (!clientProduct.Delete())
                    return false;

            }
            return true;
        }

        public int AvrageWaitingForIntrest(City city)
        {
            int avrg = 0;

            //current dattime of ClientProduct [DateIntrestedSince]
            int yearIntrest;
            int monthIntrest;
            int dayntrest;

            //Time since The product Signed in from
            int yearProduct;
            int monthProduct;
            int dayProduct;


            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as ClientProduct).Product.City.ID == city.ID)
                {
                    yearIntrest = (this[i] as ClientProduct).DateIntrestedSince.Year;
                    monthIntrest = (this[i] as ClientProduct).DateIntrestedSince.Month;
                    dayntrest = (this[i] as ClientProduct).DateIntrestedSince.Day;

                    yearProduct = (this[i] as ClientProduct).Product.DateFrom.Year;
                    monthProduct = (this[i] as ClientProduct).Product.DateFrom.Month;
                    dayProduct = (this[i] as ClientProduct).Product.DateFrom.Day;

                    //the math
                    avrg += (Math.Abs((yearIntrest - yearProduct) + (monthIntrest - monthProduct) + (dayntrest - dayProduct))) / (i+1);
                    //בגלל שI מתחיל ב0 אז מוסיפים עוד אחד כדי שיהיה שווה לכמות
                }
            }
            return avrg;
        }
        public bool IsContain(City city)
        {
            //בדיקה האם הישוב קיים באוסף
            foreach (City curCity in this)
            {
                if (curCity.ID == city.ID)
                    return true;
            }

            return false;
        }

        public CityArr GetCityArr()
        {
            //מחזירה את אוסף היישובים להם יש לקוח - ללא חזרות
            CityArr curCityArr = new CityArr();

            foreach (ClientProduct curClientProduct in this)
                if (!curCityArr.IsContain(curClientProduct.Product.City))
                    curCityArr.Add(curClientProduct.Product.City);

            return curCityArr;
        }

        public SortedDictionary<string, int> GetSortedDictionaryAvrgWaitForIntrest()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            CityArr clientsCityArr = this.GetCityArr();
            foreach (City curCity in clientsCityArr)
                //שם את העיר והממוצע
                dictionary.Add(curCity.Name, AvrageWaitingForIntrest(curCity));
            return dictionary;
        }

    }

}
