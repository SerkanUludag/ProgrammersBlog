using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.Concrete
{
    public class AboutUsPageInfo
    {
        [DisplayName("Header")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(150, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Header { get; set; }
        [DisplayName("Content")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(1500, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Content { get; set; }
        [DisplayName("Seo Description")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoDescription { get; set; }
        [DisplayName("Seo Tags")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoTags { get; set; }
        [DisplayName("Seo Author")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(60, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoAuthor { get; set; }

    }
}
