namespace CinemaTicketBooking.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public string? PictureUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CinemaId { get; set; }
        public int ProducerId { get; set; }
        public virtual Cinema Cinema { get; set; } = null!;
        public virtual Producer Producer { get; set; } = null!;
        public virtual Picture Picture { get; set; } = null!;
        public virtual IEnumerable<Actor> Actors { get; set; } = new List<Actor>();
        public virtual IEnumerable<MovieOrder> MovieOrders { get; set; } = new List<MovieOrder>();
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public virtual IEnumerable<Cart> Carts { get; set; } = new List<Cart>();
        public virtual IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
