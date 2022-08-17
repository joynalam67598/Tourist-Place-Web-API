using AutoMapper;
using TouristPlaceWebAPI.Data;
using TouristPlaceWebAPI.Models;

namespace TouristPlaceWebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<ToursitPlaces, TouristPlaceModel>().ReverseMap();
        }
    }
}
