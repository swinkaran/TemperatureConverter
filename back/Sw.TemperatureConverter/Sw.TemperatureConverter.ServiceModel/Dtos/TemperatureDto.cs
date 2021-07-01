using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Sw.TemperatureConverter.ServiceModel.Dtos
{

    public class TemperaturesDto
    {
        [JsonProperty("temperatureValue")]
        List<TemperatureDto> Temperatures { get; set; }
    }

    public class TemperatureDto
    {
        [JsonProperty("temperatureType")]
        public string TemperatureType { get; set; }

        [JsonProperty("temperatureValue")]
        public double TemperatureValue { get; set; }
    }
}
