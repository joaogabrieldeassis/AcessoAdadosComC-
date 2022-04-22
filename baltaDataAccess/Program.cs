using System;
using Microsoft.Data.SqlClient;
namespace BaltaDataAccess // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Conectando nosso banco 
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$";
            Console.WriteLine("Hello World!");
        }
    }
}