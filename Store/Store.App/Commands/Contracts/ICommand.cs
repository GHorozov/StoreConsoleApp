namespace Store.App.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(params string[] args);
    }
}
