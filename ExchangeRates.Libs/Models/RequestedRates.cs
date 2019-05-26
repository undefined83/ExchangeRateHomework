using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExchangeRates.Libs.Models
{
    public class RequestedRates
    {
        [Required]
        public IList<DateTime> DatesList { get; set; }
        
        [Required(ErrorMessage = "Source currency is required."), StringLength(5), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Not a valid currency!")]
        public string SourceCurrency { get; set; }

        [Required(ErrorMessage = "Destination currency is required."), StringLength(5), RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Not a valid currency!")]
        public string DestinationCurrency { get; set; }

    }
}
