using Ytsoob.Shared.Core.Reflection.Extensions;

namespace Ytsoob.Shared.Cache;

public static class CacheKey
{
    public static string With(params string[] keys)
    {
        return string.Join("-", keys);
    }

    public static string With(Type ownerType, params string[] keys)
    {
        return With($"{ownerType.GetCacheKey()}:{string.Join("-", keys)}");
    }
}
