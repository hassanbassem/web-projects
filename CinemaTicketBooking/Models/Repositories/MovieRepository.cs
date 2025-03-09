using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class MovieRepository : IRepository<Movie, int>
    {
        private AppDbContext _db;

        public MovieRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Movie item)
        {
            _db.Movies.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Movie? movieToDelete = await _db.Movies.FindAsync(id);

            if (movieToDelete != null)
                _db.Movies.Remove(movieToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Movie?> GetItemAsync(int id)
        {
            return await _db.Movies.Include(m => m.Cinema).Include(m => m.Producer).Include(m => m.Actors).SingleAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfMovies = await _db.Movies.CountAsync();

            return await _db.Movies.Include(m => m.Cinema).Skip(itemsPerPage*(pageNo-1))
                .Take(itemsPerPage * pageNo > numberOfMovies? numberOfMovies - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Movie oldMovie, Movie mewMovie)
        {
           // _db.Movies.Update(item);

            await _db.SaveChangesAsync();
        }
    }
}
