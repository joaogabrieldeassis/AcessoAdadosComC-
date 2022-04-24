using System;
using BaltaDataAccses.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaDataAccess // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";
            using (var connection = new SqlConnection(connectionString))
            {
                var categorys = connection.Query<Category>("SELECT [Id], [Title] FROM [Category");
                foreach (var item in categorys)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                    Console.WriteLine("João");
                }
            }
        }
    }
}