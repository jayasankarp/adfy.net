using Adfy.Domain.Abstractions;
using MediatR;

namespace Adfy.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}