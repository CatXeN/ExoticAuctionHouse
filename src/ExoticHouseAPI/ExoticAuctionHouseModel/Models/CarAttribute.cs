using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoticAuctionHouseModel.Models
{
    public class CarAttribute
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Attribute")]
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }

        public CarAttribute()
        {
            
        }

        public CarAttribute(Guid attributeId, Guid carId)
        {
            Id = Guid.NewGuid();
            AttributeId = attributeId;
            CarId = carId;
        }
    }
}
