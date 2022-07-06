using DiffApi.Helpers.Data;
using DiffApi.Helpers.Validation;
using DiffApi.Interfaces;
using DiffApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DiffApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ApiControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public HomeController(IDataService dataService) : base(dataService)
        {

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //Endpoint to put values to left side
        [HttpPut("v1/diff/{id}/left")]
        public async Task<IActionResult> PutLeftData(string id, [FromBody] EncodedBase64Data encodedData)
        {
            if (encodedData.getBase64Data() == null)
                return BadRequest(false);
            var result = await DataService.Home.AddLeft(id, encodedData.getBase64Data());
            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        //Endpoint to put values to right side
        [HttpPut("v1/diff/{id}/right")]
        public async Task<IActionResult> PutRightData(string id, [FromBody] EncodedBase64Data encodedData)
        {
            if (encodedData.getBase64Data() == null)
                return BadRequest(false);
            var result = await DataService.Home.AddRight(id, encodedData.getBase64Data());
            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }


        //Endpoint to put values to compare the left and the right side
        [HttpGet("v1/diff/{id}")]
        public async Task<IActionResult> GetData(string id)
        {
            IResponseData<Result> response = new ResponseData<Result>();
            try
            {
                DiffResult responseData = await DataService.Home.GetData(id);
                Result responseResult = null;
                if (responseData.equals && responseData.equalSize)
                {
                    responseResult = new Result {diffResultType = "Equals" };
                }
                else if(!responseData.equals && responseData.equalSize)
                {
                    responseResult = new Result { diffResultType = "ContentDoNotMatch", differences = responseData.differences };
                }
                else if(!responseData.equals && !responseData.equalSize && responseData.differences.Count == 0 && responseData.hasBothdata)
                {
                    responseResult = new Result { diffResultType = "SizeDoNotMatch"};
                }
                if(responseResult == null)
                {
                  return new ObjectResult(false) { StatusCode = StatusCodes.Status404NotFound };
                }
                else
                { 
                response.SetData(responseResult);
                response.SetStatus(HttpStatusCode.OK);
                }
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(HttpStatusCode.PreconditionFailed);

            }
            return Ok(response);
        }

    }
}
