using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
  public class CreateUserScreen
  {
    public static void Load()
    {
      Console.Clear();
      Console.WriteLine("Novo Usuário");
      Console.WriteLine("-------------");
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

      Create(new User
      {
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

    public static void Create(User user)
    {
      try
      {
        var repository = new Repository<User>(Database.Connection);
        repository.Create(user);
        Console.WriteLine("Usuário cadastrado com sucesso!");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Não foi possível cadastrar o usuário!");
        Console.WriteLine(ex);
      }
    }
  }
}