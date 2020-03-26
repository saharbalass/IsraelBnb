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

            DataTable dataTable = OrderProduct_Dal.GetDataTable();

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
                    (client == null || client.ID == -1 || clientProduct.Client.ID == client.ID)
                //סינון לפי קטגוריה
                && (product == null || product.ID == -1 || clientProduct.Product.ID == product.ID))
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
}

}
