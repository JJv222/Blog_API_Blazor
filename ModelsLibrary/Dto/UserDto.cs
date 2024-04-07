using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [StringLength(35)]
        public string Username { get; set; }
        [StringLength(60)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Password { get; set; }
        public Role Role { get; set; }
    }
}
