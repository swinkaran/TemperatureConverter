using AutoMapper;
using Sw.TemperatureConverter.DomainModels.Models;
using Sw.TemperatureConverter.ServiceModel.Dtos;

namespace Sw.TemperatureConverter.ServiceDxos.Interfaces
{
    public interface ITemperatureDxos
    {
        TemperatureDto MapTemperatureToCelsiusDto(Temperature temperature);
        TemperatureDto MapTemperatureToFahrenheitDto(Temperature temperature);
        TemperatureDto MapTemperatureToKelvinDto(Temperature temperature);
    }
}
