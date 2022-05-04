using Microsoft.Data.SqlClient;
using Modulo4.Blog.Screens.TagScreens;

namespace Modulo4.Blog // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private const string connectionString = "Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(connectionString);
            Database.Connection.Open();

            Load();
            Console.ReadKey();
            Database.Connection.Close();
        }
        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("------------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine(" 1 - Gestão de usuarios ");
            Console.WriteLine(" 2 - Gestão de perfil");
            Console.WriteLine(" 3 - Gestão de categorias ");
            Console.WriteLine(" 4 - Gestão de tags");


            // O ! serve para forçar o usuario a digitar e não deixar nula 
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 4:
                    MenuTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}