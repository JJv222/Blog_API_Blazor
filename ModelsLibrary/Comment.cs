using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class Comment
	{
		public int Id { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
		public string Content { get; set; }

		public int PostId { get; set; }
		public Post Post { get; set; } = null!;

		public int UserId { get; set; }
		public User User { get; set; } = null!;
	}
}
