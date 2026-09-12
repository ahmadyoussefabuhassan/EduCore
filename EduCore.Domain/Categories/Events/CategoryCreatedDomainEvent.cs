using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Categories.Events
{
    public sealed record CategoryCreatedDomainEvent(Guid CategoryId, CategoryName Name) : IDomainEvent;

}
