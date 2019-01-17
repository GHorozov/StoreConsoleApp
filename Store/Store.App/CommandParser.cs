using Store.App.Commands.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Store.App
{
    public class CommandParser
    {
        private IServiceProvider serviceProvider;

        public CommandParser(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand ParseCommand(string commandName)
        {
            var allCommandTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(ICommand).IsAssignableFrom(x))
                .ToArray();

            var commandType = allCommandTypes.SingleOrDefault(x => x.Name == $"{commandName}Command");
            if(commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            var services = constructorParameters
                .Select(x => serviceProvider.GetService(x))
                .ToArray();

            var command = (ICommand)Activator.CreateInstance(commandType, services );

            return command;
        }
    }
}
