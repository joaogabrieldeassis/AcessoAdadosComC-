namespace Modulo4.Blog.Screens.TagScreens
{
    public class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Tags");
            Console.WriteLine("------------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine();
            Console.WriteLine(" 1 - Listar as tags ");
            Console.WriteLine(" 2 - Cadastrar as tags ");
            Console.WriteLine(" 3 - Atualizar as tags ");
            Console.WriteLine(" 4 - Deletar as tags ");
            Console.WriteLine(" 5 - Voltar ao Menu");
            // O ! serve para forçar o usuario a digitar e não deixar nula 
            var option = short.Parse(Console.ReadLine()!);
            switch (option)
            {
                case 1:
                    ListTags.Load();
                    break;
                case 2:
                    CreatTags.Load();
                    break;
                case 3:
                    UpdateTags.Load();
                    break;
                case 4:
                    DeletTags.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}