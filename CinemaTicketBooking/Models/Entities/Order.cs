namespace CinemaTicketBooking.Models.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        public virtual IEnumerable<MovieOrder> MovieOrderInfo { get; set; } = new List<MovieOrder>();
    }
}
