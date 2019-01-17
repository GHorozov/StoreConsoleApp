using System.Collections.Generic;

namespace Store.Models
{
    public class Category
    {
        public Category()
        {
        }

        public Category(string name)
        {
            this.Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
