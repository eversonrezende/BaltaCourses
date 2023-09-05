using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{  
  class Program
  {
    static void Main(string[] args)
    {
      var connection = new SqlConnection(CONNECTION_STRING);
      connection.Open();
      ReadUsers(connection);
      //ReadUser();
      //CreateUser();
      //UpdateUser();
      //DeleteUser();
      connection.Close();
    }

    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=1q2w3e4r@#$;Integrated Security=false;TrustServerCertificate=true";

    public static void ReadUsers(SqlConnection connection)
    {
      var repository = new UserRepository(connection);
      var users = repository.Get();

      foreach (var user in users)
          Console.WriteLine(user.Name);
    }

    public static void ReadUser()
    {
      using var connection = new SqlConnection(CONNECTION_STRING);
      var user = connection.Get<User>(1);
      Console.WriteLine(user.Name);
    }

    public static void CreateUser()
    {
      var user = new User
      {
        Bio = "Equipe balta.io",
        Email = "hello@balta.io",
        Image = "https://...",
        Name = "Equipe Balta.io",
        PasswordHash = "HASH",
        Slug = "equipe-balta"
      };

      using var connection = new SqlConnection(CONNECTION_STRING);
      connection.Insert<User>(user);
      Console.WriteLine("Cadastro realizado com sucesso");
    }

    public static void UpdateUser()
    {
      var user = new User
      {
        Id = 2,
        Bio = "Equipe | balta.io",
        Email = "hello@balta.io",
        Image = "https://...",
        Name = "Equipe de suporte Balta.io",
        PasswordHash = "HASH",
        Slug = "equipe-balta"
      };

      using var connection = new SqlConnection(CONNECTION_STRING);
      connection.Update<User>(user);
      Console.WriteLine("Atualização realizada com sucesso");
    }

    public static void DeleteUser()
    {
      using var connection = new SqlConnection(CONNECTION_STRING);
      var user = connection.Get<User>(2);
      connection.Delete<User>(user);
      Console.WriteLine("Exclusão realizada com sucesso");
    }

  }
}
