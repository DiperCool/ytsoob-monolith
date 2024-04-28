using MediatR;
using Ytsoob.Shared.Abstractions.Caching;

namespace Ytsoob.Shared.Cache;

public abstract record CacheRequest<TRequest, TResponse> : ICacheRequest<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public virtual TimeSpan AbsoluteExpirationRelativeToNow => TimeSpan.FromMinutes(5);

    // public virtual TimeSpan SlidingExpiration => TimeSpan.FromSeconds(30);
    // public virtual DateTime? AbsoluteExpiration => null;
    public virtual string Prefix => "Ch_";

    public virtual string CacheKey(TRequest request) => $"{Prefix}{typeof(TRequest).Name}";
}
