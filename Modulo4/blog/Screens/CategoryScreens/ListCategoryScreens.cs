using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;
using Modulo4.Blog.Screens.CategoryScreens;

namespace Modulo4.Blog.Screens
{
    public static class ListCategoryScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista da Categoria");
            SelectCategory();
            Console.ReadKey();
            MenuCategoryScreens.Load();
        }
        public static void SelectCategory()
        {
            var create = new Repository<Category>(Database.Connection);
            var receiveListCategory = create.Get();
            foreach (var item in receiveListCategory)
            {
                Console.WriteLine($"Id: {item.Id} \nName: {item.Name} \nSlug: {item.Slug}");
            }
        }
    }
}