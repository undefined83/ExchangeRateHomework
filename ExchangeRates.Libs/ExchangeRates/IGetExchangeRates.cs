using ExchangeRates.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Libs.ExchangeRates
{
    public interface IGetExchangeRates
    {
        Task<Dictionary<DateTime,float>> ReturnExchangeRateData(IEnumerable<DateTime> dateList, string sourceCurrency, string destinationCurrency);
        Task<RateReport> ReturnExchangeRateReport(RequestedRates request);
    }
}
