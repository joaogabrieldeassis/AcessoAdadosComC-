using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.TagScreens
{
    public class DeletTags
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando a Tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Id da tag que deseja excluir:");
            var id = Console.ReadLine();
            Delete(int.Parse(id));
            Console.ReadKey();
            Console.WriteLine("Tag excluida com sucesso");
            MenuTagScreen.Load();
        }
        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Não foi possivel excluir a tag");
                Console.WriteLine(ex.Message);
            }


        }

    }
}
