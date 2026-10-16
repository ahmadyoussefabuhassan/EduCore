using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Students;

namespace EduCore.Application.Students.Commands.ActivateStudent
{
    internal sealed class ActivateStudentCommandHandler : ICommandHandler<ActivateStudentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public ActivateStudentCommandHandler(IUnitOfWork unitOfWork,
            IStudentRepository studentRepository)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
        }

        public async Task<Result<bool>> Handle(ActivateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
            if(student is null)
                return Result.Failure<bool>(StudentErrors.NotFound);
            student.ActiveStudent();
            await _studentRepository.UpdateAsync(student, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(true);
        }
    }
}
