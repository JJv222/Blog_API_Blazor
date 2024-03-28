using Microsoft.EntityFrameworkCore;
using ModelsLibrary;

namespace Blog_API.Data
{
	public class BlogContext : DbContext
	{
		public DbSet<Comment> Comments { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Post> Posts { get; set; }


		public string DbPath { get; }

		public BlogContext(DbContextOptions<BlogContext> options): base(options)
		{ 
		}
	}
}
