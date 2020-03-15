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
   public class OrderProductArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = OrderProduct_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            OrderProduct orderProduct;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                orderProduct = new OrderProduct(dataRow);
                this.Add(orderProduct);
            }
        }

        public OrderProductArr Filter(int id,Order order, Product product)
        {
            OrderProductArr orderProductArr = new OrderProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                OrderProduct orderProduct = (this[i] as OrderProduct);
                if (

                //סינון לפי מזהה המוצר

                (id <= 0 || orderProduct.ID == id)

                //סינון לפי החברה
                && (order == null || order.ID == -1 || orderProduct.Order.ID == order.ID)
                //סינון לפי קטגוריה
                && (product == null || product.ID == -1 || orderProduct.Product.ID == product.ID)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    orderProductArr.Add(orderProduct);
                    if (id > 0)
                        break;

                }
            }
            return orderProductArr;
        }

         public OrderProductArr Filter(Order order)
        {
            OrderProductArr orderProductArr = new OrderProductArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                OrderProduct orderProduct = (this[i] as OrderProduct);
                if (order == orderProduct.Order)
                {
                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר
                    orderProductArr.Add(orderProduct);

                }
            }
            return orderProductArr;
        }
        //public bool IsContain(string orderProductName)
        //{

        //    //בדיקה האם יש ישוב עם אותו שם
        //    //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

        //    orderProductName = orderProductName.Replace("י","");
        //    orderProductName = orderProductName.Replace("ו","");
        //    string curorderProductName;
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        curorderProductName = (this[i] as Product).Name;

        //        //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

        //        orderProductName = orderProductName.Replace("י", "");
        //        orderProductName = orderProductName.Replace("ו", "");
        //        if (curorderProductName == orderProductName)
        //            return true;

        //    }
        //    return false;
        //}
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
        public bool Insert()
        {

            //מוסיפה את אוסף המוצרים להזמנה למסד הנתונים

            OrderProduct orderProduct = null;
            for (int i = 0; i < this.Count; i++)
            {
                orderProduct = (this[i] as OrderProduct);
                if (!orderProduct.Insert())
                    return false;

            }
            return true;
        }

        public bool Delete()
        {

            //מוחקת את אוסף המוצרים להזמנה מ מסד הנתונים

            OrderProduct orderProduct = null;
            for (int i = 0; i < this.Count; i++)
            {
                orderProduct = (this[i] as OrderProduct);
                if (!orderProduct.Delete())
                    return false;

            }
            return true;
        }
    }

}
