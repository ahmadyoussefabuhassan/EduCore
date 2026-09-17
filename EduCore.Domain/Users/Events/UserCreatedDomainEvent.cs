
using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid Id,
        FullName FullName,
        Email Email,
        PhoneNumber PhoneNumber
    ) : IDomainEvent;

}
