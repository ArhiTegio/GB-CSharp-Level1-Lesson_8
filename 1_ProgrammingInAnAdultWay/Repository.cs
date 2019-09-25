using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Lesson8_1
{
    //<? xml version="1.0" encoding="utf-8"?>
    //<MMWEATHER>
    //<REPORT type = "frc3" >
    //    < TOWN index="26935" sname="%D0%91%D0%B0%D1%80%D1%86%D0%B8%D0%BD" latitude="53" longitude="18">
    //	    <FORECAST day = "23" month="09" year="2019" hour="21" tod="3" predict="0" weekday="2">
    //			<PHENOMENA cloudiness = "0" precipitation="10" rpower="0" spower="0"/>
    //			<PRESSURE max = "762" min="761"/>
    //			<TEMPERATURE max = "17" min="9"/>
    //			<WIND min = "2" max="4" direction="3"/>
    //			<RELWET max = "87" min="67"/>
    //			<HEAT min = "7" max="7"/>
    //		</FORECAST>


    class Repository
    {


        static public void LoadData(ListBox ListBoxCitys, string PathDbOrUrl = "weather.xml", bool flag=true)
        {
            List<CityModel> temp = new List<CityModel>();

            string xmlFile = String.Empty;


            try
            {
                if (flag) xmlFile = File.ReadAllText(PathDbOrUrl);
                else xmlFile = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString(PathDbOrUrl);

                var db = XDocument.Parse(xmlFile)
                  .Descendants("MMWEATHER")
                  .Descendants("REPORT")
                  .Descendants("TOWN")
                  .Descendants("FORECAST").ToArray();

                foreach (var item in db)
                {
                    //Console.WriteLine(item);

                    temp.Add(new CityModel(
                        Name: "Город 1",
                        TemperatureMin: Convert.ToInt32(item.Element("TEMPERATURE").Attribute("min").Value),
                        TemperatureMax: Convert.ToInt32(item.Element("TEMPERATURE").Attribute("max").Value),
                        PressureMax: Convert.ToInt32(item.Element("PRESSURE").Attribute("max").Value),
                        PressureMin: Convert.ToInt32(item.Element("PRESSURE").Attribute("min").Value),
                        Date: new DateTime(
                            year: Convert.ToInt32(item.Attribute("year").Value),
                            month: Convert.ToInt32(item.Attribute("month").Value),
                            day: Convert.ToInt32(item.Attribute("day").Value),
                            hour: Convert.ToInt32(item.Attribute("hour").Value),
                            minute: 0,
                            second: 0
                            )
                        ));
                    //Console.WriteLine("\n ---- \n");
                }

                foreach (var e in temp)                
                    ListBoxCitys.Items.Add(e);                
            }
            catch (Exception f)
            {

                MessageBox.Show($"Ошибка чтения файла {f.Message} " + Environment.NewLine + f.StackTrace + Environment.NewLine + f.InnerException, "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Console.WriteLine(xmlFile);
        }
    }
}
