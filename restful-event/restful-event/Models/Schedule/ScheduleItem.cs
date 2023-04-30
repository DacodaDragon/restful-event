using Microsoft.EntityFrameworkCore;

namespace RestfulEvents.Models.Schedule
{
    [PrimaryKey("Id")]
    public class ScheduleItemEntity : IScheduleItemEntity
    {
        public Guid Id { get; set; }
        public ScheduleItemType Type { get; set; }
        public ScheduleItemStatusFlag StatusFlags { get; set; }
        public DateTime OriginalStartDateTime { get; set; }
        public DateTime OriginalEndDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { set; get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
    }
}
