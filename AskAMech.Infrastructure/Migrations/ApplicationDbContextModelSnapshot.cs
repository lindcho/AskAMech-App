﻿// <auto-generated />
using System;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AskAMech.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AskAMech.Domain.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abstract");

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abstract = "Abstract 1",
                            AuthorId = "1",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 1",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title1"
                        },
                        new
                        {
                            Id = 2,
                            Abstract = "Abstract 1",
                            AuthorId = "2",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 2",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title2"
                        },
                        new
                        {
                            Id = 3,
                            Abstract = "Abstract 1",
                            AuthorId = "3",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 3",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title3"
                        },
                        new
                        {
                            Id = 4,
                            Abstract = "Abstract 1",
                            AuthorId = "4",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 4",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title4"
                        },
                        new
                        {
                            Id = 5,
                            Abstract = "Abstract 1",
                            AuthorId = "5",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 5",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title5"
                        },
                        new
                        {
                            Id = 6,
                            Abstract = "Abstract 1",
                            AuthorId = "6",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 6",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title6"
                        },
                        new
                        {
                            Id = 7,
                            Abstract = "Abstract 1",
                            AuthorId = "7",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 7",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title7"
                        },
                        new
                        {
                            Id = 8,
                            Abstract = "Abstract 1",
                            AuthorId = "8",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 8",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title8"
                        },
                        new
                        {
                            Id = 9,
                            Abstract = "Abstract 1",
                            AuthorId = "9",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 9",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title9"
                        },
                        new
                        {
                            Id = 10,
                            Abstract = "Abstract 1",
                            AuthorId = "10",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 10",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title10"
                        },
                        new
                        {
                            Id = 11,
                            Abstract = "Abstract 1",
                            AuthorId = "11",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 11",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title11"
                        },
                        new
                        {
                            Id = 12,
                            Abstract = "Abstract 1",
                            AuthorId = "12",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 12",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title12"
                        },
                        new
                        {
                            Id = 13,
                            Abstract = "Abstract 1",
                            AuthorId = "13",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 13",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title13"
                        },
                        new
                        {
                            Id = 14,
                            Abstract = "Abstract 1",
                            AuthorId = "14",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 14",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title14"
                        },
                        new
                        {
                            Id = 15,
                            Abstract = "Abstract 1",
                            AuthorId = "15",
                            DateCreated = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description 15",
                            LastModified = new DateTime(2019, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Title15"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("AskAMech.Domain.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FullName");

                    b.Property<string>("PictureUrl");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AskAMech.Domain.Models.Question", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser", "Author")
                        .WithMany("Questions")
                        .HasForeignKey("AuthorId");
                });
#pragma warning restore 612, 618
        }
    }
}
