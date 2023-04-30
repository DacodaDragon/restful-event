namespace RestfulEvent.Models.Schedule
{
    [Flags]
    public enum ScheduleItemStatusFlag : byte 
    { 
        Delayed = (1 << 1),
        Cancelled = (1 << 2),
        Unconfirmed = (1 << 3),
    }
}
