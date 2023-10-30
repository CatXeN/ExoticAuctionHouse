using ExoticAuctionHouse_API.Repositories;
using ExoticAuctionHouseModel.Enums;
using ExoticAuctionHouseModel.Informations;
using ExoticAuctionHouseModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoticAuctionHouse_API.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _repository;
        private readonly IAuctionHistoryRepository _historyRepository;

        public AuctionService(IAuctionRepository repository, IAuctionHistoryRepository historyRepository)
        {
            _repository = repository;
            _historyRepository = historyRepository;
        }

        public async Task EndAuctions(AuctionHistoryInformation[] auctionHistoryInformation)
        {
            var auctionsIds = auctionHistoryInformation.Select(a => a.Id).ToArray();
            await _repository.End(auctionsIds);

            var auctionsHistory = auctionHistoryInformation.Select(ah => new AuctionHistory()
            {
                Id = ah.Id,
                CarId = ah.CarId,
                IsSold = false,
                Price = ah.Price,
                SoldAt = ah.SoldAt,
                UserId = ah.UserId,
            }).ToArray();
            await _historyRepository.Add(auctionsHistory);
        }

        public async Task<IEnumerable<Auction>> GetCarsByFilter(SearchModel searchModel)
        {
            var cars = _repository.GetAuctionWithCarsQuerable(searchModel.Brand);

            if (!string.IsNullOrEmpty(searchModel.Brand))
                cars = cars.Where(car => car.Car.Brand == searchModel.Brand);

            if (!string.IsNullOrEmpty(searchModel.Model))
                cars = cars.Where(car => car.Car.Model == searchModel.Model);

            if (searchModel.BodyType != BodyType.All)
                cars = cars.Where(car => car.Car.BodyType == searchModel.BodyType);

            if (searchModel.FuelType != FuelType.All)
                cars = cars.Where(car => car.Car.FuelType == searchModel.FuelType);


            return await cars.ToListAsync();
        }
    }
}
