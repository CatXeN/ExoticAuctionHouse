using ExoticAuctionHouse_API.Helpers;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;

namespace ExoticAuctionHouse_API.Services
{
    public class CarService : ICarService
    {
        public CarPageData GetCarPageData()
        {
            CarPageData carPageData = new CarPageData
            {
                BodyTypes = EnumHelper.ExtractValues<BodyType>(),
                FuelTypes = EnumHelper.ExtractValues<FuelType>()
            };

            return carPageData;
        }
    }
}
