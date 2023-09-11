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
      ReadUsersWithRoles(connection);
      connection.Close();
    }

    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=blog;User ID=sa;Password=1q2w3e4r@#$;Integrated Security=false;TrustServerCertificate=true";

    public static void ReadUsers(SqlConnection connection)
    {
      var repository = new Repository<User>(connection);
      var items = repository.Get();

      foreach (var item in items)
        Console.WriteLine(item.Name);
    }

    public static void ReadUsersWithRoles(SqlConnection connection)
    {
      var repository = new UserRepository(connection);
      var items = repository.GetWithRoles();

      foreach (var item in items)
      {
        Console.WriteLine(item.Name);
        foreach (var role in items)
          Console.WriteLine($" - {role.Name}");
      }
    }

    public static void ReadRoles(SqlConnection connection)
    {
      var repository = new Repository<Role>(connection);
      var items = repository.Get();

      foreach (var item in items)
        Console.WriteLine(item.Name);
    }

    public static void ReadTags(SqlConnection connection)
    {
      var repository = new Repository<Tag>(connection);
      var items = repository.Get();

      foreach (var item in items)
        Console.WriteLine(item.Name);
    }

  }
}
