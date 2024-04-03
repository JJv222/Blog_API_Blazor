using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string? Email { get; set; }
		public Role Role { get; set; }

		public ICollection<Post> Posts { get; set; } = new List<Post>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
