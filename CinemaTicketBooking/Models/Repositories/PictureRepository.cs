using CinemaTicketBooking.Models.Data;
using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicketBooking.Models.Repositories
{
    public class PictureRepository : IRepository<Picture, string>
    {
        private AppDbContext _db;

        public PictureRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Picture item)
        {
            _db.Picture.Add(item);

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Picture? pictureToDelete = await _db.Picture.FindAsync(id);

            if (pictureToDelete != null)
                _db.Picture.Remove(pictureToDelete);

            await _db.SaveChangesAsync();
        }

        public async Task<Picture?> GetItemAsync(string id)
        {
            return await _db.Picture.FindAsync(id);
        }

        public async Task<IEnumerable<Picture>> GetPage(int itemsPerPage, int pageNo)
        {
            int numberOfPictures = await _db.Picture.CountAsync();

            return await _db.Picture.Skip(itemsPerPage * (pageNo - 1))
                .Take(itemsPerPage * pageNo > numberOfPictures ? numberOfPictures - itemsPerPage * (pageNo - 1) : itemsPerPage)
                .ToListAsync();
        }

        public async Task UpdateAsync(Picture oldItem, Picture newItem)
        {
            oldItem.UniqueName = newItem.UniqueName;
            oldItem.FilenameAtClient = newItem.FilenameAtClient;

            await _db.SaveChangesAsync();
        }
    }
}
