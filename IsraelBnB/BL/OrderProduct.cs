using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSahar.DAL;
using System.Data;
using ProductSahar.DAL;

namespace ClientSahar.BL
{
    public class OrderProduct
    {
        private int m_ID; //מספר סידורי (לא ת"ז)
        public int ID { get => m_ID; set => m_ID = value; }

        private Order m_Order;
        public Order Order { get => m_Order; set => m_Order = value; }

        private Product m_Product;
        public Product Product { get => m_Product; set => m_Product = value; }

        private int m_Count;
        public int Count { get => m_Count; set => m_Count = value; }
        public bool Insert()
        {
            return OrderProduct_Dal.Insert(m_Order.ID, m_Product.ID,m_Count);
        }

        public OrderProduct() { }

        public OrderProduct(DataRow dataRow)
        {

            //מייצרת לקוח מתוך שורת לקוח
            this.m_ID = (int)dataRow["ID"];
            this.m_Order = new Order(dataRow.GetParentRow("OrderProductOrder"));
            this.m_Product = new Product(dataRow.GetParentRow("OrderProductProduct"));
            this.m_Count = (int)dataRow["Count"];
        }


        //public bool Update()
        //{
        //    return Product_Dal.Update(m_Name, m_ID);

        //}
        public bool Delete()
        {
            return Product_Dal.Delete(m_ID);
        }
    }

}

