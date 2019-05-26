using ExchangeRates.Libs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Linq;

namespace ExchangeRates.Libs.ExchangeRates
{
    public class GetExchangeRates: IGetExchangeRates
    {
        public async Task<Dictionary<DateTime,float>> ReturnExchangeRateData(IEnumerable<DateTime> dateList, string sourceCurrency, string destinationCurrency)
        {
            Dictionary<DateTime, float> ratesDate = new Dictionary<DateTime, float>();
            using (var client = new HttpClient())
            {
                string startDate = "";
                string endDate = "";

                foreach (DateTime date in dateList)
                {
                    startDate = date.AddDays(-1).ToString("yyyy-MM-dd");
                    endDate = date.ToString("yyyy-MM-dd");

                    var url = new Uri($"https://api.exchangeratesapi.io/history?start_at={startDate}&end_at={endDate}&base={sourceCurrency}&symbols={destinationCurrency}");

                    string json="";
                    try
                    {
                        var response = await client.GetAsync(url);

                        using (var content = response.Content)
                        {
                            json = await content.ReadAsStringAsync();
                        }
                    }
                    catch (Exception) { }

                    if (!string.IsNullOrEmpty(json))
                    {
                        ExchangeRatesModel oneRate = JsonConvert.DeserializeObject<ExchangeRatesModel>(json);
                        if (oneRate != null && oneRate.RatesList != null && oneRate.RatesList.ContainsKey(date))
                        {
                            float singleRate = oneRate.RatesList[date][destinationCurrency];
                            ratesDate.Add(date, singleRate);
                        }
                    }                    
                }                
            }

            return ratesDate;
        }

        public async Task<RateReport> ReturnExchangeRateReport(RequestedRates request)
        {
            string sourceCurrency = request.SourceCurrency;
            string destinationCurrency = request.DestinationCurrency;
            IEnumerable<DateTime> datesList = request.DatesList;

            Dictionary<DateTime, float> ratesData = await ReturnExchangeRateData(datesList, sourceCurrency, destinationCurrency);

            if (ratesData!=null)
            {
                var results = GenerateReport(ratesData);
                return results;
            }            

            return new RateReport();
        }

        private RateReport GenerateReport(Dictionary<DateTime, float> ratesData)
        {
            float maxRate= 0.0f;
            DateTime maxDate = new DateTime();
            float minRate = 0.0f;
            DateTime minDate = new DateTime(); 
            float avgRate = 0.0f;

            if (ratesData.Count>1)
            {
                maxRate = ratesData.Values.Max();
                maxDate = ratesData.FirstOrDefault(x => x.Value == ratesData.Values.Max()).Key;
                minRate = ratesData.Values.Min();
                minDate = ratesData.FirstOrDefault(x => x.Value == ratesData.Values.Min()).Key;
                avgRate = ratesData.Values.Average();
            }

            return new RateReport() {
                MaxRate = maxRate,
                MaxDate = maxDate.ToString("yyyy-MM-dd"),
                MinRate = minRate,
                MinDate = minDate.ToString("yyyy-MM-dd"),
                AverageRate = avgRate };
        }
    }
}

