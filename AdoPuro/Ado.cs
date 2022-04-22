using System;
using Microsoft.Data.SqlClient;
namespace AdoPuro // Note: actual namespace depends on the project name.
{
    public class Ado
    {
        static void Main(string[] args)
        {
            //Conectando nosso banco 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";
            //Conectando no baco com using
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Open bank");
                Console.WriteLine("Close Bank");
                //Abrinco o banco
                connection.Open();
                //Abrindo os comandos que vou utilizar
                using (var exeCommand = new SqlCommand())
                {
                    //Garantindo que a conexão está aberta  
                    exeCommand.Connection = connection;
                    //Tipo do comando que quero executar 
                    exeCommand.CommandType = System.Data.CommandType.Text;
                    //Quary que queremos executar no banco
                    exeCommand.CommandText = "SELECT [Id], [Title] From [Category]";

                    var reader = exeCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                    }
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}