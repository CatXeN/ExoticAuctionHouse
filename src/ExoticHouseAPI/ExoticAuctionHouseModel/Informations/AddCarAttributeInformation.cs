using ExoticAuctionHouseModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Informations
{
    public class AddCarAttributeInformation
    {
        public string Attributes { get; set; }
        public Guid CarId { get; set; }
    }
}
