using Store.App.Commands.Contracts;
using Store.App.Models;
using Store.Services.Contracts;
using System.Linq;
using System.Text;

namespace Store.App.Commands
{
    public class ListProductsCommand : ICommand
    {
        private IProductService productService;

        public ListProductsCommand(IProductService productService)
        {
            this.productService = productService;
        }

        public string Execute(params string[] args)
        {
            var allProducts = this.productService
                .GetAllProducts<ProductDto>()
                .GroupBy(x => x.CategoryName)
                .ToArray();

            var sb = new StringBuilder();
            foreach (var group in allProducts)
            {
                sb.AppendLine($"{group.Key}:");
                foreach (var product in group)
                {
                    sb.AppendLine($"   ProductId: {product.Id}, ProductName: {product.Name}, ProductPrice: {product.Price}, ProductContent: {product.Content}, ProductAuthor: {product.Author}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
