using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Data;
using Store.Models;
using Store.Services.Contracts;
using System.Linq;

namespace Store.Services
{
    public class UserService : IUserService
    {
        private StoreDbContext context;
        private IMapper mapper;

        public UserService(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel ChangePassword<TModel>(int userId, string newPassword)
        {
            var user = this.context.Users.Find(userId);
            user.Password = newPassword;
            this.context.SaveChanges();

            var userDto = mapper.Map<TModel>(user);

            return userDto;
        }

        public TModel CreateUser<TModel>(string username, string password)
        {
            var user = new User(username, password);
            this.context.Users.Add(user);
            this.context.SaveChanges();

            var userDto = mapper.Map<TModel>(user);

            return userDto;
        }

        public TModel Deposit<TModel>(int userId, string username, string password, decimal money)
        {
            var user = this.context.Users.Find(userId);

            var currentBalance = user.Balance;
            var newBalance = currentBalance + money;
            user.Balance = newBalance;
            this.context.SaveChanges();

            var userDto = mapper.Map<TModel>(user);

            return userDto;
        }

        public TModel GetUserById<TModel>(int id)
        {
            var user = context
                 .Users
                 .Where(x => x.Id == id)
                 .ProjectTo<TModel>(mapper.ConfigurationProvider)
                 .SingleOrDefault();

            return user;
        }

        public TModel GetUserByUsername<TModel>(string username)
        {
            var user = context.Users
                .Where(x => x.Username == username)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            return user;
        }

        public TModel GetUserByUsernameAndPassword<TModel>(string username, string password)
        {
            var user = context.Users
                 .Where(x => x.Username == username && x.Password == password)
                 .ProjectTo<TModel>(mapper.ConfigurationProvider)
                 .SingleOrDefault();

            return user;
        }

        public void RemoveUser(int id)
        {
            var user = context.Users.Find(id);
            this.context.Remove(user);
            this.context.SaveChanges();
        }
    }
}
