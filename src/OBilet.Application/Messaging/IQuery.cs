using MediatR;
using OBilet.Application.Common.Models;

namespace OBilet.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<IResult<TResponse>>;
}
