﻿using Microsoft.Data.SqlClient;
using Modulo4.Blog.Screens.CategoryScreens;
using Modulo4.Blog.Screens.TagScreens;
using Modulo4.Blog.Screens.UserScreens;

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
        public static void Load()
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
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 3:
                    MenuCategoryScreens.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}