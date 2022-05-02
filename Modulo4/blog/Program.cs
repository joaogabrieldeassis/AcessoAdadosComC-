using System;
using Modulo4.Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            ReadUser(connection);
            ReadRole(connection);
            connection.Close();

        }
        //Método para buscar no banco os user

        //Método para buscar no banco os users com o id
        public static void ReadRole(SqlConnection connection)
        {
            var receiveRoleRepository = new Repository<User>(connection);
            var roles = receiveRoleRepository.Get();

            foreach (var item in roles)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void ReadUser(SqlConnection connection)
        {
            var receiveUsers = new UserRepository(connection);
            var users = receiveUsers.Get();
            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}