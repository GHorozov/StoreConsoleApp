using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Data;
using Store.Models;
using Store.Services.Contracts;
using System.Linq;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private StoreDbContext context;
        private IMapper mapper;
        private IUserService userService;

        public ProductService(StoreDbContext context, IMapper mapper, IUserService userService)
        {
            this.context = context;
            this.mapper = mapper;
            this.userService = userService;
        }

        public TModel CreateProduct<TModel>(string name, decimal price, string content, int categoryId, int authorId)
        {
            var product = new Product(name, price, content, categoryId, authorId);
            this.context.Products.Add(product);
            this.context.SaveChanges();

            var productDto = mapper.Map<TModel>(product);

            return productDto;
        }

        public IQueryable<TModel> GetAllProducts<TModel>()
        {
            var products = this.context.Products
                .ProjectTo<TModel>(mapper.ConfigurationProvider);
                
            return products;
        }

        public TModel GetProductById<TModel>(int id)
        {
            var product = this.context.Products
                .Where(x => x.Id == id)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            return product;
        }

        public TModel GetProductByName<TModel>(string name)
        {
            var product = this.context.Products
                .Where(x => x.Name == name)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            return product;
        }
    }
}
