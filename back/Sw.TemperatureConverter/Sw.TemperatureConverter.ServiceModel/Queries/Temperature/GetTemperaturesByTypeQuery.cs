using Newtonsoft.Json;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sw.TemperatureConverter.ServiceModel.Queries.Products
{
    public class GetTemperaturesByTypeQuery : QueryBase<IList<TemperatureDto>>
    {
        [JsonConstructor]
        public GetTemperaturesByTypeQuery(string temperatureType, double temperatureValue)
        {
            TemperatureType = temperatureType;
            TemperatureValue = temperatureValue;
        }

        [JsonProperty("temperatureType")]
        [Required]
        public string TemperatureType { get; set; }

        [JsonProperty("temperatureValue")]
        [Required]
        public double TemperatureValue { get; set; }
    }
}
