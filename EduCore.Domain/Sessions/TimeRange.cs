namespace EduCore.Domain.Sessions
{
    public sealed record TimeRange
    {
        private TimeRange() { }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public static TimeRange Create(TimeSpan startTime, TimeSpan endTime)
        {
            if (endTime < startTime)
                throw new ArgumentException("End time cannot be earlier than start time.");
            return new TimeRange { StartTime = startTime, EndTime = endTime };
        }
    }
}
