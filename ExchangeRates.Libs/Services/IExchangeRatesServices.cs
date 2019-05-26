using ExchangeRates.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Libs.Services
{
    public interface IExchangeRatesServices
    {
        Task<RateReport> GetExhangeRateData(RequestedRates request);
    }
}
