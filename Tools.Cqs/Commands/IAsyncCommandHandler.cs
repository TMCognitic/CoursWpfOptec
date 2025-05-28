namespace Tools.Cqs.Commands
{
    public interface IAsyncCommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        Task<bool> ExecuteAsync(TCommand command);
    }

    public interface IAsyncCommandHandler<TCommand, TResult>
        where TCommand : ICommandDefinition<TResult>
    {
        Task<TResult> ExecuteAsync(TCommand command);
    }
}
