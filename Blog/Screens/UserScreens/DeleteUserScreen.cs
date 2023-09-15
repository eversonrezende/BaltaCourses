using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
  public class DeleteUserScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Excluir um Usuário");
      Console.WriteLine("-------------");
      Console.WriteLine("Qual o ID do usuário que deseja excluir? ");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Delete(int.Parse(id));
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<User>(Database.Connection);
        repository.Delete(id);
        Console.WriteLine("Usuário excluído com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível excluir o usuário!");
        Console.WriteLine(ex);
      }
    }
  }
}