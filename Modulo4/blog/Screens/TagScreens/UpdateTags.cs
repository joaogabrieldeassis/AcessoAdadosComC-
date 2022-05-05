using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.TagScreens
{
    public class UpdateTags
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando a Tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Id da tag :");
            var id = Console.ReadLine();
            Console.WriteLine("Nome :");
            var name = Console.ReadLine();
            Console.WriteLine("Slug : ");
            var slug = Console.ReadLine();
            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug

            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso");
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Não foi possivel atualizar a tag");
                Console.WriteLine(ex.Message);
            }


        }

    }
}
