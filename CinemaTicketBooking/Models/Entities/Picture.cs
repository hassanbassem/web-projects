namespace CinemaTicketBooking.Models.Entities
{
    public class Picture
    {
        public string UniqueName { get; set; } = null!;
        public string FilenameAtClient { get; set; } = null!;
        public Artist Artist { get; set; } = null!;
        public Cinema Cinema { get; set; } = null!;
        public Movie Movie { get; set; } = null!;
    }
}
