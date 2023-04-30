
using RestfulEvents.Utility;
using RestfulEvents.Models.Schedule;
using System.ComponentModel.DataAnnotations;

namespace RestfulEvents.Api.Schedule.Dto
{
    public class ScheduleItem : IScheduleItemEntity
    {
        public Guid Id { get; set; }
        public ScheduleItemType Type { get; set; }
        public DateTime OriginalStartDateTime { get; set; }
        public DateTime OriginalEndDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { set; get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public ScheduleItemStatusFlag[] Flags { get; set; } = Array.Empty<ScheduleItemStatusFlag>();

        Models.Schedule.ScheduleItemType IScheduleItemEntity.Type 
        { 
            get => (Models.Schedule.ScheduleItemType)Type; 
            set => Type = (ScheduleItemType)value; 
        }

        Models.Schedule.ScheduleItemStatusFlag IScheduleItemEntity.StatusFlags 
        {
            get => (Models.Schedule.ScheduleItemStatusFlag)Flags.CombineFlagsByte();
            set => Flags = ((ScheduleItemStatusFlag)value).GetAllFlags();
        }
    }
}
