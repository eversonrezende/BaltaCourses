using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
  public class UpdateRoleScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Atualizando um Perfil");
      Console.WriteLine("-------------");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Nome: ");
      var nome = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Update(new Role
      {
        Id = int.Parse(id),
        Name = nome,
        Slug = slug
      });
      Console.ReadKey();
      MenuRoleScreen.Load();
    }

    public static void Update(Role role)
    {
      try
      {
        var repository = new Repository<Role>(Database.Connection);
        repository.Update(role);
        Console.WriteLine("Perfil atualizado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível atualizar o registro!");
        Console.WriteLine(ex);
      }
    }
  }
}