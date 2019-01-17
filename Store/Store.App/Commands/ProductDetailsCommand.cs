using Store.App.Commands.Contracts;
using Store.App.Models;
using Store.Services.Contracts;
using System.Linq;
using System.Text;

namespace Store.App.Commands
{
    public class ProductDetailsCommand : ICommand
    {
        private IProductService productService;

        public ProductDetailsCommand(IProductService productService)
        {
            this.productService = productService;
        }

        public string Execute(params string[] args)
        {
            var productId = int.Parse(args[0]);

            var product = this.productService.GetProductById<ProductDetailsDto>(productId);
            if(product == null)
            {
                return $"There are no product with id {productId}!";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Product name: {product.Name}");
            sb.AppendLine($"Product price: {product.Price}");
            sb.AppendLine($"Product content: {product.Content}");
            sb.AppendLine($"Product author: {product.Author}");

            if (product.Comments.Any())
            {
                sb.AppendLine("Comments:");
                foreach (var comment in product.Comments)
                {
                    sb.AppendLine($" - {comment.Content} by {comment.Author}");
                }
            }
            else
            {
                sb.AppendLine("Comments: none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
