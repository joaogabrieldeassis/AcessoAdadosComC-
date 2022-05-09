using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.UserScreens
{
    public static class DeletUserScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o Id do usuario que deseja excluir");
            var id = Console.ReadLine();
            InsertUser(int.Parse(id));
            Console.ReadKey();
            Console.WriteLine("Usuario Deletado com sucesso");
            Console.WriteLine("Precione Enter para voltar ao Menu");
            MenuUserScreen.Load();
        }
        public static void InsertUser(int id)
        {
            try
            {
                var connectionDelet = new Repository<User>(Database.Connection);
                connectionDelet.Delete(id);


            }
            catch (System.Exception)
            {

                Console.WriteLine("Usuario não existente ou já excluido! Tente novamente");
            }

        }
    }

}