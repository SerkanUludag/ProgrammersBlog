﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;

namespace ProgrammersBlog.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CommentCount")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SeoAuthor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SeoDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SeoTags")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CommentCount = 1,
                            Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 391, DateTimeKind.Local).AddTicks(8453),
                            Date = new DateTime(2021, 10, 30, 11, 0, 12, 391, DateTimeKind.Local).AddTicks(5369),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(40),
                            Note = "C# 9.0 and .NET 5 features",
                            SeoAuthor = "Serkan Uludağ",
                            SeoDescription = "C# 9.0 and .NET 5 features",
                            SeoTags = "C#, .NET",
                            Thumbnail = "Default.jpg",
                            Title = "C# 9.0 and .NET 5 features",
                            UserId = 1,
                            ViewCount = 200
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            CommentCount = 1,
                            Content = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3724),
                            Date = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3721),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3728),
                            Note = "C++ 11 features",
                            SeoAuthor = "Serkan Uludağ",
                            SeoDescription = "C++ 9.0 and .NET 5 features",
                            SeoTags = "C++",
                            Thumbnail = "Default.jpg",
                            Title = "C++ 11 features",
                            UserId = 1,
                            ViewCount = 300
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            CommentCount = 1,
                            Content = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet. It uses a dictionary of over 200 Latin words, combined with a handful of model sentence structures, to generate Lorem Ipsum which looks reasonable. The generated Lorem Ipsum is therefore always free from repetition, injected humour, or non-characteristic words etc.",
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3740),
                            Date = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3737),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 392, DateTimeKind.Local).AddTicks(3742),
                            Note = "JavaScript features",
                            SeoAuthor = "Serkan Uludağ",
                            SeoDescription = "JavaScript features",
                            SeoTags = "JavaScript",
                            Thumbnail = "Default.jpg",
                            Title = "JavaScript 11 features",
                            UserId = 1,
                            ViewCount = 100
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(216),
                            Description = "C# related posts",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(246),
                            Name = "C#",
                            Note = "C# Blog Category"
                        },
                        new
                        {
                            Id = 2,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(273),
                            Description = "C++ related posts",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(276),
                            Name = "C++",
                            Note = "C++ Blog Category"
                        },
                        new
                        {
                            Id = 3,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(284),
                            Description = "JavaScript related posts",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 403, DateTimeKind.Local).AddTicks(286),
                            Name = "JavaScript",
                            Note = "JavaScript Blog Category"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleId = 1,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5173),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5203),
                            Note = "C# post comment",
                            Text = "Nice post!!"
                        },
                        new
                        {
                            Id = 2,
                            ArticleId = 2,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5231),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5234),
                            Note = "C++ post comment",
                            Text = "Good post!!"
                        },
                        new
                        {
                            Id = 3,
                            ArticleId = 3,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5242),
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 399, DateTimeKind.Local).AddTicks(5244),
                            Note = "JavaScript post comment",
                            Text = "Great"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 406, DateTimeKind.Local).AddTicks(4509),
                            Description = "Admin role has full access",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 406, DateTimeKind.Local).AddTicks(4536),
                            Name = "Admin",
                            Note = "Admin role"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("VARBINARY(500)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "InitialCreation",
                            CreatedDate = new DateTime(2021, 10, 30, 11, 0, 12, 429, DateTimeKind.Local).AddTicks(9812),
                            Description = "First admin user",
                            Email = "serkanuludag@gmail.com",
                            FirstName = "Serkan",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Uludağ",
                            ModifiedByName = "InitialCreation",
                            ModifiedDate = new DateTime(2021, 10, 30, 11, 0, 12, 429, DateTimeKind.Local).AddTicks(9840),
                            Note = "Admin user",
                            PasswordHash = new byte[] { 48, 49, 57, 50, 48, 50, 51, 97, 55, 98, 98, 100, 55, 51, 50, 53, 48, 53, 49, 54, 102, 48, 54, 57, 100, 102, 49, 56, 98, 53, 48, 48 },
                            Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                            RoleId = 1,
                            UserName = "serkanuludag"
                        });
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Article", b =>
                {
                    b.HasOne("ProgrammersBlog.Entity.Concrete.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgrammersBlog.Entity.Concrete.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Comment", b =>
                {
                    b.HasOne("ProgrammersBlog.Entity.Concrete.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.User", b =>
                {
                    b.HasOne("ProgrammersBlog.Entity.Concrete.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProgrammersBlog.Entity.Concrete.User", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
