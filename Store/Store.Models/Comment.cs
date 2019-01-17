namespace Store.Models
{
    public class Comment
    {
        public Comment()
        {
        }

        public Comment(string content, int productId, int authorId)
        {
            this.Content = content;
            this.ProductId = productId;
            this.AuthorId = authorId;
        }

        

        public int Id { get; set; }

        public string Content { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}
