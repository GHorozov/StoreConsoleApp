using Store.App.IO.Contracts;
using System;

namespace Store.App.IO
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
