using ExoticAuctionHouseModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Informations
{
    public class AddCarInformation
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public FuelType FuelType { get; set; }
        public int Capacity { get; set; }
        public int Horsepower { get; set; }
        public int Mileage { get; set; }
        public BodyType BodyType { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}
