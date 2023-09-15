using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
  public class ListUserScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Lista de Usuários");
      Console.WriteLine("-------------");
      List();
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void List()
    {
      var repository = new UserRepository(Database.Connection);
      var items = repository.GetWithRoles();

      foreach (var item in items)
      {
        Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
        foreach (var role in item.Roles)
          Console.WriteLine($" - {role.Name}");
      }

    }
  }
}