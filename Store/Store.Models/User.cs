using System.Collections.Generic;

namespace Store.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
