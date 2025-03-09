using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class UserRepository : IRepository<User, int>
    {
        private AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(User item)
        {
            _db.Users.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            User? userToDelete = await _db.Users.FindAsync(id);

            if (userToDelete != null)
                _db.Users.Remove(userToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<User?> GetItemAsync(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfUsers = await _db.Movies.CountAsync();

            return await _db.Users.Skip(itemsPerPage*pageNo)
                .Take(itemsPerPage * pageNo > numberOfUsers ? numberOfUsers - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(User oldUser, User newUser)
        {
           // _db.Users.Update(item);

            await _db.SaveChangesAsync();
        }
    } 
}
