namespace RestfulEvent.Api.Schedule.Dto
{
    public enum ScheduleItemStatusFlag : byte 
    {
        Delayed = Models.Schedule.ScheduleItemStatusFlag.Delayed,
        Cancelled = Models.Schedule.ScheduleItemStatusFlag.Cancelled,
        Unconfirmed = Models.Schedule.ScheduleItemStatusFlag.Unconfirmed,
    }
}
