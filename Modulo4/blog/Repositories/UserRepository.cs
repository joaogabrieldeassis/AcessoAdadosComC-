using Blog.Models;
using Dapper;
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

        // Ler os usuarios de Role e retornar na tela
        public List<User> GetWithRoles()
        {
            var query = @"
            SELECT
                [User].*,
                [Role].*
            FROM 
                [User] 
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
            ";
            //Criando a lista de usuarios e retornando ela
            var users = new List<User>();
            var items = _conection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else

                        usr.Roles.Add(role);
                    return user;
                }, splitOn: "Id"
            );
            return users;
        }
    }
}