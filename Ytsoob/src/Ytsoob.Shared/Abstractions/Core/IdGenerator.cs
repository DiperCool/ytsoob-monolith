namespace Ytsoob.Shared.Abstractions.Core;

public interface IIdGenerator<out TId>
{
    TId New();
}
