using RestfulEvents.Utility;
using RestfulEvents.Models.Schedule;

namespace RestfulEvents.Api.Schedule.Dto
{
    public class NewScheduleItem : IScheduleItemEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { set; get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public ScheduleItemType Type { get; set; }
        public ScheduleItemStatusFlag[]? StatusFlags { get; set; } = Array.Empty<ScheduleItemStatusFlag>();

        Guid IScheduleItemEntity.Id { get; set; }
        
        DateTime IScheduleItemEntity.OriginalStartDateTime { get; set; }
        DateTime IScheduleItemEntity.OriginalEndDateTime { get; set; }

        Models.Schedule.ScheduleItemType IScheduleItemEntity.Type
        {
            get => (Models.Schedule.ScheduleItemType)Type;
            set => Type = (ScheduleItemType)value;
        }

        Models.Schedule.ScheduleItemStatusFlag IScheduleItemEntity.StatusFlags
        {
            get => (Models.Schedule.ScheduleItemStatusFlag)StatusFlags.CombineFlagsByte();
            set => StatusFlags = ((ScheduleItemStatusFlag)value).GetAllFlags();
        }
    }
}