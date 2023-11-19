namespace ExoticAuctionHouse_API.Data
{
    public static class SeedAttributes
    {
        public static List<ExoticAuctionHouseModel.Models.Attribute> GetAttributes()
        {
            var attributes = new List<ExoticAuctionHouseModel.Models.Attribute>
            {
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "Apple CarPlay"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "Android Auto"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "Interface Bluetooth"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "Radio"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "USB socket"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "HIFI speaker"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Audio and multimedia",
                    Value = "Touchscreen"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Automatic air conditioning"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Leather seats"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Heated seats"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Leather steering wheel"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Multifunction steering wheel"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Comfort and accessories",
                    Value = "Electrict windows"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Headlights with LED technology"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Park assistant"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Heated side mirror"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "ESP"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Daytime running lights"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Fog lamps"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "System start/stop"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Driver assistance system",
                    Value = "Power steering"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Security",
                    Value = "ABS"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Security",
                    Value = "ESP"
                },
                new ExoticAuctionHouseModel.Models.Attribute()
                {
                    Id = Guid.NewGuid(),
                    Category = "Security",
                    Value = "Isofix"
                },
            };

            return attributes;
        }
    }
}
