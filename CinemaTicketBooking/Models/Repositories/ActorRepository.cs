using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class ActorRepository : IRepository<Actor, int>
    {
        private AppDbContext _db;

        public ActorRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Actor item)
        {
            _db.Actors.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Actor? actorToDelete = await _db.Actors.FindAsync(id);

            if (actorToDelete != null)
                _db.Actors.Remove(actorToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Actor?> GetItemAsync(int id)
        {
            return await _db.Actors.FindAsync(id);
        }

        public async Task<IEnumerable<Actor>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfActors = await _db.Actors.CountAsync();

            return await _db.Actors.Skip(itemsPerPage*pageNo)
                .Take(itemsPerPage * pageNo > numberOfActors ? numberOfActors - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Actor oldActor, Actor newActor)
        {
            //_db.Actors.Update(item);

            await _db.SaveChangesAsync();
        }
    }
}
