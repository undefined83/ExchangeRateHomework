using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExchangeRates.Libs.Services;
using ExchangeRates.Libs.Models;

namespace ExchangeRates.Api.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly IExchangeRatesServices _exchangeRateServices;

        public ExchangeRateController(IExchangeRatesServices exchangeRatesServices)
        {
            _exchangeRateServices = exchangeRatesServices;
        }

        [HttpGet]
        [Route("v1/getRates")]
        public async Task<IActionResult> GetExchangeRateData([FromBody]RequestedRates requestedRates)
        {
            if (ModelState.IsValid && requestedRates.DatesList != null && requestedRates.DatesList.Count > 0)
            {
                var result = await _exchangeRateServices.GetExhangeRateData(requestedRates);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }
}