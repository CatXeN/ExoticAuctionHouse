using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class AuctionHistory
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

        public DateTime SoldAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public Guid? UserId { get; set; }
    }
}
