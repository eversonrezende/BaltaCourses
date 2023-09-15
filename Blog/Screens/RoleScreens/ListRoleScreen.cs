using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
  public class ListRoleScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Lista de Perfis");
      Console.WriteLine("-------------");
      List();
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void List()
    {
      var repository = new Repository<Role>(Database.Connection);
      var roles = repository.Get();

      foreach (var role in roles)
      {
        Console.WriteLine($"{role.Id} - {role.Name} ({role.Slug})");
      }
    }
  }
}