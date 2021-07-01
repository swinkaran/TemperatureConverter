using System;
using System.Collections.Generic;
using System.Text;

namespace Sw.TemperatureConverter.DomainModels.Models
{
    public class Celsius : Temperature
    {
        private double celsius;

        public Celsius(double _celsius)
        {
            celsius = _celsius;
        }

        public override double ConvertToC()
        {
            return celsius * 1;
        }

        public override double ConvertToF()
        {
            return (celsius * 9) / 5 + 32;
        }

        public override double ConvertToK()
        {
            return celsius + 273.15;
        }
    }
}
