using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using ClientSahar.DAL;
using ClientSahar.BL;

namespace ClientSahar
{
    public class CityArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = City_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            City city;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                city = new City(dataRow);
                this.Add(city);
            }
        }

        public CityArr Filter(int id, string Name)
        {
            CityArr cityArr = new CityArr();
            City city;
            for (int i = 0; i < this.Count; i++)
            {

                //הצבת העיר הנוכחי במשתנה עזר - עיר

                city = (this[i] as City);
                if
                (

                // מזהה 0 – כלומר, לא נבחר מזהה בסינון

               (id == 0 || city.ID == id)
                && city.Name.StartsWith(Name))

                    //הלקוח ענה לדרישות הסינון - הוספת הלקוח לאוסף הלקוחות המוחזר

                    cityArr.Add(city);
            }
            return cityArr;
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

        public bool IsContain(string cityName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            cityName = cityName.Replace("י", "");
            cityName = cityName.Replace("ו", "");
            string curCityName;
            for (int i = 0; i < this.Count; i++)
            {
                curCityName = (this[i] as City).Name;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                cityName = cityName.Replace("י", "");
                cityName = cityName.Replace("ו", "");
                if (curCityName == cityName)
                    return true;

            }
            return false;
        }
        public City GetCityWithMaxId()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            City maxCity = new City();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as City).ID > maxCity.ID)
                    maxCity = (this[i] as City);

            }
            return maxCity;
        }
    }

}

