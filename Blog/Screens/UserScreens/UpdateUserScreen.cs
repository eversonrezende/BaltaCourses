using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
  public class UpdateUserScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Atualizando um Usuário");
      Console.WriteLine("-------------");
      Console.WriteLine("Id: ");
      var id = Console.ReadLine();

      Console.WriteLine("Nome: ");
      var nome = Console.ReadLine();

      Console.WriteLine("Email: ");
      var email = Console.ReadLine();

      Console.WriteLine("PasswordHash: ");
      var passwordHash = Console.ReadLine();

      Console.WriteLine("Bio: ");
      var bio = Console.ReadLine();

      Console.WriteLine("Imagem: ");
      var image = Console.ReadLine();

      Console.WriteLine("Slug: ");
      var slug = Console.ReadLine();

      Update(new User
      {
        Id = int.Parse(id),
        Name = nome,
        Email = email,
        PasswordHash = passwordHash,
        Bio = bio,
        Image = image,
        Slug = slug
      });
      Console.ReadKey();
      MenuUserScreen.Load();
    }

    public static void Update(User user)
    {
      try
      {
        var repository = new Repository<User>(Database.Connection);
        repository.Update(user);
        Console.WriteLine("Usuário atualizado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível salvar o usuário!");
        Console.WriteLine(ex);
      }
    }
  }
}