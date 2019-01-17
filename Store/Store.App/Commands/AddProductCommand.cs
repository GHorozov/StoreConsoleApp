using Store.App.Commands.Contracts;
using Store.App.Models;
using Store.Services.Contracts;

namespace Store.App.Commands
{
    public class AddProductCommand : ICommand
    {
        private IUserSessionService userSessionservice;
        private IUserService userService;
        private ICategoryService categoryService;
        private IProductService productService;

        public AddProductCommand(IUserSessionService userSessionservice, IUserService userService, ICategoryService categoryService, IProductService productService)
        {
            this.userSessionservice = userSessionservice;
            this.userService = userService;
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public string Execute(params string[] args)
        {
            var categoryName = args[0];
            var name = args[1];
            var price = decimal.Parse(args[2]);
            var content = args[3];

            if (!this.userSessionservice.IsLoggedIn())
            {
                return "You are not logged in!";
            }

            var category = this.categoryService.GetCategoryByName<CategoryDto>(categoryName);
            
            if(category == null)
            {
                category = this.categoryService.CreateCategory<CategoryDto>(categoryName);
            }

            var categoryId = category.Id;
            var authorId = userSessionservice.User.Id;

            var product = this.productService.CreateProduct<ProductDto>(name, price, content, categoryId, authorId);

            return $"Product {product.Name} created successfully!";
        }
    }
}
