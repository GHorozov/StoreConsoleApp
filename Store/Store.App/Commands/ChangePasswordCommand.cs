using Store.App.Commands.Contracts;
using Store.Models;
using Store.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.App.Commands
{
    public class ChangePasswordCommand : ICommand
    {
        private IUserSessionService userSessionService;
        private IUserService userService;

        public ChangePasswordCommand(IUserSessionService userSessionService, IUserService userService)
        {
            this.userSessionService = userSessionService;
            this.userService = userService;
        }

        public string Execute(params string[] args)
        {
            var newPassword = args[0];

            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var userId = this.userSessionService.User.Id;

            var user = this.userService.ChangePassword<User>(userId, newPassword);

            return "Password is changed successfuly!";
        }
    }
}
