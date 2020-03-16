using System.Collections;
using System.Data;
using ClientSahar.BL;
using ProductSahar.DAL;

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
                return this[place] as House;;
        }
        public bool IsContain(string houseName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            houseName = houseName.Replace("י","");
            houseName = houseName.Replace("ו","");
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
