using ModelsLibrary.CommentDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.PostDto
{
    public record PostDtoPutRequest
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        public string UsernName { get; set; }
    }
}
