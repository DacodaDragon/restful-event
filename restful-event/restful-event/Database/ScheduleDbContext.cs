using Microsoft.EntityFrameworkCore;
using RestfulEvents.Models.Schedule;

namespace RestfulEvents.Database
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        {

        }

        public DbSet<ScheduleItemEntity> ScheduleEntries { get; set; } = null;
    }
}
