namespace CinemaTicketBooking.Models.Repositories
{
    public interface IRepository<T, I>
    {
        Task AddAsync(T item);

        Task UpdateAsync(T oldItem, T newItem);

        Task DeleteAsync(I id);

        Task<T?> GetItemAsync(I id);

        Task<IEnumerable<T>> GetPage(int itemsPerPage, int pageNo);
    }
}
