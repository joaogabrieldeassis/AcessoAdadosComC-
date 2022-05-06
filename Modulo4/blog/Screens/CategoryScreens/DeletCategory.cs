using Modulo4.Blog.Models;
using Modulo4.Blog.Repositories;
using Modulo4.Blog.Screens.CategoryScreens;

namespace Modulo4.Blog.Screens
{
    public static class DeletCategory
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Digite o Id da Categoria que deseja excluir");
            var id = int.Parse(Console.ReadLine()!);
            Delet(new Category
            {
                Id = id
            });
            Console.WriteLine("Categoria excluida com sucesso");
            MenuCategoryScreens.Load();
        }
        public static void Delet(Category category)
        {
            var receiveConnection = new Repository<Category>(Database.Connection);
            receiveConnection.Delete(category.Id);

        }
    }
}