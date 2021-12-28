using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped,Required]
        public IFormFile Photo { get; set; }
    }
}
