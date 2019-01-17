using Store.App.Commands.Contracts;
using Store.Models;
using Store.Services.Contracts;

namespace Store.App.Commands
{
    public class RegisterCommand : ICommand
    {
        private IUserService userService;

        public RegisterCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            var user = this.userService.GetUserByUsernameAndPassword<User>(username, password);

            if(user != null)
            {
                return "User already exist!";
            }

            var userResult = this.userService.CreateUser<User>(username, password);

            return $"User {userResult.Username} created successfully!";
        }
    }
}



