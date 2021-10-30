using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(1000);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);

            builder.ToTable("Comments");

            builder.HasData(
                new Comment
                {
                    Id = 1,
                    ArticleId = 1,
                    Text = "Nice post!!",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "C# post comment"
                }, new Comment
                {
                    Id = 2,
                    ArticleId = 2,
                    Text = "Good post!!",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ post comment"
                }, new Comment 
                {
                    Id = 3,
                    ArticleId = 3,
                    Text = "Great",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript post comment"
                });
        }
    }
}
