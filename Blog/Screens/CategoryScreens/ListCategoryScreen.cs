using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.CategoryScreens
{
  public class ListCategoryScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Lista de Category");
      Console.WriteLine("-------------");
      List();
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void List()
    {
      var repository = new Repository<Category>(Database.Connection);
      var items = repository.Get();

      foreach (var item in items)
      {
        Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
      }
    }
  }
}