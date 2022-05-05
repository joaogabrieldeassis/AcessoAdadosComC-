using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.TagScreens
{
    public static class CreatTags
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova Tag");
            Console.WriteLine("-------------");
            Console.WriteLine("Nome :");
            var name = Console.ReadLine();
            Console.WriteLine("Slug : ");
            var slug = Console.ReadLine();
            Create(new Tag
            {
                Name = name,
                Slug = slug

            });
            Console.ReadKey();
            Console.WriteLine("Tag cadastrada com sucesso");
            MenuTagScreen.Load();

        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
            }
            catch (System.Exception ex)
            {

                Console.WriteLine("Usuario já cadastrado");
                Console.WriteLine(ex.Message);
            }


        }
    }
}
