
using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Users.Events
{
    public sealed record UserUpdatedDomainEvent(Guid Id , 
        FullName FullName ,
        Email Email ,
        PhoneNumber PhoneNumber
    ) : IDomainEvent;

}
