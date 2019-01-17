using System.Linq;

namespace Store.Services.Contracts
{
    public interface IProductService
    {
        IQueryable<TModel> GetAllProducts<TModel>();

        TModel GetProductById<TModel>(int id);

        TModel GetProductByName<TModel>(string name);

        TModel CreateProduct<TModel>(string name, decimal price, string content, int categoryId, int authorId);
    }
}
