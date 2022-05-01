using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Modulo4.Blog.Models;

namespace Modulo4.Blog.Repositories
{
    public class UserRepository
    {
        private readonly SqlConnection _conectionUser;
        public UserRepository(SqlConnection connection)
        {
            _conectionUser = connection;
        }
        public IEnumerable<User> Get()
        => _conectionUser.GetAll<User>();
        public User Get(int id)
        => _conectionUser.Get<User>(id);
        public void Create(User user)
        => _conectionUser.Insert<User>(user);

    }
}