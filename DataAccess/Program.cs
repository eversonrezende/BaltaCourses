using BaltaDataAccess.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;
using DataAccess.Models;

const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Integrated Security=false;TrustServerCertificate=true";

using(var connection = new SqlConnection(connectionString))
{
  //ExecuteProcedure(connection);
  //ExecuteReadProcedure(connection);
  //CreateManyCategory(connection);
  //UpdateCategory(connection);
  //ExecuteReadProcedure(connection);
  //ExecuteScalar(connection);
  //ListCategories(connection);
  //CreateCategory(connection);
  //ReadView(connection);
  //OneToOne(connection);
  //OneToMany(connection);
  //QueryMultiple(connection);
  //SelectIn(connection);
  //Like(connection, "backend");
  Transaction(connection);
}

#region Consultas
  static void ListCategories(SqlConnection connection)
  {
    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
    foreach(var item in categories)
    {
      Console.WriteLine($"({item.Id} - {item.Title})");
    }
  }

  static void CreateCategory(SqlConnection connection)
  {
    var category = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Amazon AWS",
        Url = "amazon",
        Order = 8,
        Description = "Categoria destinada a serviços da Amazon",
        Featured = false,
        Summary = "AWS Cloud"
    };

    var insertSql = @"INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, new {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
    });

    Console.WriteLine($"{rows} linhas inseridas");
  }

  static void CreateManyCategory(SqlConnection connection)
  {
    var category = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Azure",
        Url = "azure",
        Order = 9,
        Description = "Categoria destinada a serviços da Azure",
        Featured = false,
        Summary = "Azure"
    };

    var category2 = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Categoria Nova",
        Url = "categoria-nova",
        Order = 10,
        Description = "Categoria Nova",
        Featured = false,
        Summary = "Categoria"
    };

    var insertSql = @"INSERT INTO [Category] VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, new[] 
    {
      new 
      {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
      },
      new 
      {
      category2.Id,
      category2.Title,
      category2.Url,
      category2.Summary,
      category2.Order,
      category2.Description,
      category2.Featured
      }
    });

    Console.WriteLine($"{rows} linhas inseridas");
  }

  static void UpdateCategory(SqlConnection connection)
  {
    var updateQuery = "UPDATE [Category] SET [Title] = @title WHERE [Id] = @id";
    var rows = connection.Execute(updateQuery, new 
    {
      id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
      title = "FrontEnd 2023"
    });

    Console.WriteLine($"{rows} registros atualizados");
  }

  static void ExecuteProcedure(SqlConnection connection)
  {
    var procedure = "spDeleteStudent";
    var pars = new { StudentId = new Guid("e6eb49e3-0a4e-4aea-af59-2d54625706b0") };

    var affectedRows = connection.Execute(
      procedure, 
      pars, 
      commandType: CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} linhas afetadas");
  }

  static void ExecuteReadProcedure(SqlConnection connection)
  {
    var procedure = "spGetCoursesByCategory";
    var pars = new { CategoryId = new Guid("09ce0b7b-cfca-497b-92c0-3290ad9d5142") };

    var courses = connection.Query(
      procedure, 
      pars, 
      commandType: CommandType.StoredProcedure);

    foreach(var item in courses)
    {
      Console.WriteLine($"{item.Id} - {item.Title}");
    }
  }

  static void ExecuteScalar(SqlConnection connection)
  {
      var category = new Category
    {
        Title = "Oracle Cloud",
        Url = "oraclecld",
        Order = 12,
        Description = "Categoria destinada a serviços da Oracle",
        Featured = false,
        Summary = "Oracle Cloud"
    };

    var insertSql = @"
    INSERT INTO 
      [Category]
      OUTPUT INSERTED.[ID] 
      VALUES (
        NEWID(), 
        @Title, 
        @Url, 
        @Summary, 
        @Order, 
        @Description, 
        @Featured)";

    var id = connection.ExecuteScalar<Guid>(insertSql, new {
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured
    });

    Console.WriteLine($"A categoria inserida foi: {id}");
  }

  static void ReadView(SqlConnection connection)
  {
    var sql = "SELECT * FROM [vwCourses]";
    var courses = connection.Query(sql);

    foreach(var item in courses)
    {
      Console.WriteLine($"{item.ID} - {item.Title}");
    }
  }
#endregion

#region Consultas Múltiplas e Joins
static void OneToOne(SqlConnection connection)
{
  var sql = @"
    SELECT 
      * 
    FROM 
      [CareerItem] 
    INNER JOIN 
      [Course] ON [CareerItem].[CourseId] = [Course].[Id]";

  var items = connection.Query<CareerItem, Course, CareerItem>(
    sql,
    (careerItem, course) => {
      careerItem.Course = course;
      return careerItem;
    },
    splitOn: "Id");

  foreach(var item in items)
  {
    Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
  }
}

static void OneToMany(SqlConnection connection)
{
  var sql = @"
    SELECT 
      [Career].[Id],
      [Career].[Title],
      [CareerItem].[CareerId],
      [CareerItem].[Title]
    FROM 
      [Career] 
    INNER JOIN 
      [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
    ORDER BY
      [Career].[Title];";

  var careers = new List<Career>();
  var items = connection.Query<Career, CareerItem, Career>(
    sql,
    (career, item) => 
    {
      var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();
      if(car == null)
      {
        car = career;
        car.Items.Add(item);
        careers.Add(car);
      }
      else 
      {
        car.Items.Add(item);
      }
      return career;
    },
    splitOn: "CareerId");

  foreach(var career in careers)
  {
    Console.WriteLine($"{career.Title}");

    foreach(var item in career.Items)
    {
      Console.WriteLine($" - {item.Title}");
    }
  }

}

static void QueryMultiple(SqlConnection connection)
{
  var query = "SELECT * FROM [Category]; SELECT * FROM [Course];";

  using(var multi = connection.QueryMultiple(query))
  {
    var categories = multi.Read<Category>();
    var courses = multi.Read<Course>();

    foreach(var item in categories)
    {
      Console.WriteLine($"Categoria: {item.Title}");
    }
    foreach(var item in courses)
    {
      Console.WriteLine($"Curso: {item.Title}");
    }
  }
}

static void SelectIn(SqlConnection connection)
{
  var query = @"
    SELECT 
      * 
    FROM 
      Career 
    WHERE 
      Id IN @Id";

  var item = connection.Query<Career>(query, new 
  {
    Id = new[] { "4327ac7e-963b-4893-9f31-9a3b28a4e72b","e6730d1c-6870-4df3-ae68-438624e04c72" }
  });

  foreach(var career in item)
  {
    Console.WriteLine($"{career.Title}");
  }
}

static void Like(SqlConnection connection, string term)
{
  var query = @"
    SELECT 
      * 
    FROM 
      Course 
    WHERE 
      Title LIKE @exp";

  var item = connection.Query<Course>(query, new 
  {
    exp = $"%{term}%"
  });

  foreach(var career in item)
  {
    Console.WriteLine($"{career.Title}");
  }
}

static void Transaction(SqlConnection connection)
{
    var category = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Minha categoria que não",
        Url = "amazon",
        Description = "Categoria destinada a serviços do AWS",
        Order = 8,
        Summary = "AWS Cloud",
        Featured = false
    };

    var insertSql = @"INSERT INTO 
          [Category] 
      VALUES(
          @Id, 
          @Title, 
          @Url, 
          @Summary, 
          @Order, 
          @Description, 
          @Featured)";

  connection.Open();
    using var transaction = connection.BeginTransaction();
    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    }, transaction);

    transaction.Commit();
    // transaction.Rollback();

    Console.WriteLine($"{rows} linhas inseridas");
}
#endregion
