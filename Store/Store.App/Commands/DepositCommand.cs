using Store.App.Commands.Contracts;
using Store.Models;
using Store.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App.Commands
{
    public class DepositCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IUserService userService;

        public DepositCommand(IUserSessionService userSessionService, IUserService userService)
        {
            this.userSessionService = userSessionService;
            this.userService = userService;
        }

        public string Execute(params string[] args)
        {
            var money = decimal.Parse(args[0]);

            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var userId = this.userSessionService.User.Id;
            var username = this.userSessionService.User.Username;
            var password = this.userSessionService.User.Password;

            var user = this.userService.Deposit<User>(userId,username, password, money);

            return "Deposit made successfully!";
        }
    }
}
