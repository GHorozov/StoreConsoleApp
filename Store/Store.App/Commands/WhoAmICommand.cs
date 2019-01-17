using Store.App.Commands.Contracts;
using Store.Services.Contracts;

namespace Store.App.Commands
{
    public class WhoAmICommand : ICommand
    {
        private IUserSessionService userSessionService;

        public WhoAmICommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute(params string[] args)
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var username = this.userSessionService.User.Username;

            return $"{username}";
        }
    }
}
