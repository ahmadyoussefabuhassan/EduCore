namespace EduCore.Domain.Courses
{
    public sealed record DateRange
    {
        private DateRange() { }
        public DateOnly? StartDate { get; init; }
        public DateOnly? EndDate { get; init; }
        public static DateRange Create(DateOnly? startDate, DateOnly? endDate)
        {
            if (endDate.HasValue && !startDate.HasValue)
                throw new ApplicationException("Cannot have an end date without a start date.");

            if (startDate.HasValue && endDate.HasValue && endDate < startDate)
                throw new ApplicationException("End date cannot be earlier than start date.");
            return new DateRange { StartDate = startDate, EndDate = endDate };
        }
        public bool IsComplete() => StartDate.HasValue && EndDate.HasValue;
    }
}
