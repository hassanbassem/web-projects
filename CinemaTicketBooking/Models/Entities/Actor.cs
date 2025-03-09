namespace CinemaTicketBooking.Models.Entities
{
    public class Actor: Artist
    {
        public virtual IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
