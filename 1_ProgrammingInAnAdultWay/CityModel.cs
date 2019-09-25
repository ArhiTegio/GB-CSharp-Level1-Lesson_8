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

        public CityModel(string Name, DateTime Date, int PressureMax, int PressureMin, int TemperatureMax, int TemperatureMin)
        {
            this.Name = Name;
            this.Date = Date;
            this.PressureMax = PressureMax;
            this.PressureMin = PressureMin;
            this.TemperatureMax = TemperatureMax;
            this.TemperatureMin = TemperatureMin;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PressureMax { get; set; }
        public int PressureMin { get; set; }
        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }

        public override string ToString()
        {
            return $"{Date}";
        }

    }
}
