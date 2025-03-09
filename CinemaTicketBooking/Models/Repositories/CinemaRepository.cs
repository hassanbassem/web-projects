using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class CinemaRepository : IRepository<Cinema, int>
    {
        private AppDbContext _db;

        public CinemaRepository(AppDbContext db, IFileLoader loader)
        {
            _db = db;
        }

        public async Task AddAsync(Cinema item)
        {
            _db.Cinemas.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Cinema? cinemaToDelete = await _db.Cinemas.FindAsync(id);

            if (cinemaToDelete != null)
                _db.Cinemas.Remove(cinemaToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Cinema?> GetItemAsync(int id)
        {
            return await _db.Cinemas.Include(c => c.Picture).SingleAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cinema>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfCinemas = await _db.Cinemas.Include(c => c.Picture).CountAsync();

            return await _db.Cinemas.Include(c => c.Picture).Skip(itemsPerPage*(pageNo - 1))
                .Take(itemsPerPage * pageNo > numberOfCinemas ? numberOfCinemas - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Cinema oldCinema, Cinema newCinema)
        {
            oldCinema.Name = newCinema.Name;
            oldCinema.Description = newCinema.Description;
            oldCinema.Picture = newCinema.Picture;

            await _db.SaveChangesAsync();
        }
    }
}
