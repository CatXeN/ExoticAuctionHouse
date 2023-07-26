using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Informations
{
    public class AuctionInformation
    {
        public Guid CarId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BiddingBegins { get; set; }
        public decimal AmountStarting { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Location { get; set; }
    }
}
