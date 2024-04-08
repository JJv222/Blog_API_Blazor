using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        public UserDto? User { get; set; }
    }
}
