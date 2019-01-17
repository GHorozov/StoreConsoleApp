using Store.Models;
using Store.Services.Contracts;

namespace Store.Services
{
    public class UserSessionService : IUserSessionService
    {
        private IUserService userService;

        public UserSessionService(IUserService userService)
        {
            this.userService = userService;
        }

        public User User { get; private set; }

        public bool IsLoggedIn()
        {
            return this.User != null;
        }

        public User Login(string username, string password)
        {
            this.User = userService.GetUserByUsernameAndPassword<User>(username, password);

            return this.User;
        }

        public void Logout()
        {
            this.User = null;
        }
    }
}
