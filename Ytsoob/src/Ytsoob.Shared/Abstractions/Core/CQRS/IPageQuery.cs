using Ytsoob.Shared.Abstractions.Core.Paging;

namespace Ytsoob.Shared.Abstractions.Core.CQRS;

public interface IPageQuery<out TResponse> : IPageRequest, IQuery<TResponse>
    where TResponse : class
{
}
