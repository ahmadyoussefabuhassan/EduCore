
using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Users.Events
{
    public sealed record UserUpdatedPasswordDomainEvent(Guid Id,
        FullName FullName,
        Email Email,
        PhoneNumber PhoneNumber
    ) : IDomainEvent;

}
