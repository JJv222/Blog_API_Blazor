using ModelsLibrary.UserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.PostDto
{
    public record class PostDtoCreateRequest
    {
        [StringLength(60)]
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [StringLength(1000)]
        public string Content { get; set; }
        public UserDto.UserDto User { get; set; }
    }
}
