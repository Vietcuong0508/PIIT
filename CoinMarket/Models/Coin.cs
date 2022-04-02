using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoinMarket.Models
{
    public class Coin
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter coin name!")]
        public string Name { get; set; }
        [Required]
        public string BaseAsset { get; set; }
        [Required]
        public string QuoteAsset { get; set; }
        public double LastPrice { get; set; }
        [Required]
        public string Volumn24h { get; set; }
        public Market MarketId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}