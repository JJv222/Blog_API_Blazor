using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class User
	{
		public int Id { get; set; }
		[StringLength(35)]
		public string Username { get; set; }
		[StringLength(100)]
		public string Password { get; set; }
		[StringLength(60)]
		public string? Email { get; set; }
		public Role Role { get; set; }

		public ICollection<Post> Posts { get; set; } = new List<Post>();
		public ICollection<Comment> Comments { get; set; } = new List<Comment>();
	}
}
