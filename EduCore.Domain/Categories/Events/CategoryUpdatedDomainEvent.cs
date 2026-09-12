using EduCore.Domain.Abstractions;

namespace EduCore.Domain.Categories.Events
{
    public sealed record CategoryUpdatedDomainEvent(Guid CategoryId, CategoryName Name) : IDomainEvent;

}
