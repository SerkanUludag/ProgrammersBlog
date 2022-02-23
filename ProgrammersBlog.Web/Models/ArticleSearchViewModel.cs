using ProgrammersBlog.Entity.DTOs;

namespace ProgrammersBlog.Web.Models
{
    public class ArticleSearchViewModel
    {
        public ArticleListDto ArticleListDto { get; set; }
        public string Keyword { get; set; }
    }
}
