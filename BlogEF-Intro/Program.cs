using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
  private static void Main(string[] args)
  {
    #region Create
    using (var context = new BlogDataContext())
    {
      //var tag = new Tag { Name = "Angular", Slug = "angular" };
      //context.Add(tag);
      //context.SaveChanges();

      // var tag1 = new Tag { Name = "Blazor", Slug = "blazor" };
      // context.Add(tag1);
      // context.SaveChanges();
    }
    #endregion

    #region Update
    // using var context = new BlogDataContext();
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // if (tag != null)
    // {
    //   tag.Name = ".Net";
    //   tag.Slug = "dotnet";
    //   context.Update(tag);
    //   context.SaveChanges();
    //   Console.WriteLine("Registro atualizado!");
    // }
    // else
    // {
    //   Console.WriteLine("Não foi possível atualizar o registro!");
    // }
    #endregion

    #region Delete

    // using (var context = new BlogDataContext())
    // {
    //   var tag = context.Tags.FirstOrDefault(x => x.Id == 2);

    //   if (tag != null)
    //   {
    //     context.Remove(tag);
    //     context.SaveChanges();
    //     Console.WriteLine("Registro excluído com sucesso!");
    //   }
    //   else
    //   {
    //     Console.WriteLine("Não foi possível excluir o registro!");
    //   }
    // }

    #endregion

    #region Read

    using (var context = new BlogDataContext())
    {
      //A query só é executada no banco quando informa o ToList, FirstOrDefault, etc..
      //Sempre usar esses por último na consulta
      //Quando for apenas leitura usar AsNoTracking()


      var tags = context
                  .Tags
                  .AsNoTracking()
                  .ToList();

      foreach (var item in tags)
      {
        Console.WriteLine(item.Name);
      }

      var tag = context
                .Tags
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == 3);

      Console.WriteLine(tag?.Name);
    }

    #endregion
  }
}
