using CinemaTicketBooking.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace CinemaTicketBooking.Models.Interceptors
{
    public class SoftDeleteInterceptor: SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context == null)
                return result;

            IEnumerable<EntityEntry<Movie>> trackedOrders = eventData.Context.ChangeTracker.Entries<Movie>();

            foreach(EntityEntry<Movie> entry in trackedOrders)
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }

            return result;
        }
    }
}
