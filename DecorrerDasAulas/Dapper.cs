/*
using System;
using BaltaDataAccess.Model;
using BaltaDataAccses.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            //variavel de conexão 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
            //Meus using de conexão 
            using (var connection = new SqlConnection(connectionString))
            {
                //Meus métodos
                UpdateCategory(connection);
                ListCategorys(connection);
                //CreateCategory(connection);

            }
        }
        //Listando minha catgoria 
        static void ListCategorys(SqlConnection connection)
        {
            var categorys = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categorys)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
                Console.WriteLine("João gabriel");
            }
        }
        //Inserindo valores na minha categoria
        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Kabum";
            category.Url = "https: kabum.com";
            category.Description = "Venha comprar no melhor site do brasil";
            category.Order = 8;
            category.Summary = "João developer";
            category.Featured = false;
            var insert = @"INSERT INTO 
            [Category] 
            VALUES(
            @Id,
            @Title,
            @Url,
            @Description,
            @Order,
            @Summary,
            @Featured)";
            var linhasInsert = connection.Execute(insert, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Description,
                category.Order,
                category.Summary,
                category.Featured
            }
                );
            Console.WriteLine($"{linhasInsert} linhas inseridas");
        }
        //Executando o Update "Inserindo novos valores"
        static void UpdateCategory(SqlConnection connection)
        {
            var update = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
            var executeUpdate = connection.Execute(update, new
            {
                id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                title = "Joao developer front-end 2022"
            });
            Console.WriteLine($"{executeUpdate} Linhas nodificadas");
        }
    }
}
*/