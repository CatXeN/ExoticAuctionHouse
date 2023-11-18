using ExoticAuctionHouseModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Informations
{
    public class SellCarInformation
    {
        public AddCarInformation Car { get; set; }
        public AuctionInformation Auction { get; set; }
        public AddCarAttributeInformation AddCarAttributeInformation { get; set; }
    }
}
