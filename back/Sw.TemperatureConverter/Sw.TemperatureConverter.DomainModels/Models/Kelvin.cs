using System;
using System.Collections.Generic;
using System.Text;

namespace Sw.TemperatureConverter.DomainModels.Models
{
    public class Kelvin : Temperature
    {
        private double kelvin;

        public Kelvin(double _kelvin)
        {
            kelvin = _kelvin;
        }

        public override double ConvertToC()
        {
            return kelvin - 273.15;
        }

        public override double ConvertToF()
        {
            return (ConvertToC() * 9) / 5 + 32;
        }

        public override double ConvertToK()
        {
            return kelvin;
        }
    }
}
