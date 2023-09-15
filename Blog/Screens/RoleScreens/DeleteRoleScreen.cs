using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
  public class DeleteRoleScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Excluir um Perfil");
      Console.WriteLine("-------------");
      Console.WriteLine("Qual o ID do perfil que deseja excluir? ");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Delete(int.Parse(id));
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void Delete(int id)
    {
      try
      {
        var repository = new Repository<Role>(Database.Connection);
        repository.Delete(id);
        Console.WriteLine("Perfil excluído com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível excluir o perfil!");
        Console.WriteLine(ex);
      }
    }
  }
}