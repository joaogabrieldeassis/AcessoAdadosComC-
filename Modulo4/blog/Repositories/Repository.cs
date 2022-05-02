using Microsoft.Data.SqlClient;

namespace Modulo4.Blog.Repositories
{
    public class Repository
    {
        private readonly SqlConnection _conection;
        public UserRepository(SqlConnection connection)
            => _conection = connection;
    }
}