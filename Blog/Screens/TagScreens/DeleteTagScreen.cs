using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
  public class DeleteTagScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Excluir uma Tag");
      Console.WriteLine("-------------");
      Console.WriteLine("Qual o ID da tag que deseja excluir? ");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Delete(int.Parse(id));
      Console.ReadKey();
      MenuTagScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Tag>(Database.Connection);
        repository.Delete(id);
        Console.WriteLine("Tag excluida com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível excluir a tag");
        Console.WriteLine(ex);
      }
    }
  }
}
