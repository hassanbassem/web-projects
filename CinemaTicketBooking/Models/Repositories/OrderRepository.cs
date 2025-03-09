using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class OrderRepository : IRepository<Order, Guid>
    {
        private AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Order item)
        {
            _db.Orders.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Order? orderToDelete = await _db.Orders.FindAsync(id);

            if (orderToDelete != null)
                _db.Orders.Remove(orderToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Order?> GetItemAsync(Guid id)
        {
            return await _db.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfOrders = await _db.Orders.CountAsync();

            return await _db.Orders.Skip(itemsPerPage*pageNo)
                .Take(itemsPerPage * pageNo > numberOfOrders ? numberOfOrders - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Order oldOrder, Order newOrder)
        {
            //_db.Orders.Update(item);

            await _db.SaveChangesAsync();
        }
    }
}
