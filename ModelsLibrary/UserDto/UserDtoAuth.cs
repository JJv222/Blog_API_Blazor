using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.UserDto
{
    public class UserDtoAuth
    {
        [StringLength(35)]
        public string Username { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(60)]
        public string? Email { get; set; }
        public Role Role { get; set; }
    }
}
