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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(70);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "C#",
                    Description = "C# related posts",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "C# Blog Category"
                },
                new Category
                {
                    Id = 2,
                    Name = "C++",
                    Description = "C++ related posts",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Blog Category"
                },
                new Category
                {
                    Id = 3,
                    Name = "JavaScript",
                    Description = "JavaScript related posts",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreation",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreation",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript Blog Category"
                }
            );
        }
    }
}
