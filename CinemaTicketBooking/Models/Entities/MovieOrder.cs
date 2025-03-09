namespace CinemaTicketBooking.Models.Entities
{
    public class MovieOrder
    {
        public Guid OrderId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
