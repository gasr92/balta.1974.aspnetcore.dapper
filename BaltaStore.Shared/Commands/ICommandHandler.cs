namespace BaltaStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        // retorna um ICommandResult, pois caso contrario ficaria limitado a um tipo de dados especifico
         ICommandResult Handle(T command);
    }
}