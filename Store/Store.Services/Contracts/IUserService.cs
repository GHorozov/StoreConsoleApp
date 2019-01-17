namespace Store.Services.Contracts
{
    public interface IUserService
    {
        TModel GetUserById<TModel>(int id);

        TModel GetUserByUsername<TModel>(string username);

        TModel GetUserByUsernameAndPassword<TModel>(string username, string password);

        TModel CreateUser<TModel>(string username, string password);

        TModel Deposit<TModel>(int userId, string username, string password, decimal money);

        TModel ChangePassword<TModel>(int userId, string newPassword);

        void RemoveUser(int id);
    }
}
