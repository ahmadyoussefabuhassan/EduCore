using EduCore.Application.Abstractions.Messaging;

namespace EduCore.Application.SuperAdmin.Queries.GetProfileSuperAdmin
{
    public sealed record GetProfileSuperAdminQuery() :IQuery<SuperAdminResponse>;
}
