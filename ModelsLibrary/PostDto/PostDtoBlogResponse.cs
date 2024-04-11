using ModelsLibrary.UserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.PostDto
{
    public class PostDtoBlogResponse
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public UserDto.UserDto User { get; set; }
    }
}
