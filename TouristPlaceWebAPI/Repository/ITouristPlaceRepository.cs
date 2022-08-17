using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TouristPlaceWebAPI.Models;

namespace TouristPlaceWebAPI.Repository
{
    public interface ITouristPlaceRepository
    {
        Task<List<TouristPlaceModel>> GetAllPlaces();
        Task<int> AddToursitPlaceAsync(TouristPlaceModel touristPlace);
        Task<TouristPlaceModel> GetPlaceById(int placeId);
        Task UpdatePlaceAsycn(TouristPlaceModel model,int placeId);
        Task DeletePlace(int placeId);

    }
}