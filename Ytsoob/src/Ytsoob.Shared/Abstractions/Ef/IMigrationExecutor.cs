namespace Ytsoob.Shared.Abstractions.Ef;

public interface IMigrationExecutor
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}
