using Shouldly;
using Sw.TemperatureConverter.ServiceDxos;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using Sw.TemperatureConverter.ServiceModel.Queries.Products;
using Sw.TemperatureConverter.ServiceProduct;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sw.TemperatureConverter.UnitTests.Categories.Queries
{
    public class GetTemperaturesByMetricQueryHandlerTests
    {
        private readonly ITemperatureDxos _temperatureDxos;
        public GetTemperaturesByMetricQueryHandlerTests()
        {
            _temperatureDxos = new TemperatureDxos();
        }

        [Fact]
        public async Task Should_Return_List_Of_Temperature()
        {
            var handler = new GetTemperaturesByTypeHandler(_temperatureDxos);
            var result = await handler.Handle(new GetTemperaturesByTypeQuery("Celsius", 2), CancellationToken.None);

            result.ShouldBeOfType<List<TemperatureDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBeEquivalentTo(3);
        }

        [Theory]
        [InlineData(11.0, 51.8, 284.15)]
        [InlineData(32.00, 89.6, 305.15)]
        [InlineData(-14.0, 6.8, 259.15)]
        public async Task Passing_Celsius_Should_Return_Correct_Temperature_Metrics(double celsius, double fahrenheit, double kelvin)
        {
            var handler = new GetTemperaturesByTypeHandler(_temperatureDxos);
            var result = await handler.Handle(new GetTemperaturesByTypeQuery("Celsius", celsius), CancellationToken.None);

            result.ShouldBeOfType<List<TemperatureDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBeEquivalentTo(3);

            result.First(r => r.TemperatureType.Equals("Celsius")).TemperatureValue.ShouldBeEquivalentTo(celsius);
            result.First(r => r.TemperatureType.Equals("Fahrenheit")).TemperatureValue.ShouldBeEquivalentTo(fahrenheit);
            result.First(r => r.TemperatureType.Equals("Kelvin")).TemperatureValue.ShouldBeEquivalentTo(kelvin);
        }

        [Theory]
        [InlineData(21.0, -6.11, 267.04)]
        [InlineData(146, 63.33, 336.48)]
        [InlineData(-11, -23.89, 249.26)]
        public async Task Passing_Fahrenheit_Should_Return_Correct_Temperature_Metrics(double fahrenheit, double celsius, double kelvin)
        {
            var handler = new GetTemperaturesByTypeHandler(_temperatureDxos);
            var result = await handler.Handle(new GetTemperaturesByTypeQuery("Fahrenheit", fahrenheit), CancellationToken.None);

            result.ShouldBeOfType<List<TemperatureDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBeEquivalentTo(3);

            result.First(r => r.TemperatureType.Equals("Celsius")).TemperatureValue.ShouldBeEquivalentTo(celsius);
            result.First(r => r.TemperatureType.Equals("Fahrenheit")).TemperatureValue.ShouldBeEquivalentTo(fahrenheit);
            result.First(r => r.TemperatureType.Equals("Kelvin")).TemperatureValue.ShouldBeEquivalentTo(kelvin);
        }

        [Theory]
        [InlineData(314, 40.85, 105.53)]
        [InlineData(185, -88.15, -126.67)]
        [InlineData(-11, -284.15, -479.47)]
        public async Task Passing_Kelvin_Should_Return_Correct_Temperature_Metrics(double kelvin, double celsius, double fahrenheit)
        {
            var handler = new GetTemperaturesByTypeHandler(_temperatureDxos);
            var result = await handler.Handle(new GetTemperaturesByTypeQuery("Kelvin", kelvin), CancellationToken.None);

            result.ShouldBeOfType<List<TemperatureDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBeEquivalentTo(3);

            result.First(r => r.TemperatureType.Equals("Celsius")).TemperatureValue.ShouldBeEquivalentTo(celsius);
            result.First(r => r.TemperatureType.Equals("Fahrenheit")).TemperatureValue.ShouldBeEquivalentTo(fahrenheit);
            result.First(r => r.TemperatureType.Equals("Kelvin")).TemperatureValue.ShouldBeEquivalentTo(kelvin);
        }
    }
}
