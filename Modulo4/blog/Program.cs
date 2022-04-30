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
            //ReadUsers();
            //ReadUser();
            // CreateUser();
            //UpdateUser();
            //DeleteUser();
            connection.Close();

        }
        //Método para buscar no banco os user

        //Método para buscar no banco os users com o id
        public static void ReadUser(SqlConnection connection)
        {
            var receiveUserRepository = new UserRepository(connection);
            var users = receiveUserRepository.Get();
            foreach (var item in users)
            {
                Console.WriteLine(users);
            }

        }
        //Inserindo informações no banco com o método Insert
        public static void CreateUser()
        {
            var user = new User()
            {
                Bio = "Joao",
                Email = "Joao@ifaksjaopifh",
                Name = "João e mari",
                PasswordHash = "akfihjaafo",
                Slug = "aófkd",
                Image = "https/Joaogostoso"

            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Insert<User>(user);

                Console.WriteLine("Usuario cadastrado");


            }

        }
        // Fazendo o update com o método abaixo
        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 4,
                Bio = "Joao",
                Email = "Joao@ifaksjaopifh",
                Name = "João e mari casa carro",
                PasswordHash = "akfihjaafo",
                Slug = "aófkd",
                Image = "https/Joaogostoso"

            };
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Update<User>(user);

                Console.WriteLine("Usuario cadastrado");


            }

        }
        // Excluindo um usuario com 
        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                //Get busca só o usuario com o id 1
                var user = connection.Get<User>(1);
                connection.Delete<User>(user);

                Console.WriteLine("Usuario Excluido");


            }

        }
    }
}