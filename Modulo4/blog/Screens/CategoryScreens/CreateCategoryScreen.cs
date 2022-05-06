using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;

namespace Modulo4.Blog.Screens.CategoryScreens
{
    public static class CreateCategoryScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da categoria: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite o slug de categoria: ");
            var slug = Console.ReadLine();
            Create(new Category
            {
                Name = name,
                Slug = slug
            });
            Console.WriteLine("Categoria cadastrada com sucesso");
        }
        private static void Create(Category category)
        {
            try
            {
                var create = new Repository<Category>(Database.Connection);
                create.Create(category);
                MenuCategoryScreens.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Categoria já existente");
            }

        }
    }
}