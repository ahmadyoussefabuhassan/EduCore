using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Admin.Queries.GetAllAdmin
{
    public sealed record GetAllAdminQuery() : IQuery<IEnumerable<AdminResponse>>;
}
