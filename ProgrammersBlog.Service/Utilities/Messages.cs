using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Service.Utilities
{
    public static class Messages
    {
        public static class General
        {
            public static string ValidationError()
            {
                return $"One or more validation error occurred";
            }
        }

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

            public static string UndoDelete(string categoryName)
            {
                return $"{categoryName} has been successfully restored.";
            }

            public static string NotFoundById(int categoryId)
            {
                return $"Category with id: {categoryId} not found.";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "No article found.";
                return "Article not found.";
            }

            public static string NotFoundById(int articleId)
            {
                return $"Article with id: {articleId} not found.";
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

            public static string UndoDelete(string articleName)
            {
                return $"{articleName} has been successfully restored.";
            }

            public static string IncreaseViewCount(string articleName)
            {
                return $"{articleName} view count has been increased.";
            }
        }

        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(int commentId)
            {
                return $"{commentId} no'lu yorum başarıyla onaylanmıştır.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla veritabanından silinmiştir.";
            }

            public static string UndoDelete(string createdByName)
            {
                return $"{createdByName} user comment has been successfully restored.";
            }
        }

        public static class User
        {
            //public static string NotFound(bool isPlural)
            //{
            //    if (isPlural) return "No category found.";
            //    return "Category not found.";
            //}

            //public static string Add(string categoryName)
            //{
            //    return $"{categoryName} has been successfully added.";
            //}

            //public static string Update(string categoryName)
            //{
            //    return $"{categoryName} has been successfully updated.";
            //}

            //public static string Delete(string categoryName)
            //{
            //    return $"{categoryName} has been successfully deleted.";
            //}

            //public static string HardDelete(string categoryName)
            //{
            //    return $"{categoryName} has been successfully deleted from database.";
            //}

            //public static string UndoDelete(string categoryName)
            //{
            //    return $"{categoryName} has been successfully restored.";
            //}

            public static string NotFoundById(int userId)
            {
                return $"User with id: {userId} not found.";
            }
        }

    }
}
