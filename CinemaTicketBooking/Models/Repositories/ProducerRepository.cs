using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class ProducerRepository : IRepository<Producer, int>
    {
        private AppDbContext _db;

        public ProducerRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Producer item)
        {
            _db.Producers.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Producer? ProducerToDelete = await _db.Producers.FindAsync(id);

            if (ProducerToDelete != null)
                _db.Producers.Remove(ProducerToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Producer?> GetItemAsync(int id)
        {
            return await _db.Producers.FindAsync(id);
        }

        public async Task<IEnumerable<Producer>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfProducers = await _db.Producers.CountAsync();

            return await _db.Producers.Skip(itemsPerPage*pageNo)
                .Take(itemsPerPage * pageNo > numberOfProducers ? numberOfProducers - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Producer oldProducer, Producer newProducer)
        {
           // _db.Producers.Update(item);

            await _db.SaveChangesAsync();
        }
    }
}
