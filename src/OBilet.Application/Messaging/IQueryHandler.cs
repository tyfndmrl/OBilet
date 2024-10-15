using MediatR;
using OBilet.Application.Common.Models;

namespace OBilet.Application.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, IResult<TResponse>> where TQuery : IQuery<TResponse>;
}
