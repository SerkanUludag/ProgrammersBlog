using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class UserLoginDto
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} must be greater than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember me")]
        public bool RememberMe { get; set; }
    }
}
