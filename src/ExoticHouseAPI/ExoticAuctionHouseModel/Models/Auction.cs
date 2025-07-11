﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class Auction
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime BiddingBegins { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountStarting { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentPrice { get; set; }
        public string Location { get; set; }
        public bool IsEnd { get; set; }
    }
}
