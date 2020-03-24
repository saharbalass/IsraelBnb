using System.Collections;
using System.Data;
using ClientSahar.BL;
using ProductSahar.DAL;
using System.Collections.Generic;

namespace ClientSahar
{
    public class HouseArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Houses_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            House house;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                house = new House(dataRow);
                this.Add(house);
            }
        }

        public void Remove(HouseArr houseArr)
        {

            //מסירה מהאוסף הנוכחי את האוסף המתקבל

            for (int i = 0; i < houseArr.Count; i++)
                this.Remove(houseArr[i] as House);
        }

        public HouseArr Filter(int id, string adress)
        {
            HouseArr houseArr = new HouseArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                House house = (this[i] as House);
                if (

                //סינון לפי מזהה המוצר

                (id <= 0 || house.ID == id)

                //סינון לפי שם המוצר

                && house.Adress.StartsWith(adress)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    houseArr.Add(house);
                    if (id > 0)
                        break;

                }
            }
            return houseArr;
        }

        public bool DoesExist(City curCity)
        {

            //מחזירה האם לפחות לאחד מהלקוחות יש את היישוב

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as House).City.ID == curCity.ID)
                    return true;

            return false;
        }

        public HouseArr Filter(Client client)
        {
            HouseArr houseArr = new HouseArr();
            //לבדוק למה צריך פה פיל (לבדוק דרך הרפרנס)כ
            houseArr.Fill();
            HouseArr houseArr1 = new HouseArr(); 

            for (int i = 0; i < houseArr.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                House house = (houseArr[i] as House);
                ClientArr clientArr = new ClientArr();
                clientArr.Fill();
                Client client1 = clientArr.ReturnClientWithID(house.Client);
                if (

                //סינון לפי מזהה הקלוח

                client1.ID == client.ID
                )
                
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    houseArr1.Add(house);

                }
            }
            return houseArr1;
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

            foreach (House curHouse in this)
                if (!curCityArr.IsContain(curHouse.City.Name))
                    curCityArr.Add(curHouse.City);

            return curCityArr;
        }
        public SortedDictionary<string, int> GetSortedDictionary()
        {

            // מחזירה משתנה מסוג מילון ממוין עם ערכים רלוונטיים לדוח
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            CityArr HousesclientsCityArr = this.GetCityArr();
            foreach (City curCity in HousesclientsCityArr)
                dictionary.Add(curCity.Name, this.Filter(curCity).Count);
            return dictionary;
        }

        //שמקבלת יישוב ומחזירה רק את הלקוחות הגרים באותו ישוב )העמסה על פעולת הסינון הקיימת
        public HouseArr Filter(City city)
        {
            HouseArr houseArr = new HouseArr();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as House).City.ID == city.ID)
                {
                    houseArr.Add((this[i] as House));
                }
            }
            return houseArr;
        }
        public HouseArr FilterByAdress(string adress)
        {
            HouseArr houseArr = new HouseArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                House house = (this[i] as House);
                if (

                //סינון לפי שם המוצר
                 house.Adress.StartsWith(adress)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    houseArr.Add(house);
                    break;

                }
            }
            return houseArr;
        }
        public House FilterWithID(int id)
        {
            HouseArr houseArr = new HouseArr();

            for (int i = 0; i < this.Count; i++)
            {
                House house = (this[i] as House);
                if (house.ID == id)
                {
                    return house;
                }
            }
            return null;
        }

        public House GetHouseWithNumber(int place)
        {
            return this[place] as House; ;
        }
        public bool IsContain(string houseName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            houseName = houseName.Replace("י", "");
            houseName = houseName.Replace("ו", "");
            string curhouseName;
            for (int i = 0; i < this.Count; i++)
            {
                curhouseName = (this[i] as House).Adress;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                houseName = houseName.Replace("י", "");
                houseName = houseName.Replace("ו", "");
                if (curhouseName == houseName)
                    return true;

            }
            return false;
        }
        public House GethouseWithMaxID()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            House maxhouse = new House();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as House).ID > maxhouse.ID)
                    maxhouse = (this[i] as House);

            }
            return maxhouse;
        }

        public int GetNumberOfHouses()
        {
            return this.Count;
        }

        public void Update()
        {

            //מעדכנת את אוסף המוצרים

            for (int i = 0; i < this.Count; i++)
            {
                (this[i] as House).Update();
            }
        }

        public void UpdateHouse(House house)
        {

            //מעדכנת את הכמות של הפריט באוסף הנוכחי

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as House).ID == house.ID)
                {
                    this[i] = house;
                    break;
                }

        }
    }

}
