using Blog.Models;
using Dapper.Contrib.Extensions;

namespace Modulo4.Blog.Models
{
    //Buscar a tabela user no banco e sempre colocar os colchetes 
    [Table("[User]")]
    public class User
    {
        public User(List<Role> roles)
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}