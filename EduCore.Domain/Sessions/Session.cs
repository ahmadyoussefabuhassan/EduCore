using EduCore.Domain.Abstractions;
using EduCore.Domain.Courses;
using EduCore.Domain.Sessions.Events;

namespace EduCore.Domain.Sessions
{
    public sealed class Session : Entity
    {
        private Session(Guid Id, Title title , Description description, TimeRange timeRange ,DateTime date, Guid courseId ) : base(Id)
        {
            Title = title;
            Description = description;
            TimeRange = timeRange;
            Date = date;
            CourseId = courseId;
        }
        public Title Title { get; private set; }
        public Description Description { get; private set; }
        public TimeRange TimeRange { get; private set; }
        public DateTime Date { get; private set; }
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; } = null!;
        public static Session Create(Title title, Description description , TimeRange timeRange,DateTime date, Guid courseId)
        {
            var session = new Session(Guid.NewGuid(), title ,description, timeRange, date,courseId);
            session.RaiseDomainEvent(new SessionCreatedDomainEvent(session.Id));
            return session;
        }
        public void UpdateSession(Title title , Description description)
        {
            Title = title;
            Description = description;
        }
        public Result UpdateTimeRange(TimeRange timeRange)
        {
            TimeRange = timeRange;
            RaiseDomainEvent(new SessionUpdateTimeDomainEvent(Id));
            return Result.Success();
        }
    }
}
