using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Modulo4.Blog.Models;

namespace Modulo4.Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _conection;
        public Repository(SqlConnection connection)
            => _conection = connection;
        public IEnumerable<T> Get()
            => _conection.GetAll<T>();
    }
}