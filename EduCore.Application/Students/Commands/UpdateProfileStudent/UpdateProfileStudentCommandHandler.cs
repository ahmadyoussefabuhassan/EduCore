using EduCore.Application.Abstractions.Files;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Application.Abstractions.Services;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Students;
using EduCore.Domain.Users;
using Microsoft.AspNetCore.Http;

namespace EduCore.Application.Students.Commands.UpdateProfileStudent
{
    internal sealed class UpdateProfileStudentCommandHandler : BaseService,ICommandHandler<UpdateProfileStudentCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFileService _fileService;

        public UpdateProfileStudentCommandHandler(IUnitOfWork unitOfWork,
            IStudentRepository studentRepository,
            IUserRepository userRepository, 
            IFileService fileService,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _fileService = fileService;
        }

        public async Task<Result<Guid>> Handle(UpdateProfileStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(UserId , cancellationToken);
            if(student is null)
                return Result.Failure<Guid>(StudentErrors.NotFound);
            var user = await _userRepository.GetByIdAsync(student.Id, cancellationToken);
            if(user is null)
                return Result.Failure<Guid>(UserErrors.NotFound);
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
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(student.Id);
        }
    }
}
