using System.Collections;
using System.Data;
using ClientSahar.BL;
using ProductSahar.DAL;

namespace ClientSahar
{
    public class ApartmentArr : ArrayList
    {
        public void Fill()
        {

            //להביא מה-DAL טבלה מלאה בכל הלקוחות

            DataTable dataTable = Apartments_Dal.GetDataTable();

            //להעביר את הערכים מהטבלה לתוך אוסף הלקוחות
            //להעביר כל שורה בטבלה ללקוח

            DataRow dataRow;
            Apartment apartment;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataRow = dataTable.Rows[i];
                apartment = new Apartment(dataRow);
                this.Add(apartment);
            }
        }

        public void Remove(ApartmentArr ApartmentArr)
        {

            //מסירה מהאוסף הנוכחי את האוסף המתקבל

            for (int i = 0; i < ApartmentArr.Count; i++)
                this.Remove(ApartmentArr[i] as Apartment);
        }
        public ApartmentArr Filter(Client client)
        {
            ApartmentArr apartmentArr = new ApartmentArr();
            //לבדוק למה צריך פה פיל (לבדוק דרך הרפרנס)כ
            apartmentArr.Fill();
            ApartmentArr apartmentArr1 = new ApartmentArr();

            for (int i = 0; i < apartmentArr.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Apartment apartment= (apartmentArr[i] as Apartment);
                ClientArr clientArr = new ClientArr();
                clientArr.Fill();
                Client client1 = clientArr.ReturnClientWithID(apartment.Client);
                if (

                //סינון לפי מזהה הקלוח

                client1.ID == client.ID
                )

                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    apartmentArr1.Add(apartment);

                }
            }
            return apartmentArr1;
        }
        public bool DoesExist(City curCity)
        {

            //מחזירה האם לפחות לאחד מהלקוחות יש את היישוב

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as Apartment).City.ID == curCity.ID)
                    return true;

            return false;
        }
        public ApartmentArr Filter(int id, string adress)
        {
            ApartmentArr ApartmentArr = new ApartmentArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Apartment apartment = (this[i] as Apartment);
                if (

                //סינון לפי מזהה המוצר

                (id <= 0 || apartment.ID == id)

                //סינון לפי שם המוצר

                && apartment.Adress.StartsWith(adress)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר

                    ApartmentArr.Add(apartment);
                    if (id > 0)
                        break;

                }
            }
            return ApartmentArr;
        }

        public ApartmentArr FilterByAdress(string adress)
        {
            ApartmentArr ApartmentArr = new ApartmentArr();

            for (int i = 0; i < this.Count; i++)
            {

                //הצבת המוצר הנוכחי במשתנה עזר - מוצר

                Apartment apartment = (this[i] as Apartment);
                if (
                //סינון לפי שם המוצר
                 apartment.Adress.StartsWith(adress)
                )
                {

                    //המוצר ענה לדרישות החיפוש - הוספה שלו לאוסף המוחזר
                    ApartmentArr.Add(apartment);

                }
            }
            return ApartmentArr;
        }
        public Apartment FilterWithID(int id)
        {
            ApartmentArr ApartmentArr = new ApartmentArr();

            for (int i = 0; i < this.Count; i++)
            {
                Apartment apartment = (this[i] as Apartment);
                if (apartment.ID == id)
                {
                    return apartment;
                }
            }
            return null;
        }
        public Apartment GetApartmentWithNumber(int place)
        {
            return this[place] as Apartment; ;
        }
        public bool IsContain(string apartmentName)
        {

            //בדיקה האם יש ישוב עם אותו שם
            //הסרת האותיות י', ו' משם היישוב לבדיקה - כדיי לשפר מניעת כפילות

            apartmentName = apartmentName.Replace("י", "");
            apartmentName = apartmentName.Replace("ו", "");
            string curapartmentName;
            for (int i = 0; i < this.Count; i++)
            {
                curapartmentName = (this[i] as Apartment).Adress;

                //הסרת האותיות י', ו' משם היישוב הנוכחי - כדיי לשפר מניעת כפילות

                apartmentName = apartmentName.Replace("י", "");
                apartmentName = apartmentName.Replace("ו", "");
                if (curapartmentName == apartmentName)
                    return true;

            }
            return false;
        }
        public Apartment GetapartmentWithMaxID()
        {

            //מחזירה את הישוב עם המזהה הגבוה ביותר

            Apartment maxapartment = new Apartment();
            for (int i = 0; i < this.Count; i++)
            {
                if ((this[i] as Apartment).ID > maxapartment.ID)
                    maxapartment = (this[i] as Apartment);

            }
            return maxapartment;
        }

        public int GetNumberOfApartments()
        {
            return this.Count;
        }

        public void Update()
        {

            //מעדכנת את אוסף המוצרים

            for (int i = 0; i < this.Count; i++)
            {
                (this[i] as Apartment).Update();
            }
        }

        public void UpdateApartment(Apartment apartment)
        {

            //מעדכנת את הכמות של הפריט באוסף הנוכחי

            for (int i = 0; i < this.Count; i++)
                if ((this[i] as Apartment).ID == apartment.ID)
                {
                    this[i] = apartment;
                    break;
                }

        }
    }

}
