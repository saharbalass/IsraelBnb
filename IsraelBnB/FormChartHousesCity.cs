using ClientSahar;
using ClientSahar.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IsraelBnB
{
    public partial class FormChartHousesCity : Form
    {
        public FormChartHousesCity()
        {
            InitializeComponent();
            DataToChart();
        }

        public void DataToChart()
        {
            // פלטת הצבעים -אפשר גם להגדיר מראש במאפיינים )לא בקוד(
            chart1.Palette = ChartColorPalette.SeaGreen;
            // מחייב הצגת כל הערכים בציר האיקס, אם רוצים שיוצגו לסירוגין רושמים 2//
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            //     כותרת הגרף -1//
            chart1.Titles.Clear();
            chart1.Titles.Add("התפלגות");
            //  הוספת הערכים למשתנה מסוג מילון ממוין//
            HouseArr curHousetArr = new HouseArr();
            curHousetArr.Fill();
            SortedDictionary<string, int> dictionary = curHousetArr.GetSortedDictionary();
            CityArr clientsCityArr = curHousetArr.GetCityArr();
            foreach (City curCity in clientsCityArr)
                dictionary.Add(curCity.Name, curHousetArr.Filter(curCity).Count);
            //הגדרת סדרה וערכיה - שם הסדרה מועבר למקרא - 2

            Series series = new Series("התפלגות ", 0);

            //סוג הגרף

            series.ChartType = SeriesChartType.Column;

            //המידע שיוצג לכל רכיב ערך בגרף - 3

            //   שם - VALX//#
            //הערך - VAL//#
            //אחוז עם אפס אחרי הנקודה - {
            //     P0{
            //  PERCENT//#
            series.Label = "#VALX [#VAL = #PERCENT{P0}]";
            // הוספת הערכים מתוך משתנה המילון לסדרה//
            series.Points.DataBindXY(dictionary.Keys, dictionary.Values);
            //מחיקת סדרות קיימות - אם יש ולא בכוונה

            chart1.Series.Clear();

            //הוספת הסדרה לפקד הגרף

            chart1.Series.Add(series);
        }
    }
}
