using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExchangeRates.Libs.Models;
using ExchangeRates.Libs.ExchangeRates;

namespace ExchangeRates.Libs.Services
{
    public class ExchangeRatesServices : IExchangeRatesServices
    {
        private static IGetExchangeRates _getExchangeRates;

        public ExchangeRatesServices(IGetExchangeRates getExchangeRates)
        {
            _getExchangeRates = getExchangeRates;
        }

        public async Task<RateReport> GetExhangeRateData(RequestedRates request)
        {
            return await _getExchangeRates.ReturnExchangeRateReport(request);
        }
    }
}
