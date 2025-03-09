namespace CinemaTicketBooking.Models.Entities
{
    public class Producer: Artist
    {
        public virtual IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
    }
}
