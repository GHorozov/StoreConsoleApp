using System.Collections.Generic;

namespace Store.App.Models
{
    public class ProductDetailsDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
