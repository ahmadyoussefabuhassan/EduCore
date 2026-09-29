using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Admin.Queries.GetProfileAdmin
{
    public sealed record GetProfileAdminQuery() : IQuery<AdminResponse>;
}
