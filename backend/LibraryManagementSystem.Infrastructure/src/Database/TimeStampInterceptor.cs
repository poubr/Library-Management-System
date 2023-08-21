using LibraryManagementSystem.Domain.src;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LibraryManagementSystem.Infrastructure.src.Database
{
    public class TimeStampInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var trackedEntities = eventData.Context!.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Added);
            foreach (var entry in trackedEntities)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.UpdatedAt = DateTime.Now;
                }
            }

            var updatedEntities = eventData.Context!.ChangeTracker.Entries().Where(entity => entity.State == EntityState.Modified);
            foreach (var entry in updatedEntities)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    entity.UpdatedAt = DateTime.Now;
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}