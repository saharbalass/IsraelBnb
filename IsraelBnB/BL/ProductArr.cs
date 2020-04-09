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

        public bool DoesExist(City curCity)
        {

            //מחזירה האם לפחות לאחד מהלקוחות יש את היישוב

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as Client).City.ID == curCity.ID)
                    return true;

            return false;
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

                Product product = (productArr[i] as Product);
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

        public ProductArr Filter(string adress, int catagory, int priceFrom, int priceTill)
        {
            ProductArr productArr = new ProductArr();

            if (priceFrom != 0 && priceTill != 0)
            {
                for (int i = 0; i < this.Count; i++)
                {

                    //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                    Product product = (this[i] as Product);
                    if (

                     //סינון לפי שם המוצר
                     product.Adress.StartsWith(adress) && product.Catagory.ID == catagory && product.Price > priceFrom && product.Price < priceTill
                    )
                    {

                        //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                        productArr.Add(product);
                        break;

                    }
                }
            }

            if (priceFrom == 0 && priceTill != 0)
            {
                for (int i = 0; i < this.Count; i++)
                {

                    //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                    Product product = (this[i] as Product);
                    if (

                     //סינון לפי שם המוצר
                     product.Adress.StartsWith(adress) && product.Catagory.ID == catagory && product.Price < priceTill
                    )
                    {

                        //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                        productArr.Add(product);
                        break;

                    }
                }
            }

            if (priceFrom != 0 && priceTill == 0)
            {
                for (int i = 0; i < this.Count; i++)
                {

                    //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                    Product product = (this[i] as Product);
                    if (

                     //סינון לפי שם המוצר
                     product.Adress.StartsWith(adress) && product.Catagory.ID == catagory && product.Price > priceFrom
                    )
                    {

                        //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                        productArr.Add(product);
                        break;

                    }
                }
            }
            if (priceFrom == 0 && priceTill == 0)
            {
                for (int i = 0; i < this.Count; i++)
                {

                    //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                    Product product = (this[i] as Product);
                    if (

                     //סינון לפי שם המוצר
                     product.Adress.StartsWith(adress) && product.Catagory.ID == catagory
                    )
                    {

                        //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                        productArr.Add(product);
                        break;

                    }
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

        public CityArr GetCityArr()
        {
            //מחזירה את אוסף היישובים להם יש לקוח - ללא חזרות
            CityArr curCityArr = new CityArr();

            foreach (Product curProduct in this)
                if (!curCityArr.IsContain(curProduct.City))
                    curCityArr.Add(curProduct.City);

            return curCityArr;
        }

        public ProductArr Filter(City city)
        {
            ProductArr productArr = new ProductArr();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Product).City.ID == city.ID)
                {
                    productArr.Add(this[i] as Product);
                }
            }
            return productArr;
        }
        public SortedDictionary<string, int> GetSortedDictionary()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            CityArr clientsCityArr = this.GetCityArr();
            foreach (City curCity in clientsCityArr)
                dictionary.Add(curCity.Name, this.Filter(curCity).Count);
            return dictionary;
        }

        public SortedDictionary<string, int> GetSortedDictionaryForSales()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            CityArr clientsCityArr = this.GetCityArrForSaled();
            foreach (City curCity in clientsCityArr)
                dictionary.Add(curCity.Name, this.FilterForSales(curCity).Count);
            return dictionary;
        }

        public CityArr GetCityArrForSaled()
        {
            //מחזירה את אוסף היישובים להם יש לקוח - ללא חזרות
            CityArr curCityArr = new CityArr();

            //"הסופת תנאי של "האם נמכר
            // כדי להראות את הערים שנמכר בהם ולא את כל הערים 
            foreach (Product curProduct in this)
                if (!curCityArr.IsContain(curProduct.City) && curProduct.IsSold == 1)
                    curCityArr.Add(curProduct.City);

            return curCityArr;
        }

        public ProductArr FilterForSales(City city)
        {
            ProductArr productArr = new ProductArr();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Product).City.ID == city.ID && (this[i] as Product).IsSold == 1)
                {
                    productArr.Add(this[i] as Product);
                }
            }
            return productArr;
        }
    }

}
