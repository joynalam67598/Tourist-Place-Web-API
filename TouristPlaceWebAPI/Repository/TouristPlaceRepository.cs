using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouristPlaceWebAPI.Data;
using TouristPlaceWebAPI.Models;

namespace TouristPlaceWebAPI.Repository
{
    public class TouristPlaceRepository : ITouristPlaceRepository
    {

        private readonly TouristPlaceContext _touristPlaceContext;
        private readonly IMapper _mapper;

        public TouristPlaceRepository(TouristPlaceContext touristPlaceContext, IMapper mapper)
        {
            _touristPlaceContext = touristPlaceContext;
            _mapper = mapper;
        }

        public async Task<List<TouristPlaceModel>> GetAllPlaces()
        {
            var places = await _touristPlaceContext.ToursitPlaces.ToListAsync();
            return _mapper.Map<List<TouristPlaceModel>>(places);

        }

        public async Task<int> AddToursitPlaceAsync(TouristPlaceModel touristPlace)
        {
            var newPlace = new ToursitPlaces()
            {
                Name = touristPlace.Name,
                Address = touristPlace.Address,
                PictureUrl = touristPlace.PictureUrl,
                Rating = touristPlace.Rating,
                Type = touristPlace.Type,
            };

            _touristPlaceContext.ToursitPlaces.Add(newPlace);
            await _touristPlaceContext.SaveChangesAsync();

            return newPlace.Id;
        }

        public async Task<TouristPlaceModel> GetPlaceById(int placeId)
        {
            var place = await _touristPlaceContext.ToursitPlaces.FindAsync(placeId);
            return _mapper.Map<TouristPlaceModel>(place);

        }

        public async Task UpdatePlaceAsycn(TouristPlaceModel touristPlace, int placeId)
        {            
            var place = new ToursitPlaces()
            {
                Id = touristPlace.Id,
                Name = touristPlace.Name,
                Address = touristPlace.Address,
                PictureUrl = touristPlace.PictureUrl,
                Rating = touristPlace.Rating,
                Type = touristPlace.Type,
            };

            _touristPlaceContext.Update(place);
            await _touristPlaceContext.SaveChangesAsync();
        }

        public async Task DeletePlace(int placeId)
        {
            var place = await _touristPlaceContext.ToursitPlaces.FindAsync(placeId);
            _touristPlaceContext.ToursitPlaces.Remove(place);
            await _touristPlaceContext.SaveChangesAsync();
        }
        
    }
}
