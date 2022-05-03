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
        public T Get(int id)
        => _conection.Get<T>(id);
        public void Create(T model)
        => _conection.Insert<T>(model);

        public void Update(T model)
        => _conection.Update<T>(model);

        public void Delete(int id)
        {
            var model = _conection.Get<T>(id);
            _conection.Delete<T>(model);
        }
    }
}