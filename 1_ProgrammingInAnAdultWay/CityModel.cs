using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_1
{
    [Serializable]
    public class CityModel
    {
        public CityModel( )
        {

        }

        public CityModel(string Name, DateTime Date, int PressureMax, int PressureMin, int TemperatureMax, int TemperatureMin, Сloudiness СloudinessWeather, Precipitation PrecipitationWeather)
        {
            this.Name = Name;
            this.Date = Date;
            this.PressureMax = PressureMax;
            this.PressureMin = PressureMin;
            this.TemperatureMax = TemperatureMax;
            this.TemperatureMin = TemperatureMin;
            this.TemperatureMin = TemperatureMin;
            this.СloudinessWeather = СloudinessWeather;
            this.PrecipitationWeather = PrecipitationWeather;
            //this.RelWet = RelWet;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PressureMax { get; set; }
        public int PressureMin { get; set; }
        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }
        public Сloudiness СloudinessWeather { get; set; }
        public Precipitation PrecipitationWeather { get; set; }
        //public int RelWet { get; set; }

        public override string ToString()
        {
            return $"{Date}";
        }

    }

    public enum Сloudiness
    {
        туман = - 1,
        ясно = 0,
        малооблачно = 1,
        облачно = 2,
        пасмурно = 3,
    }

    public enum Precipitation
    {
        смешанные = 3,
        дождь = 4,
        ливень = 5,
        снег = 6,
        сильный_снег = 7,
        гроза = 8,
        нет_данных = 9,
        без_осадков = 10,
    }
}
