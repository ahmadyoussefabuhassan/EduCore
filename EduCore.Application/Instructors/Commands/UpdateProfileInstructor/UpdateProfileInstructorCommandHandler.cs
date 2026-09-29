using EduCore.Application.Abstractions.Files;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Instructors.Commands.UpdateProfileInstructor
{
    internal sealed class UpdateProfileInstructorCommandHandler : BaseService,
        ICommandHandler<UpdateProfileInstructorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;
        public UpdateProfileInstructorCommandHandler(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IUserRepository userRepository, IInstructorRepository instructorRepository, IFileService fileService) : base(httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _instructorRepository = instructorRepository;
            _fileService = fileService;
        }

        public async Task<Result<Guid>> Handle(UpdateProfileInstructorCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(UserId, cancellationToken);
            if (user is null)
                return Result.Failure<Guid>(UserErrors.NotFound);
            var instructor = await _instructorRepository.GetByIdAsync(user.Id, cancellationToken);
            if (instructor is null)
                return Result.Failure<Guid>(InstructorErrors.NotFound);
            var newEmail = new Email(request.Email);
            if (newEmail != user.Email)
            {
                var existingUserWithEmail = await _userRepository.GetByEmailAsync(newEmail, cancellationToken);
                if (existingUserWithEmail is not null)
                    return Result.Failure<Guid>(UserErrors.EmailAlreadyExists);
            }
            string? image = user.ImageUrl?.Value;
            if (request.ImageUrl is not null)
            {
                if (!string.IsNullOrEmpty(user.ImageUrl?.Value))
                {
                    _fileService.DeleteImage(user.ImageUrl.Value);
                }
                image = await _fileService.UploadImageAsync(request.ImageUrl, "Users", cancellationToken);
            }
            user.UpdateProfileUser(
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                newEmail,
                new PhoneNumber(request.PhoneNumber),
                request.Genders,
                new Address(request.Address),
                new ImageUrl(image)
            );
            await _userRepository.UpdateAsync(user, cancellationToken);
            instructor.UpdateInstructor(new Specialization(request.Specialization));
            await _instructorRepository.UpdateAsync(instructor, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(instructor.Id);
        }
    }
}
