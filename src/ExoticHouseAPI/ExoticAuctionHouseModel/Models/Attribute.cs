using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class Attribute
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Value { get; set; }
    }
}
