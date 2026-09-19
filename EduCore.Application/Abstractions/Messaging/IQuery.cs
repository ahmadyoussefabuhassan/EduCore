using EduCore.Domain.Abstractions;
using MediatR;

namespace EduCore.Application.Abstractions.Messaging
{
    public interface IQuery<TResponce> : IRequest<Result<TResponce>>
    {
    }

}
