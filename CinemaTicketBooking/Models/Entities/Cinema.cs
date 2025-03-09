using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CinemaTicketBooking.Models.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field is required")]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public virtual IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        public virtual Picture? Picture { get; set; }
    }
}