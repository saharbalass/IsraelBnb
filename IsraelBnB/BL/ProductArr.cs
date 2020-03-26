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
   public class ProductArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Product_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            Product product;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                product = new Product(dataRow);
                this.Add(product);
            }
        }

        public void Remove(ProductArr productArr)
        {

            //מסירה מהאוסף הנוכחי את האוסף המתקבל

            for (int i = 0; i < productArr.Count; i++)
                this.Remove(productArr[i] as Product);
        }

        public ProductArr Filter(int id, string adress, Catagory category)
        {
            ProductArr productArr = new ProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Product product = (this[i] as Product);
                if (

                //סינון לפי מזהה המוצר

                (id <= 0 || product.ID == id)

                //סינון לפי שם המוצר

                && product.Adress.StartsWith(adress)

                //סינון לפי קטגוריה
                && (category == null || category.ID == -1 || product.Catagory.ID == category.ID)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    productArr.Add(product);
                    if (id > 0)
                        break;

                }
            }
            return productArr;
        }

        public ProductArr Filter(Client client)
        {
            ProductArr productArr = new ProductArr();
            //לבדוק למה צריך פה פיל (לבדוק דרך הרפרנס)כ
            productArr.Fill();
            ProductArr productArr1 = new ProductArr();

            for (int i = 0; i < productArr.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Product product= (productArr[i] as Product);
                ClientArr clientArr = new ClientArr();
                clientArr.Fill();
                Client client1 = clientArr.ReturnClientWithID(product.Client);
                if (

                //סינון לפי מזהה הקלוח

                client1.ID == client.ID
                )

                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    productArr1.Add(product);

                }
            }
            return productArr1;
        }
        public ProductArr FilterByAdress(string adress)
        {
            ProductArr productArr = new ProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Product product = (this[i] as Product);
                if (

                //סינון לפי שם המוצר
                 product.Adress.StartsWith(adress)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    productArr.Add(product);
                    break;

                }
            }
            return productArr;
        }
        public Product FilterWithID(int id)
        {
            ProductArr productArr = new ProductArr();

            for (int i = 0; i < this.Count; i++)
            {
                Product product = (this[i] as Product);
                if (product.ID == id)
                {
                    return product;
                }
            }
            return null;
        } 
        public ProductArr GetProductArr()
        {

            //מחזירה את אוסף הפריטים מתוך אוסף הזוגות פריט -הזמנה

            ProductArr productArr = new ProductArr();
            OrderProduct orderProduct;
            for (int i = 0; i < this.Count; i++)
            {
                orderProduct = (this[i] as OrderProduct);
                productArr.Add(orderProduct.Product);
            }
            return productArr;
        }
        public Product GetProductWithNumber(int place)
        {
                return this[place] as Product;;
        }
        public bool IsContain(string productName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            productName = productName.Replace("י","");
            productName = productName.Replace("ו","");
            string curproductName;
            for (int i = 0; i < this.Count; i++)
            {
                curproductName = (this[i] as Product).Adress;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                productName = productName.Replace("י", "");
                productName = productName.Replace("ו", "");
                if (curproductName == productName)
                    return true;

            }
            return false;
        }
        public Product GetproductWithMaxID()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Product maxproduct = new Product();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Product).ID > maxproduct.ID)
                    maxproduct = (this[i] as Product);

            }
            return maxproduct;
        }

        public int GetNumberOfProducts()
        {
            return this.Count;
        }

        public void Update()
        {

            //מעדכנת את אוסף המוצרים

            for (int i = 0; i < this.Count; i++)
            {
                (this[i] as Product).Update();
            }
        }

        public void UpdateProduct(Product product)
        {

            //מעדכנת את הכמות של הפריט באוסף הנוכחי

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as Product).ID == product.ID)
                {
                    this[i] = product;
                    break;
                }

        }
    }

}
