namespace Modulo4.Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu user ");
            Console.WriteLine("----------------");
            Console.WriteLine("O que deseja fazer ?");
            Console.WriteLine(" 1 - Cadastrar um usuario ");
            Console.WriteLine(" 2 - Atualizar os dados de um usuario");
            Console.WriteLine(" 3 - Deletar um usuario");
            Console.WriteLine(" 4 - Listar um usuario");
            Console.WriteLine(" 5 - voltar para o menu");
            var receiveSelection = int.Parse(Console.ReadLine()!);
            switch (receiveSelection)
            {
                case 1:
                    CreateUserScreens.Load();
                    break;
                case 2:
                    UpdateUserScreen.Load();
                    break;
                case 3:
                    DeletUserScreens.Load();
                    break;
                case 4:
                    ListUserScreens.Load();
                    break;
                case 5:
                    Program.Load();
                    break;
                default:
                    MenuUserScreen.Load();
                    break;
            }
        }

    }

}