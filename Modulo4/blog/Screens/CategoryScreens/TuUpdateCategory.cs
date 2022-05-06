using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;
using Modulo4.Blog.Screens.CategoryScreens;

namespace Modulo4.Blog.Screens
{
    public static class TuUpdateCategory
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o id que deseja atualizar:");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite um novo nome: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite a nova Slug: ");
            var slug = Console.ReadLine();
            Update(new Category
            {
                Id = id,
                Name = name,
                Slug = slug
            });

        }
        public static void Update(Category category)
        {
            try
            {
                var receiveCategory = new Repository<Category>(Database.Connection);
                receiveCategory.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!\nPrecione Enter para sair");
                Console.ReadKey();
                MenuCategoryScreens.Load();

            }
            catch (System.Exception)
            {

                Console.WriteLine("Categoria já cadastrado");
                Console.ReadKey();
                MenuCategoryScreens.Load();

            }

        }
    }
}