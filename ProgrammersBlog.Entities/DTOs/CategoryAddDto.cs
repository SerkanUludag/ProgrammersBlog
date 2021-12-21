using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class CategoryAddDto
    {
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(70, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Category Description")]
        [MaxLength(500, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Description { get; set; }

        [DisplayName("Category Private Note")]
        [MaxLength(500, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Note { get; set; }

        [DisplayName("Active")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool IsActive { get; set; }
    }
}
