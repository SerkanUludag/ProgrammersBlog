using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class EmailSendDto
    {
        [DisplayName("Your Name")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(60, ErrorMessage = "{0} field should be max {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field should be min {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Your E-Mail Address")]
        [DataType(DataType.EmailAddress)]           // DataType
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(60, ErrorMessage = "{0} field should be max {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field should be min {1} characters.")]
        public string Email { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(125, ErrorMessage = "{0} field should be max {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} field should be min {1} characters.")]
        public string Subject { get; set; }

        [DisplayName("Your Message")]
        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(1500, ErrorMessage = "{0} field should be max {1} characters.")]
        [MinLength(20, ErrorMessage = "{0} field should be min {1} characters.")]
        public string Message { get; set; }
    }
}
