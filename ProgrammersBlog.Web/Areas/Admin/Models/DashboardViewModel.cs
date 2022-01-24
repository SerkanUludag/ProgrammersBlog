using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;
using System.Collections.Generic;

namespace ProgrammersBlog.Web.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int CategoriesCount { get; set; }
        public int ArticlesCount { get; set; }
        public int CommentsCount { get; set; }
        public int UserCount { get; set; }
        public ArticleListDto Articles { get; set; }
    }
}
