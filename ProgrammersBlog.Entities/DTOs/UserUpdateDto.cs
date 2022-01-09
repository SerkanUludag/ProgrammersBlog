﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entity.DTOs
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} must be greater than {1} characters.")]
        public string UserName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(100, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} must be greater than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(13, ErrorMessage = "{0} must be less than {1} characters.")]
        [MinLength(13, ErrorMessage = "{0} must be greater than {1} characters.")]
        [DataType(DataType.Password)]
        public string PhoneNumber { get; set; }
        [DisplayName("Add Image")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }          /*picture*/
        [DisplayName("Image")]
        public string Picture { get; set; }
    }
}
