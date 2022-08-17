using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TouristPlaceWebAPI.Models
{
    public class TouristPlaceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Ratng must be between 1 and 5")]
        public int Rating { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Picture can't be blank")]
        public IFormFile Picture { get; set; }
        public string PictureUrl { get; set; }
    }
}
