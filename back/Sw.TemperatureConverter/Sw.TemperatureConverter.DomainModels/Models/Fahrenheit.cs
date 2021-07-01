using System;
using System.Collections.Generic;
using System.Text;

namespace Sw.TemperatureConverter.DomainModels.Models
{
    public class Fahrenheit : Temperature
    {
        private double fahrenheit;

        public Fahrenheit(double _fahrenheit)
        {
            fahrenheit = _fahrenheit;
        }

        public override double ConvertToC()
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public override double ConvertToF()
        {
            return fahrenheit * 1;
        }

        public override double ConvertToK()
        {
            return 0.00;
        }
    }
}
