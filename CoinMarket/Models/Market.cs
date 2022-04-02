using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoinMarket.Models
{
    public class Market
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter market name")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Status { get; set; }
    }
}