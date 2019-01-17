namespace Store.Services.Contracts
{
    public interface ICategoryService
    {
        TModel GetCategoryByName<TModel>(string name);

        TModel GetCategoryById<TModel>(int id);

        TModel CreateCategory<TModel>(string name);
    }
}
