using Store.App.Commands.Contracts;
using System.Text;

namespace Store.App.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Commands:");
            sb.AppendLine("Register (username, password)");
            sb.AppendLine("Login (username, password)");
            sb.AppendLine("Logout");
            sb.AppendLine("AddProduct (categoryName, productName, productPrice, content)");
            sb.AppendLine("ProductDetails (productId)");
            sb.AppendLine("ListProducts");
            sb.AppendLine("Deposit (depositSum)");
            sb.AppendLine("ChangePassword (newPassword)");
            sb.AppendLine("AddComment {productId, content}");
            sb.AppendLine("WhoAmI");
            sb.AppendLine("Exit");

            return sb.ToString().TrimEnd();
        }
    }
}
