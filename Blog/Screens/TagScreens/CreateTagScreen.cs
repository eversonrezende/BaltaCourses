using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public class CreateTagScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Nova Tags");
      Console.WriteLine("-------------");
      Console.WriteLine("Nome: ");
      var nome = Console.ReadLine();
      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Create(new Tag
      {
        Name = nome,
        Slug = slug
      });
      Console.ReadKey();
      MenuTagScreen.Load();
    }

    public static void Create(Tag tag)
    {
      try
      {
        var repository = new Repository<Tag>(Database.Connection);
        repository.Create(tag);
        Console.WriteLine("Tag cadastrada com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar a tag");
        Console.WriteLine(ex);
      }
    }
  }
}
