using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProgrammersBlog.Web.Areas.Admin.Models
{
    public class ArticleUpdateViewModel
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Header")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Title { get; set; }

        [DisplayName("Context")]
        [Required(ErrorMessage = "{0} is required.")]
        [MinLength(20, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        public string Thumbnail { get; set; }

        [DisplayName("Add Thumbnail")]
        public IFormFile ThumbnailFile { get; set; }

        [DisplayName("Date Of Article")]
        [Required(ErrorMessage = "{0} is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Author Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Article Description")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(150, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(0, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoDescription { get; set; }

        [DisplayName("Article Tags")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(70, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string SeoTags { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} is required.")]
        public int CategoryId { get; set; }

        [DisplayName("Active")]
        [Required(ErrorMessage = "{0} is required.")]
        public bool IsActive { get; set; }

        [Required]
        public int UserId { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
