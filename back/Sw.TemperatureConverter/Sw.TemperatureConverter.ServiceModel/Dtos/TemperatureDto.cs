using Newtonsoft.Json;

namespace Sw.TemperatureConverter.ServiceModel.Dtos
{
    public class TemperatureDto
    {
        [JsonProperty("temperatureType")]
        public string TemperatureType { get; set; }

        [JsonProperty("temperatureValue")]
        public double TemperatureValue { get; set; }
    }
}
