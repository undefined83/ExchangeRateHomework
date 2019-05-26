using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExchangeRates.Libs.Models
{
    [DataContract]
    public class ExchangeRatesModel
    {
        [DataMember(Name = "start_at")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "end_at")]
        public DateTime EndDate { get; set; }

        [DataMember(Name = "base")]
        public string SourceCurrency { get; set; }

        [DataMember(Name = "rates")]
        public Dictionary<DateTime, Dictionary<string, float>> RatesList;

    }
}
