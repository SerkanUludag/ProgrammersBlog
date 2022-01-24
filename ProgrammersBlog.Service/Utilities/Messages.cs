using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.Utilities
{
    public static class Messages
    {
        // Messages.Category.NotFound
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "No category found.";
                return "Category not found.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} has been successfully added.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} has been successfully updated.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} has been successfully deleted.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} has been successfully deleted from database.";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "No article found.";
                return "Article not found.";
            }

            public static string Add(string articleName)
            {
                return $"{articleName} has been successfully added.";
            }

            public static string Update(string articleName)
            {
                return $"{articleName} has been successfully updated.";
            }

            public static string Delete(string articleName)
            {
                return $"{articleName} has been successfully deleted.";
            }

            public static string HardDelete(string articleName)
            {
                return $"{articleName} has been successfully deleted from database.";
            }
        }
    }
}
