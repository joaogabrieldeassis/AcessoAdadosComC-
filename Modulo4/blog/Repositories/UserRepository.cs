using Microsoft.Data.SqlClient;
using Modulo4.Blog.Models;

namespace Modulo4.Blog.Repositories
{
    //Essa classe sera para ler o meus usuarios e meu Role juntos 
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _conection;
        public UserRepository(SqlConnection connection)
        : base(connection)
            => _conection = connection;
    }
}