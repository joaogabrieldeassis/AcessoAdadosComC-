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
        }
        private static void List()
        {
            var repository = new Repository<Tag>(Database.Connection);
            var tags = repository.Get();
            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Name}-{item.Id}({item.Slug})");
            }
        }
    }
}
