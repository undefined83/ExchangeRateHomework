using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates.Libs.Models
{
    public class RateReport
    {
        public float MaxRate { get; set; }
        public string MaxDate { get; set; }
        public float MinRate { get; set; }
        public string MinDate { get; set; }
        public float AverageRate { get; set; }
    }
}
