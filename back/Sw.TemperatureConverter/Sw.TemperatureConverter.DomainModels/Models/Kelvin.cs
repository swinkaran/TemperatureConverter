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
            throw new NotImplementedException();
        }

        public override double ConvertToF()
        {
            throw new NotImplementedException();
        }

        public override double ConvertToK()
        {
            return kelvin * 1;
        }
    }
}
