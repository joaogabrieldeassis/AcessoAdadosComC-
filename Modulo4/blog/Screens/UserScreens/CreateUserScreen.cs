using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.UserScreens
{
    public static class CreateUserScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu nome: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o seu email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Digite a sua senha: ");
            var password = Console.ReadLine();
            Console.WriteLine("Digite sua bio: ");
            var bio = Console.ReadLine();
            Console.WriteLine("Digite sua imagem: ");
            var image = Console.ReadLine();
            Console.WriteLine("Digite seu slug: ");
            var slug = Console.ReadLine();
            // InsertUser(new User
            // {
            //     Name = name,
            //     Email = email,
            //     PasswordHash = password,
            //     Bio = bio,
            //     Image = image,
            //     Slug = slug
            // });
            Console.ReadKey();
            Console.WriteLine("Usuario cadastrado com sucesso!\nPrecione enter para sair");
            MenuUserScreen.Load();
        }
        public static void InsertUser(User user)
        {
            try
            {
                var connectionUsr = new Repository<User>(Database.Connection);
                connectionUsr.Create(user);

            }
            catch (System.Exception)
            {

                Console.WriteLine("Usuario já cadastrado");
            }

        }
    }

}