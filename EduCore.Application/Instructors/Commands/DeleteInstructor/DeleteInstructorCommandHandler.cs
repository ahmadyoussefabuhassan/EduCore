using EduCore.Application.Abstractions.Files;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;
using EduCore.Domain.Users;

namespace EduCore.Application.Instructors.Commands.DeleteInstructor
{
    internal sealed class DeleteInstructorCommandHandler : ICommandHandler<DeleteInstructorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;

        public DeleteInstructorCommandHandler(IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IInstructorRepository instructorRepository,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _fileService = fileService;
            _instructorRepository = instructorRepository;
        }

        public async Task<Result> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorRepository.GetByIdAsync(request.Id , cancellationToken);
            if(instructor is null)
                return Result.Failure(InstructorErrors.NotFound);
            if(await _instructorRepository.HasRelatedDataAsync(instructor.Id, cancellationToken))
                return Result.Failure(InstructorErrors.HasRelatedData);
            var user = await _userRepository.GetByIdAsync(instructor.Id, cancellationToken);
            if(user is null)
                return Result.Failure(UserErrors.NotFound);
            await _instructorRepository.DeleteAsync(instructor, cancellationToken);
            await _userRepository.DeleteAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
              if(user.ImageUrl?.Value is not null)
                _fileService.DeleteImage(user.ImageUrl.Value);
            return Result.Success();

        }
    }
}
