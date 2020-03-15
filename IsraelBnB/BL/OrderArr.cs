using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using ClientSahar.BL;
using ClientSahar.DAL;

namespace OrderSahar
{
   public class OrderArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Order_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            Order order;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                order = new Order(dataRow);
                this.Add(order);
            }
        }

        //public OrderArr Filter(int id, string note, DateTime dateTime,Client client)
        //{
        //    OrderArr orderArr = new OrderArr();
        //    Order order;
        //    for (int i = 0; i < this.Count; i++)
        //    {

        //        //הצבת הלקוח הנוכחי במשתנה עזר - לקוח

        //        order = (this[i] as Order);
        //        if
        //        (

        //        // מזהה 0 – כלומר, לא נבחר מזהה בסינון

        //        (id == 0 || order.ID == id)
        //        && order.Date == dateTime  
        //        && order.Client.FirstName == client.FirstName
        //        && order.Client.LastName == client.LastName
        //        )

        //            //הלקוח ענה לדרישות הסינון - הוספת הלקוח לאוסף הלקוחות המוחזר

        //            orderArr.Add(order);
        //    }
        //    return orderArr;
        //}

        public OrderArr Filter(int id, Client client, DateTime fromDate, DateTime toDate)
        {
            OrderArr orderArr = new OrderArr();
            Order order;
            for (int i = 0; i < this.Count; i++)
            {

                //הצבת הלקוח הנוכחי במשתנה עזר - לקוח

                order = (this[i] as Order);
                if
                 (

                 // מזהה 0 – כלומר, לא נבחר מזהה בסינון

                 (id == 0 || order.ID == id)
                 &&
                 (
                 ((order.Date.Ticks > fromDate.Ticks) || ((order.Date - fromDate.Date).TotalDays == 0))
                 && ((order.Date.Ticks < toDate.Ticks) || (order.Date - toDate.Date).TotalDays == 0)
                 )
                 &&
                 ((order.Client.ID == client.ID) || (client.ID == -1))
                 )


                    //הלקוח ענה לדרישות הסינון - הוספת הלקוח לאוסף הלקוחות המוחזר

                    orderArr.Add(order);
            }
            return orderArr;
        }
        public bool DoesExist(Client curClient)
        {

            //מחזירה האם לפחות לאחד מהלקוחות יש את היישוב

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as Order).Client.ID == curClient.ID)
                    return true;

            return false;
        }


        public Order GetOrderWithMaxID()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Order maxOrder = new Order();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Order).ID > maxOrder.ID)
                    maxOrder = (this[i] as Order);

            }
            return maxOrder;
        }
    }
}
