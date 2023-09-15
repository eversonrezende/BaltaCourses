using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.CategoryScreens
{
  public class CreateCategoryScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Nova Categoria");
      Console.WriteLine("-------------");
      Console.WriteLine("Nome: ");
      var nome = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Create(new Category
      {
        Name = nome,
        Slug = slug
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Create(Category category)
    {
      try
      {
        var repository = new Repository<Category>(Database.Connection);
        repository.Create(category);
        Console.WriteLine("Categoria cadastrada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível cadastrar uma categoria!");
        Console.WriteLine(ex);
      }
    }
  }
}