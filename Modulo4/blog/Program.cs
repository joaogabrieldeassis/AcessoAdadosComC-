using System;
using Modulo4.Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Modulo4.Blog.Repositories;
using Dapper;

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
            ReadTag(connection);
            InsertTag(connection);
            DeletUser(connection);
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
            var receiveUsers = new Repository<Role>(connection);
            var users = receiveUsers.Get();
            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
            }

        }
        public static void ReadTag(SqlConnection connection)
        {
            var receiveTag = new Repository<Tag>(connection);
            var receiveAnReceiveTag = receiveTag.Get();
            foreach (var item in receiveAnReceiveTag)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void InsertTag(SqlConnection connection)
        {
            var receiveTag = new Repository<Tag>(connection);
            var update = "UPDATE [Tag] SET [Name] = @Name WHERE [Id] = @id";
            var receiveUpdate = connection.Execute(update, new
            {
                id = "1",
                name = "João arquiteto senior"
            });
            Console.WriteLine($"Linha inserida {receiveUpdate}");

        }
        public static void DeletUser(SqlConnection connection)
        {
            var receiveUser = new Repository<User>(connection);
            var delete = "DELETE FROM [Role] WHERE [Id] = 4";
            var receiveDelet = connection.Execute(delete);
            Console.WriteLine($"Linha afetada {receiveDelet}");

        }
    }
}