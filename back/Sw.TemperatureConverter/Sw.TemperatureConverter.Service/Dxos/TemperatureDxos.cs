using AutoMapper;
using Sw.TemperatureConverter.DomainModels.Models;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using System;

namespace Sw.TemperatureConverter.ServiceDxos
{
    public class TemperatureDxos : ITemperatureDxos
    {
        private readonly IMapper _celsiusMapper;
        private readonly IMapper _fahrenheitMapper;
        private readonly IMapper _kelvinMapper;

        public TemperatureDxos()
        {
            _celsiusMapper = CreateCelsiusMappings().CreateMapper();
            _fahrenheitMapper = CreateFahrenheitMappings().CreateMapper();
            _kelvinMapper = CreateKelvinMappings().CreateMapper();
        }

        private MapperConfiguration CreateCelsiusMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Temperature, TemperatureDto>()
                .ForMember(dst => dst.TemperatureType, opt => opt.Ignore())
                .ForMember(dst => dst.TemperatureValue, opt => opt.MapFrom(src => Math.Round(src.ConvertToC(), 2)))
                .AfterMap((Temperature, dst) => { dst.TemperatureType = "Celsius"; });
            });
        }
        private MapperConfiguration CreateFahrenheitMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Temperature, TemperatureDto>()
                .ForMember(dst => dst.TemperatureType, opt => opt.Ignore())
                .ForMember(dst => dst.TemperatureValue, opt => opt.MapFrom(src => Math.Round(src.ConvertToF(), 2)))
                .AfterMap((Temperature, dst) => { dst.TemperatureType = "Fahrenheit"; });
            });
        }
        private MapperConfiguration CreateKelvinMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Temperature, TemperatureDto>()
                .ForMember(dst => dst.TemperatureType, opt => opt.Ignore())
                .ForMember(dst => dst.TemperatureValue, opt => opt.MapFrom(src => Math.Round(src.ConvertToK(), 2)))
                .AfterMap((Temperature, dst) => { dst.TemperatureType = "Kelvin"; });
            });
        }

        public TemperatureDto MapTemperatureToCelsiusDto(Temperature temperature)
            => _celsiusMapper.Map<Temperature, TemperatureDto>(temperature);

        public TemperatureDto MapTemperatureToFahrenheitDto(Temperature temperature)
            => _fahrenheitMapper.Map<Temperature, TemperatureDto>(temperature);

        public TemperatureDto MapTemperatureToKelvinDto(Temperature temperature)
            => _kelvinMapper.Map<Temperature, TemperatureDto>(temperature);
    }
}
