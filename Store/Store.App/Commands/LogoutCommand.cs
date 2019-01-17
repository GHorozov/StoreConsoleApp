using Store.App.Commands.Contracts;
using Store.Services.Contracts;

namespace Store.App.Commands
{
    public class LogoutCommand : ICommand
    {
        private IUserSessionService userSessionService;

        public LogoutCommand(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }

        public string Execute(params string[] args)
        {
            if (!this.userSessionService.IsLoggedIn())
            {
                return "You must be logged in first to logout!";
            }

            this.userSessionService.Logout();

            return "Logged out successufully!";
        }
    }
}
