using EduCore.Application.Abstractions.Hashing;
using EduCore.Application.Abstractions.Messaging;
using EduCore.Domain.Abstractions;
using EduCore.Domain.Instructors;
using EduCore.Domain.Roles;
using EduCore.Domain.Users;

namespace EduCore.Application.Instructors.Commands.AddInstructor
{
    internal sealed class AddInstructorCommandHandler : ICommandHandler<AddInstructorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly IRoleRepository _roleRepository;

        public AddInstructorCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IInstructorRepository instructorRepository, IPasswordHashingService passwordHashingService, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _instructorRepository = instructorRepository;
            _passwordHashingService = passwordHashingService;
            _roleRepository = roleRepository;
        }

        public async Task<Result> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByNameAsync(Name.Instructor, cancellationToken);
            if (role is null)
                return Result.Failure(RoleErrors.NotFound);
            var existingUser = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if (existingUser is not null)
                return Result.Failure(UserErrors.EmailAlreadyExists);
            var passwordhash = _passwordHashingService.GetPasswordHash(request.Password);
            var user = User.Create(
                new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email),
                new PasswordHash(passwordhash),
                new PhoneNumber(request.PhoneNumber),
                new Address(request.Address),
                role.Id
            );
            await _userRepository.AddAsync(user, cancellationToken);
            var instructor = Instructor.Create(
                user.Id,
                new Specialization(request.Specialization)
            );
            await _instructorRepository.AddAsync(instructor, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
