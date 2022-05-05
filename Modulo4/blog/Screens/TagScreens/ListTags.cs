using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.TagScreens
{
    public class ListTags
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Tags");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
            {
                Console.WriteLine($"Id: {item.Id}\n Nome: {item.Name} Slug: ({item.Slug})");
            }
        }
    }
}
