using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;

namespace Blog.Screens.CategoryScreens
{
  public class DeleteCategoryScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Excluir uma Categoria");
      Console.WriteLine("-------------");
      Console.WriteLine("Qual o ID da categoria que deseja excluir? ");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Delete(int.Parse(id));
      Console.ReadKey();
      MenuCategoryScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Category>(Database.Connection);
        repository.Delete(id);
        Console.WriteLine("Categoria deletada com sucesso");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível deletar a categoria!");
        Console.WriteLine(ex);
      }
    }
  }
}