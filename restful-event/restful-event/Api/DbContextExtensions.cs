using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RestfulEvents.Api
{
    public static class DbContextExtensions
    {
        public static void RejectChanges(this DbContext dbContext)
        {
            RejectChanges(dbContext.ChangeTracker);
        }

        public static void RejectChanges(this ChangeTracker tracker)
        {
            foreach (var entry in tracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}
