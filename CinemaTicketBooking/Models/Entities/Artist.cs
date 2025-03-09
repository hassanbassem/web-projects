using CinemaTicketBooking.Models.Entities.Enums;

namespace CinemaTicketBooking.Models.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Bio { get; set; }
        public string? PictureUrl { get; set; }
        public Picture Picture { get; set; } = null!;
    }
}