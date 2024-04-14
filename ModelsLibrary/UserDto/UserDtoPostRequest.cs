using ModelsLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.UserDto
{
    public class UserDtoPostRequest
    {
        [StringLength(35)]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [StringLength(60)]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
    }
}
