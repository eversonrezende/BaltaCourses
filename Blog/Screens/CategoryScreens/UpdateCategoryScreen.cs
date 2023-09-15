using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.CategoryScreens
{
  public class UpdateCategoryScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Atualizando uma Categoria");
      Console.WriteLine("-------------");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Nome: ");
      var nome = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Update(new Category
      {
        Id = int.Parse(id),
        Name = nome,
        Slug = slug
      });
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Update(Category category)
    {
      try
      {
        var repository = new Repository<Category>(Database.Connection);
        repository.Update(category);
        Console.WriteLine("Categoria atualizada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar a categoria!");
        Console.WriteLine(ex);
      }
    }
  }
}