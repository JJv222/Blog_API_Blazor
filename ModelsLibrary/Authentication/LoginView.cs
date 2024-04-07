using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Authentication
{
    public class LoginView
    {
        [Required(AllowEmptyStrings = false,ErrorMessage ="Please provide User Name")]
        public string? Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide User Password")]
        public string? Password { get; set; }

    }
}
