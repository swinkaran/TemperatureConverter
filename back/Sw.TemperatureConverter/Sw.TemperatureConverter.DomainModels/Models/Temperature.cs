using System;
using System.Collections.Generic;
using System.Text;

namespace Sw.TemperatureConverter.DomainModels.Models
{
    public abstract class Temperature
    {
        public abstract double ConvertToC();

        public abstract double ConvertToF();

        public abstract double ConvertToK();
    }

}
