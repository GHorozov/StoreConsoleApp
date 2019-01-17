using Store.App.IO.Contracts;
using System;

namespace Store.App.IO
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
