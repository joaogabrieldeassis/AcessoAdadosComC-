namespace Modulo4.Blog.Screens.CategoryScreens
{
    public class MenuCategoryScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Categorias");
            Console.WriteLine("------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine(" 1 - Cadastrar uma categoria");
            Console.WriteLine(" 2 - Listar uma categoria");
            Console.WriteLine(" 3 - Atualizar uma categoria");
            Console.WriteLine(" 4 - Deletar uma categoria");
            var receiveCategory = int.Parse(Console.ReadLine()!);
            switch (receiveCategory)
            {
                case 1:
                    CreateCategoryScreens.Load();
                    break;
                case 2:
                    ListCategoryScreens.Load();
                    break;
                case 3:
                    TuUpdateCategory.Load();
                    break;
                case 4:
                    TuUpdateCategory.Load();
                    break;
                default:
                    break;
            }
        }
    }
}