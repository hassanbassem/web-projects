namespace CinemaTicketBooking.Models.Entities
{
    public class Cart
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Amount { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
