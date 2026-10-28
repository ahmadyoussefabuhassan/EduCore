using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Categories;
using EduCore.Domain.Courses;
using EduCore.Domain.Roles;
using EduCore.Domain.Shared;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Courses.Commands.AddCourse
{
    internal sealed class AddCourseCommandHandler : BaseService, ICommandHandler<AddCourseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICourseRepository _courseRepository;
        public AddCourseCommandHandler(IHttpContextAccessor httpContextAccessor, 
            IUnitOfWork unitOfWork, IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            ICourseRepository courseRepository) : base(httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Result<Guid>> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(UserId, cancellationToken);
            if (user is null)
                return Result.Failure<Guid>(UserErrors.NotFound);
            if (user.Role.Name != Name.Instructor
                && user.Role.Name != Name.Admin
                && user.Role.Name != Name.SuperAdmin)
                return Result.Failure<Guid>(UserErrors.Unauthorized);
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
            if(category  is null)
                return Result.Failure<Guid>(CategoryErrors.NotFound);
            var currency =  Currency.FromCode(request.Currency);
            var date = DateRange.Create(request.StartDate, request.EndDate);
            var course = Course.Create(
                new CourseName(request.Name),
                new Description(request.Description),
                new TotalHours(request.TotalHours),
                new MaximumStudents(request.MaximumStudents),
                new Money(request.Amount,currency),
                date,
                category.Id,
                user.Id
            );
            await _courseRepository.AddAsync(course , cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(course.Id);
        }
    }
}
