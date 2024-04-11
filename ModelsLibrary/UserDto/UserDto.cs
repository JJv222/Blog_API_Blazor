using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.UserDto
{
    public class UserDto
    {
        [StringLength(35)]
        public string Username { get; set; } = null!;
        [StringLength(60)]
        public string? Email { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
