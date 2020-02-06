using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class Seeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false),
                    AcceptedAnswerId = table.Column<int>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1f7999f-28be-4322-bc69-612ef8bbbb5G", 0, "1ffeb57a-8056-483c-b0f8-93c400beead3", "lindco@outlook.com", true, "lindokuhle", true, null, "LINDCHO@OUTLOOK.COM", "LINDCHO@OUTLOOK.COM", "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==", "0746009500", true, null, "aa88c5b1-8bf5-464a-be70-1ae0a467f147", false, "lindco@outlook.com" },
                    { "1f7999f-28be-4322-bc69-612ef8bbbb5c", 0, "4391d6f7-4e14-40f1-91c3-90a79e8a44dc", "askamech@gmail.com", true, "khanyisile", true, null, "ASKAMECH@GMAIL.COM", "ASKAMECH@GMAIL.COM", "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==", "0746009500", true, null, "a05ca472-1179-421c-a19e-500c6408d032", false, "askamech@gmail.com" },
                    { "36b2db51-238e-4224-ad1d-fe3077a5e4e4", 0, "dd0968d2-7006-4af8-a810-5fdd794d0668", "sam@gmail.com", true, "samkelo", true, null, "SAM@GMAIL.COM", "SAM@GMAIL.COM", "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==", "0746009500", true, null, "f17f36d5-601d-43ab-b8c0-0bcf664da362", false, "sam@gmail.com" },
                    { "ffc183dc-78c2-413d-96f8-2091600c0b69", 0, "9d5993f2-6e50-481b-95f7-f967b2fe4f75", "lindo1@ymail.com", true, "samkelo", true, null, "LINDO1@YMAIL.COM", "LINDO1@YMAIL.COM", "AQAAAAEAACcQAAAAEKGJW6gAMtcOK+HH2phjyFSosZjyexbheSbFtgc6IYtspAcTAmPe9MwjitV7xe8gLQ==", "0746009500", true, null, "753b048a-02fd-43a8-b0aa-8b4b94a53b03", false, "lindo1@ymail.com" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "AcceptedAnswerId", "AuthorId", "DateCreated", "Description", "LastModified", "Title" },
                values: new object[,]
                {
                    { 2, null, "1f7999f-28be-4322-bc69-612ef8bbbb5G", new DateTime(2020, 2, 6, 9, 51, 59, 590, DateTimeKind.Local).AddTicks(1651), "I just bought a tire but don;t know how to fit it in my car.", new DateTime(2020, 2, 6, 12, 49, 59, 590, DateTimeKind.Local).AddTicks(1655), "How to fit a tire" },
                    { 1, null, "1f7999f-28be-4322-bc69-612ef8bbbb5c", new DateTime(2020, 2, 6, 11, 51, 59, 589, DateTimeKind.Local).AddTicks(1480), "I need to know where can i buy a strong tire.", new DateTime(2020, 2, 6, 12, 41, 59, 590, DateTimeKind.Local).AddTicks(1370), "where to buy a strong tire" },
                    { 3, null, "36b2db51-238e-4224-ad1d-fe3077a5e4e4", new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1659), "I bought brackpads but don't know how to fix it.", new DateTime(2020, 1, 7, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1660), "How to fit brackes" },
                    { 4, null, "ffc183dc-78c2-413d-96f8-2091600c0b69", new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1661), "my cra is making a noise i think i need to replace cv's.", new DateTime(2020, 2, 6, 12, 41, 59, 590, DateTimeKind.Local).AddTicks(1662), "CV problem" },
                    { 5, null, "ffc183dc-78c2-413d-96f8-2091600c0b69", new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1663), "i bought this brakes two months ago but it seams like they are not original.", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(1663), "My car brakes are not working" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AuthorId", "Date", "Description", "QuestionId" },
                values: new object[,]
                {
                    { 1, "1f7999f-28be-4322-bc69-612ef8bbbb5c", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(2903), "fix it", 2 },
                    { 4, "36b2db51-238e-4224-ad1d-fe3077a5e4e4", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3304), "You can buy from Continental! but the price is just off the roof.. Very expensive", 1 },
                    { 5, "ffc183dc-78c2-413d-96f8-2091600c0b69", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3305), "Super Tyres", 1 },
                    { 6, "1f7999f-28be-4322-bc69-612ef8bbbb5G", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3305), "Goodyear Tyres for new tires, but you can also try your new garage for second hand tyres", 1 },
                    { 2, "1f7999f-28be-4322-bc69-612ef8bbbb5c", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3296), "fix it now", 3 },
                    { 3, "1f7999f-28be-4322-bc69-612ef8bbbb5c", new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3303), "fix then test it", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AcceptedAnswerId",
                table: "Questions",
                column: "AcceptedAnswerId",
                unique: true,
                filter: "[AcceptedAnswerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AuthorId",
                table: "Questions",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
