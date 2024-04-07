using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class Post
	{
		public int Id { get; set; }
		[StringLength(60)]
		public string Title { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		[StringLength(1000)]
		public string Content { get; set; }

		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
		public int UserId { get; set; }
		public User User { get; set; } = null!;
	}
}
