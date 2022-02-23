using ProgrammersBlog.Entity.Concrete;
using ProgrammersBlog.Entity.DTOs;

namespace ProgrammersBlog.Web.Models
{
    public class ArticleDetailRightSideBarViewModel
    {
        public string Header { get; set; }
        public ArticleListDto ArticleListDto { get; set; }
        public User User { get; set; }
    }
}
