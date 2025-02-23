﻿// <auto-generated />
using System;
using AskAMech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AskAMech.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200415100120_Recreate-database")]
    partial class Recreatedatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AskAMech.Domain.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("QuestionId");

                    b.HasKey("AnswerId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8cccc5c",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(6738),
                            Description = "fix it",
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 2,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8cccc5c",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(8414),
                            Description = "fix it now",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 3,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8cccc5c",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(8433),
                            Description = "fix then test it",
                            QuestionId = 4
                        },
                        new
                        {
                            AnswerId = 4,
                            AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(8435),
                            Description = "You can buy from Continental! but the price is just off the roof.. Very expensive",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 5,
                            AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(8437),
                            Description = "Super Tyres",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 6,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                            Date = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(8438),
                            Description = "Goodyear Tyres for new tires, but you can also try your new garage for second hand tyres",
                            QuestionId = 1
                        });
                });

            modelBuilder.Entity("AskAMech.Domain.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<byte[]>("UserPhoto");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0ad5125c-bc4b-4f73-af0c-3fb7b94b5e01",
                            Email = "lindco@outlook.com",
                            EmailConfirmed = true,
                            FullName = "lindokuhle",
                            LockoutEnabled = true,
                            NormalizedEmail = "LINDCHO@OUTLOOK.COM",
                            NormalizedUserName = "LINDCHO@OUTLOOK.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==",
                            PhoneNumber = "0746009500",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "5969e29b-f9bf-4da2-a498-393812936c59",
                            TwoFactorEnabled = false,
                            UserName = "lindco@outlook.com"
                        },
                        new
                        {
                            Id = "1f7999f-28be-4322-bc69-612ef8cccc5c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a74f800c-edad-4e9f-af76-15ff6e1742b0",
                            Email = "askamech@gmail.com",
                            EmailConfirmed = true,
                            FullName = "khanyisile",
                            LockoutEnabled = true,
                            NormalizedEmail = "ASKAMECH@GMAIL.COM",
                            NormalizedUserName = "ASKAMECH@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==",
                            PhoneNumber = "0746009500",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "72c2fa54-f94a-4c42-92d1-31e34e9a0e06",
                            TwoFactorEnabled = false,
                            UserName = "askamech@gmail.com"
                        },
                        new
                        {
                            Id = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f114a92e-f16f-41f7-b817-4cae1e0c9aa2",
                            Email = "sam@gmail.com",
                            EmailConfirmed = true,
                            FullName = "samkelo",
                            LockoutEnabled = true,
                            NormalizedEmail = "SAM@GMAIL.COM",
                            NormalizedUserName = "SAM@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==",
                            PhoneNumber = "0746009500",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "a9517dba-1d9b-4c9c-8eb3-289515d19cc1",
                            TwoFactorEnabled = false,
                            UserName = "sam@gmail.com"
                        },
                        new
                        {
                            Id = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "960b3a00-4e44-426b-b9ec-4ce9ebc4f091",
                            Email = "lindo1@ymail.com",
                            EmailConfirmed = true,
                            FullName = "samkelo",
                            LockoutEnabled = true,
                            NormalizedEmail = "LINDO1@YMAIL.COM",
                            NormalizedUserName = "LINDO1@YMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==",
                            PhoneNumber = "0746009500",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "68ce9950-11a2-4809-ad82-a85cad1ceaa2",
                            TwoFactorEnabled = false,
                            UserName = "lindo1@ymail.com"
                        });
                });

            modelBuilder.Entity("AskAMech.Domain.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AcceptedAnswerId");

                    b.Property<string>("AuthorId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AcceptedAnswerId")
                        .IsUnique()
                        .HasFilter("[AcceptedAnswerId] IS NOT NULL");

                    b.HasIndex("AuthorId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                            DateCreated = new DateTime(2020, 4, 15, 11, 1, 20, 207, DateTimeKind.Local).AddTicks(9092),
                            Description = "I need to know where can i buy a strong tire.",
                            LastModified = new DateTime(2020, 4, 15, 11, 51, 20, 209, DateTimeKind.Local).AddTicks(1409),
                            Title = "where to buy a strong tire"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8cccc5c",
                            DateCreated = new DateTime(2020, 4, 15, 9, 1, 20, 209, DateTimeKind.Local).AddTicks(2146),
                            Description = "I just bought a tire but don;t know how to fit it in my car.",
                            LastModified = new DateTime(2020, 4, 15, 11, 59, 20, 209, DateTimeKind.Local).AddTicks(2156),
                            Title = "How to fit a tire"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                            DateCreated = new DateTime(2020, 2, 15, 12, 1, 20, 209, DateTimeKind.Local).AddTicks(2170),
                            Description = "I bought brackpads but don't know how to fix it.",
                            LastModified = new DateTime(2020, 3, 16, 12, 1, 20, 209, DateTimeKind.Local).AddTicks(2172),
                            Title = "How to fit brackes"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                            DateCreated = new DateTime(2020, 2, 15, 12, 1, 20, 209, DateTimeKind.Local).AddTicks(2174),
                            Description = "my cra is making a noise i think i need to replace cv's.",
                            LastModified = new DateTime(2020, 4, 15, 11, 51, 20, 209, DateTimeKind.Local).AddTicks(2175),
                            Title = "CV problem"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = "ffc183dc-78c2-413d-96f8-2091600c0b69",
                            DateCreated = new DateTime(2020, 2, 15, 12, 1, 20, 209, DateTimeKind.Local).AddTicks(2178),
                            Description = "i bought this brakes two months ago but it seams like they are not original.",
                            LastModified = new DateTime(2020, 4, 15, 11, 45, 20, 209, DateTimeKind.Local).AddTicks(2179),
                            Title = "My car brakes are not working"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AskAMech.Domain.Models.Answer", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser", "Author")
                        .WithMany("Answers")
                        .HasForeignKey("AuthorId");

                    b.HasOne("AskAMech.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AskAMech.Domain.Models.Question", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser", "Author")
                        .WithMany("Questions")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AskAMech.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AskAMech.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
