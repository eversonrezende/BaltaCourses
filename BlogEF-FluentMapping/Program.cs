using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
  static void Main(string[] args)
  {
    using var context = new BlogDataContext();
    var posts = GetPosts(context, 0, 25);
  }

  public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
  {
    var posts = context
                .Posts
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToList();

    return posts;
  }
}
