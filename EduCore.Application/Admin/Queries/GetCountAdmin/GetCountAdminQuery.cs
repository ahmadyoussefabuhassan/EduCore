using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.Admin.Queries.GetCountAdmin
{
    public sealed record GetCountAdminQuery() : IQuery<int>;
}
