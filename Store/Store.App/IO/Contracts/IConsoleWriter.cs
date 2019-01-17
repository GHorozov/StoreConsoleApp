namespace Store.App.IO.Contracts
{
    public interface IConsoleWriter
    {
        void Write(string text);

        void WriteLine(string text);
    }
}
