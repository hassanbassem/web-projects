namespace CinemaTicketBooking.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual IEnumerable<Cart> CartInfo { get; set; } = new List<Cart>();
        public virtual IEnumerable<Movie> Movies { get; set; } = new List<Movie>();
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
