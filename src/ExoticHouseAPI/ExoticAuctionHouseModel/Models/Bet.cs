using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Guid AuctionId { get; set; }
        public Guid CarId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentPrice { get; set; }
        public Guid LastUserId { get; set; }
        public DateTimeOffset LastTime { get; set; }
    }
}
