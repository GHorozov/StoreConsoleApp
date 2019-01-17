using Store.App.IO;
using Store.App.IO.Contracts;
using Store.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Store.App
{
    public class Engine
    {
        private IConsoleReader reader;
        private IConsoleWriter writer;
        private CommandParser commandParser;
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.serviceProvider = serviceProvider;
            this.commandParser = new CommandParser(serviceProvider);
        }

        public void Run()
        {
            //var databaseInitializerService = this.serviceProvider.GetService<IDatabaseInitializerService>();
            //databaseInitializerService.InitializeDatabase();

            while (true)
            {
                Console.Write("Enter command: ");
                var input = this.reader.ReadLine();
                var args = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var commandName = args[0];
                args = args.Skip(1).ToArray();

                try
                {
                    var command = this.commandParser.ParseCommand(commandName);
                    var result = command.Execute(args);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
