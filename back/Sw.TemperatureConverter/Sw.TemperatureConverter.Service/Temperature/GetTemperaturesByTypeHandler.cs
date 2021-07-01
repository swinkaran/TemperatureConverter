using MediatR;
using Sw.TemperatureConverter.DomainModels.Models;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using Sw.TemperatureConverter.ServiceModel.Queries.Products;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sw.TemperatureConverter.ServiceProduct
{
    public class GetTemperaturesByTypeHandler : IRequestHandler<GetTemperaturesByTypeQuery, IList<TemperatureDto>>
    {
        private readonly ITemperatureDxos _temperatureDxos;

        public GetTemperaturesByTypeHandler(ITemperatureDxos ProductDxos)
        {
            _temperatureDxos = ProductDxos ?? throw new ArgumentNullException(nameof(ProductDxos));
        }

        public async Task<IList<TemperatureDto>> Handle(GetTemperaturesByTypeQuery request, CancellationToken cancellationToken)
        {
            //handle the inputs
            var type = request.TemperatureType.ToLower();
            var value = request.TemperatureValue;

            Temperature metric;

            try
            {
                if (type.Equals(nameof(Celsius).ToLower()))
                {
                    metric = new Celsius(value);
                }
                else if (type.Equals(nameof(Fahrenheit).ToLower()))
                {
                    metric = new Fahrenheit(value);
                }
                else if (type.Equals(nameof(Kelvin).ToLower()))
                {
                    metric = new Kelvin(value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid temperature type in parameter");
                }

                var temperatures = GetTemperature(metric);
                if (temperatures != null)
                {
                    return temperatures;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error reading data from the server", e);
            }

            return null;
        }

        private IList<TemperatureDto> GetTemperature(Temperature metric)
        {
            return new List<TemperatureDto> {
                _temperatureDxos.MapTemperatureToCelsiusDto(metric),
                _temperatureDxos.MapTemperatureToFahrenheitDto(metric),
                _temperatureDxos.MapTemperatureToKelvinDto(metric)
            };
        }
    }

}
