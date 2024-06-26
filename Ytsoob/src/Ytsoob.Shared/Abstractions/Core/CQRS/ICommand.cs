using MediatR;

namespace Ytsoob.Shared.Abstractions.Core.CQRS;

public interface ICommand : IRequest
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
    where TResponse : class
{
}
