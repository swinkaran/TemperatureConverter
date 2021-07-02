using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sw.TemperatureConverter.Api.Controllers.Infrastructure;
using Sw.TemperatureConverter.ServiceModel.Dtos;
using Sw.TemperatureConverter.ServiceModel.Queries.Products;

namespace Sw.TemperatureConverter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ApiControllerBase
    {
        private readonly ILogger<TemperatureController> logger;

        public TemperatureController(IMediator mediator, ILogger<TemperatureController> logger) : base(mediator)
        {
            this.logger = logger;
        }

        [HttpGet("{temperatureType}/{temperatureValue}")]
        [HttpGet("all", Name = "GetTemperatureByType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TemperatureDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<TemperatureDto>>> GetTemperatureByType(string temperatureType, double temperatureValue)
        {
            if (temperatureType == null)
                return StatusCode(StatusCodes.Status400BadRequest, "Provided product Id is null");

            try
            {
                var dtos = await QueryAsync(new GetTemperaturesByTypeQuery(temperatureType, temperatureValue));

                if (dtos == null)
                {
                    logger.LogWarning("Cannot find temperatures for provided input : {0} - {1}", temperatureType, temperatureValue);
                    return StatusCode(StatusCodes.Status204NoContent, "Cannot find temperatures for provided input");
                }
                return Ok(dtos);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
