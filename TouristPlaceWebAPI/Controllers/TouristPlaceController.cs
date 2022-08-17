using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using TouristPlaceWebAPI.Models;
using TouristPlaceWebAPI.Repository;

namespace TouristPlaceWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TouristPlaceController : ControllerBase
    {
        private readonly ITouristPlaceRepository _touristPlaceRepository;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public TouristPlaceController(ITouristPlaceRepository touristPlaceRepository, IWebHostEnvironment webHostEnvironment)
        {
            _touristPlaceRepository = touristPlaceRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetTouristPlaces()
        {
            var places = await _touristPlaceRepository.GetAllPlaces();
            return Ok(places);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTouristPlace([FromForm] TouristPlaceModel touristPlace)
        {
            string imgPath = "images/place/";
            touristPlace.PictureUrl = await GetImageUrl(imgPath, touristPlace.Picture);

            var newPlaceId = await _touristPlaceRepository.AddToursitPlaceAsync(touristPlace);
            return CreatedAtAction(nameof(GetTouristPlaceById),new {id = newPlaceId, controller= "TouristPlace" }, newPlaceId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTouristPlace([FromForm] TouristPlaceModel touristPlace, [FromRoute]int id)
        {
            await _touristPlaceRepository.UpdatePlaceAsycn(touristPlace, id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTouristPlaceById([FromRoute] int id)
        {
            var touristPlace = await _touristPlaceRepository.GetPlaceById(id);
            if(touristPlace == null)
            {
                return NotFound();
            }
            return Ok(touristPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTouristPlace([FromRoute] int id)
        {
            await _touristPlaceRepository.DeletePlace(id);
            return Ok();
        }

        private async Task<string> GetImageUrl(string imgPath, IFormFile img)
        {
            imgPath += Guid.NewGuid().ToString() + "_" + img.Name;
            var serverPath = Path.Combine(_webHostEnvironment.WebRootPath, imgPath);
            await img.CopyToAsync(new FileStream(serverPath, FileMode.Create));
            return "/" + imgPath;

        }
    }
}
