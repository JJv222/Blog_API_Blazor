using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        public UserDto? User { get; set; }
		public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
