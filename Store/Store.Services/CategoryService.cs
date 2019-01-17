using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Data;
using Store.Models;
using Store.Services.Contracts;
using System.Linq;

namespace Store.Services
{
    public class CategoryService : ICategoryService
    {
        private StoreDbContext context;
        private IMapper mapper;

        public CategoryService(StoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TModel CreateCategory<TModel>(string name)
        {
            var category = new Category(name);
            this.context.Categories.Add(category);
            this.context.SaveChanges();

            var categoryDto = mapper.Map<TModel>(category);

            return categoryDto;
        }

        public TModel GetCategoryById<TModel>(int id)
        {
            var category = this.context.Categories
                 .Where(x => x.Id == id)
                 .ProjectTo<TModel>(mapper.ConfigurationProvider)
                 .SingleOrDefault();

            return category;
        }

        public TModel GetCategoryByName<TModel>(string name)
        {
            var category = this.context.Categories
                .Where(x => x.Name == name)
                .ProjectTo<TModel>(mapper.ConfigurationProvider)
                .SingleOrDefault();

            return category;
        }
    }
}
