using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
  private static void Main(string[] args)
  {
    using var context = new BlogDataContext();

    // var user = new User
    // {
    //   Name = "André Baltieri",
    //   Slug = "andrebaltieri",
    //   Email = "andre@balta.io",
    //   Bio = "9x Microsoft MVP",
    //   Image = "https://balta.io",
    //   PasswordHash = "1234567"
    // };

    // var category = new Category
    // {
    //   Name = "Backend",
    //   Slug = "backend"
    // };

    // var post = new Post
    // {
    //   Author = user,
    //   Category = category,
    //   Body = "<p>Hello World</p>",
    //   Slug = "comecando-com-ef-core",
    //   Summary = "Neste artigo vamos aprender EF core",
    //   Title = "Começando com EF Core",
    //   CreateDate = DateTime.Now,
    //   LastUpdateDate = DateTime.Now
    // };

    // context.Posts.Add(post);
    // context.SaveChanges();

    // var posts = context
    //             .Posts
    //             .AsNoTracking()
    //             .Include(x => x.Author)
    //             .Include(x => x.Category)
    //             .OrderByDescending(x => x.LastUpdateDate)
    //             .ToList();

    // foreach (var post in posts)
    //   Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category.Name}");

    var posts = context
                .Posts
                //.AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.LastUpdateDate)
                .FirstOrDefault();

    posts.Author.Name = "Teste";

    context.Posts.Update(posts);
    context.SaveChanges();

  }
}
