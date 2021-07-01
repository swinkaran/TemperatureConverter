
using Shouldly;
using Sw.TemperatureConverter.ServiceDxos;
using Sw.TemperatureConverter.ServiceDxos.Interfaces;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using Sw.TemperatureConverter.ServiceModel.Queries.Products;
using Sw.TemperatureConverter.ServiceProduct;
using System.Collections.Generic;
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

        [Fact]
        public async Task Passing_Celsius_Should_Return_Correct_Temperature_Metrics()
        {
            var handler = new GetTemperaturesByTypeHandler(_temperatureDxos);
            var result = await handler.Handle(new GetTemperaturesByTypeQuery("Celsius", 2), CancellationToken.None);

            result.ShouldBeOfType<List<TemperatureDto>>();
            result.ShouldNotBeNull();
            result.Count.ShouldBeEquivalentTo(3);
        }
    }
}
