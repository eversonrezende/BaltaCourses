using Blog.Screens.CategoryScreens;

namespace Blog.Screens.RoleScreens
{
  public class MenuCategoryScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Gestão de Categoria");
      Console.WriteLine("--------------");
      Console.WriteLine("O que deseja fazer?");
      Console.WriteLine();
      Console.WriteLine("1 - Listar categoria");
      Console.WriteLine("2 - Cadastrar categoria");
      Console.WriteLine("3 - Atualizar categoria");
      Console.WriteLine("4 - Deletar categoria");
      var option = short.Parse(Console.ReadLine());

      switch (option)
      {
        case 1:
          ListCategoryScreen.Load();
          break;
        case 2:
          CreateCategoryScreen.Load();
          break;
        case 3:
          UpdateCategoryScreen.Load();
          break;
        case 4:
          DeleteCategoryScreen.Load();
          break;
        default:
          Load();
          break;
      }
    }
  }
}