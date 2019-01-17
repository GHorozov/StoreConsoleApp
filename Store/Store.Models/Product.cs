using System.Collections.Generic;

namespace Store.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, decimal price, string content, int categoryId, int authorId)
        {
            this.Name = name;
            this.Price = price;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
