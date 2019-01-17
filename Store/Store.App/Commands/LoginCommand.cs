using Store.App.Commands.Contracts;
using Store.Services.Contracts;
using System;

namespace Store.App.Commands
{
    public class LoginCommand : ICommand
    {
        private IUserSessionService userSessionService;

        public LoginCommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var user = this.userSessionService.Login(username, password);

            if (user == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            return "Logged in successfully!";
        }
    }
}
