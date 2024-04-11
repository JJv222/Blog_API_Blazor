using ModelsLibrary.CommentDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.PostDto
{
    public class PostDtoPostResponse
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [StringLength(1000)]
        public string Content { get; set; }

        public UserDto.UserDto User { get; set; } = null!;

        public ICollection<CommentDtoPostResponse> Comments { get; set; } = new List<CommentDtoPostResponse>();

    }
}
