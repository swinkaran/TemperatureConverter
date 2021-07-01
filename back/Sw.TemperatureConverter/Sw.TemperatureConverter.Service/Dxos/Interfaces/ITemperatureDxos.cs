using AutoMapper;
using Sw.TemperatureConverter.DomainModels.Models;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using System.Collections.Generic;

namespace Sw.TemperatureConverter.ServiceDxos.Interfaces
{
    public interface ITemperatureDxos
    {
        MapperConfiguration CreateMappings();
        TemperatureDto MapTemperatureDto(Temperature Product);
        IList<TemperatureDto> MapTemperatureDtos(IList<Temperature> Product);
    }
}
