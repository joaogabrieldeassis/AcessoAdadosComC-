using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Modulo4.Blog.Models;

namespace Modulo4.Blog.Repositories
{
    public class UserRepository
    {
        // Em vez de ficarmos abrindo sempre uma nova conexão a cada query, podemos reaproveitar uma conexão para todos os nossos métodos com o método construtor
        // E como a não faz sentido outras pessoas ficarem atribuiando a conexão, fazemos ela somente de leitura com a palavra reservada readonly
        private readonly SqlConnection _conection;
        public UserRepository(SqlConnection connection)
        {
            _conection = connection;
        }
        // Como o retorno do GetAll já é um IEnumerable retornamos ele
        // E como toda função local é privada e só pode ser chamada pelo método que a contem eu fiz elá dessa forma
        // E com o _connection todos os meus métodos vão receber ele por causa da sua conexão aberta 
        public IEnumerable<User> Get()
            => _conection.GetAll<User>();


    }
}