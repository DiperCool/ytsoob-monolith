using Ytsoob.Shared.Abstractions.Core.Domain;

namespace Ytsoob.Shared.Core.Domain;

public record EntityId<T> : Identity<T>
{
    public static implicit operator T(EntityId<T> id)
    {
        ArgumentNullException.ThrowIfNull(id.Value);
        return id.Value;
    }

    public static EntityId<T> CreateEntityId(T id) => new() { Value = id };
}

public record EntityId : EntityId<long>
{
    public static implicit operator long(EntityId id)
    {
        ArgumentNullException.ThrowIfNull(id.Value);
        return id.Value;
    }

    public new static EntityId CreateEntityId(long id) => new() { Value = id };
}
