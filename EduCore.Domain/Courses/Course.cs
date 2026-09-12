using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;
using EduCore.Domain.Courses.Events;
using EduCore.Domain.Enrollments;
using EduCore.Domain.Instructors;
using EduCore.Domain.Sessions;
using EduCore.Domain.Shared;

namespace EduCore.Domain.Courses
{
    public sealed class Course : Entity
    {
        private Course() : base(Guid.Empty)
        {
        }
        private Course(Guid Id, CourseName name, Description description, CourseStatus status, TotalHours totalHours, MaximumStudents maximumStudents, Money price, DateRange? dateRange, Guid categoryId, Guid instructorId) : base(Id)
        {
            Name = name;
            Description = description;
            TotalHours = totalHours;
            MaximumStudents = maximumStudents;
            Price = price;
            Status = status;
            DateRange = dateRange;
            CategoryId = categoryId;
            InstructorId = instructorId;
        }
        public CourseName Name { get; private set; }
        public Description Description { get; private set; }
        public CourseStatus Status { get; private set; }
        public TotalHours TotalHours { get; private set; }
        public MaximumStudents MaximumStudents { get; private set; }
        public Money Price { get; private set; }
        public DateRange? DateRange { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid InstructorId { get; private set; }
        public Category Category { get; private set; } = null!;
        public Instructor Instructor { get; private set; } = null!;
        public ICollection<Enrollment> Enrollments { get; private set; } = new List<Enrollment>();
        public ICollection<Session> Sessions { get; private set; } = new List<Session>();
        public static Course Create(CourseName name, Description description, TotalHours totalHours, MaximumStudents maximumStudents, Money price, DateRange? dateRange, Guid categoryId, Guid instructorId)
        {
            var course = new Course(Guid.NewGuid(), name, description, CourseStatus.Upcoming, totalHours, maximumStudents, price, dateRange, categoryId, instructorId);
            course.RaiseDomainEvent(new CourseCreatedDomainEvent(course.Id));
            return course;
        }
        public void UpdateDetails(CourseName name, Description description, MaximumStudents maximumStudents)
        {
            Name = name;
            Description = description;
            MaximumStudents = maximumStudents;
        }
        public Result UpdatePrice(Money price)
        {
            if (price is null || price.IsZero())
                return Result.Failure(CourseErrors.PriceCannotBeZeroOrNull);
            Price = price;
            return Result.Success();
        }
        public Result UpdateDateRange(DateRange? dateRange)
        {
            DateRange = dateRange;
            return Result.Success();
        }
        public Result Publish()
        {
            Status = CourseStatus.Upcoming;
            RaiseDomainEvent(new CoursePublishedDomainEvent(Id));
            return Result.Success();
        }
        public Result Activate()
        {
            if(DateRange is null && !DateRange.IsComplete())
                return Result.Failure(CourseErrors.DateRangeRequiredForStatus);
            Status = CourseStatus.Active;
            RaiseDomainEvent(new CourseActivatedDomainEvent(Id));
            return Result.Success();
        }
        public Result Complete()
        {
            if (DateRange is null && !DateRange.IsComplete())
                return Result.Failure(CourseErrors.DateRangeRequiredForStatus);
            Status = CourseStatus.Completed;
            RaiseDomainEvent(new CourseCompletedDomainEvent(Id));
            return Result.Success();
        }
        public Result Cancel()
        {
            Status = CourseStatus.Cancelled;
            RaiseDomainEvent(new CourseCancelledDomainEvent(Id));
            return Result.Success();
        }
    }
}
