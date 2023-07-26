using ExoticAuctionHouseModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Informations
{
    public class SearchModel
    {
        public string Brand { get; set; }
        public string? Model { get; set; }
        public FuelType FuelType { get; set; }
        public BodyType BodyType { get; set; }
    }
}
