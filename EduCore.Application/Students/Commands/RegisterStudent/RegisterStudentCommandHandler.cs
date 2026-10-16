using EduCore.Application.Abstractions.Hashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Roles;
using EduCore.Domain.Students;
using EduCore.Domain.Users;

namespace EduCore.Application.Students.Commands.RegisterStudent
{
    internal sealed class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHashingService _passwordHashingService;

        public RegisterStudentCommandHandler(IUnitOfWork unitOfWork,
            IStudentRepository studentRepository,
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            IPasswordHashingService passwordHashingService)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHashingService = passwordHashingService;
        }

        public async Task<Result> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByNameAsync(Name.Student , cancellationToken);
            if(role is null)
                return Result.Failure(RoleErrors.NotFound);
            var existingUser = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if(existingUser is not null)
                return Result.Failure(UserErrors.EmailAlreadyExists);
            var passwordHash = _passwordHashingService.GetPasswordHash(request.Password);
            var user = User.Create(
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email),
                new PasswordHash(passwordHash),
                new PhoneNumber(request.PhoneNumber),
                new Address(request.Address),
                role.Id
            );
            await _userRepository.AddAsync(user, cancellationToken);
            var student = Student.Create(user.Id);
            await _studentRepository.AddAsync(student, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
