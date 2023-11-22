using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class FollowedCar
    {
        public Guid Id { get; set; }
        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public Guid ClientId { get; set; }

        public Car Car { get; set; }

        public FollowedCar(Guid clientId, Guid carId)
        {
            ClientId = clientId;
            CarId = carId;
        }
    }
}
