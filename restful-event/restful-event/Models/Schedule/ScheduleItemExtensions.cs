namespace RestfulEvents.Models.Schedule
{
    public static class ScheduleItemExtensions
    {
        public static ViewType ConvertToType<ViewType>(this IScheduleItemEntity source) where ViewType : IScheduleItemEntity, new()
        {
            ViewType view = new();
            view.Copy(source);
            return view;
        }

        public static void Copy(this IScheduleItemEntity target, IScheduleItemEntity source)
        {
            if (target is null) throw new ArgumentNullException(nameof(target));
            if (source is null) throw new ArgumentNullException(nameof(source));

            target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.OriginalStartDateTime = source.OriginalStartDateTime;
            target.OriginalEndDateTime = source.OriginalEndDateTime;
            target.StartDateTime = source.StartDateTime;
            target.EndDateTime = source.EndDateTime;
            target.Author = source.Author;
            target.Type = source.Type;
            target.StatusFlags = source.StatusFlags;
        }
    }
}
