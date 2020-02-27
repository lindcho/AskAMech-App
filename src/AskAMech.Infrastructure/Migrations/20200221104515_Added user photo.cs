using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class Addeduserphoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "UserPhoto",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 466, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 467, DateTimeKind.Local).AddTicks(659));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 467, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 467, DateTimeKind.Local).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 467, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 21, 12, 29, 15, 467, DateTimeKind.Local).AddTicks(670));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c18909f6-ea08-4f14-a819-74750607e620", "61757722-34cf-48d7-b297-ee2b14538f52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8cccc5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "be808c23-2b6d-4c61-8426-e82187382015", "92e2613a-e2f5-4e3f-b4ba-4f1bdcaf0937" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf89a831-e5d7-4712-9af8-9e3a384b49ec", "82396159-6c22-416c-bc07-2fee39a1017d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "754d698d-af9b-42b6-acc0-ca05c1354a5a", "b63cd8e8-34b5-499e-8a99-a336b009e6eb" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 21, 11, 45, 15, 465, DateTimeKind.Local).AddTicks(6873), new DateTime(2020, 2, 21, 12, 35, 15, 466, DateTimeKind.Local).AddTicks(6981) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 21, 9, 45, 15, 466, DateTimeKind.Local).AddTicks(7510), new DateTime(2020, 2, 21, 12, 43, 15, 466, DateTimeKind.Local).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 23, 12, 45, 15, 466, DateTimeKind.Local).AddTicks(7520), new DateTime(2020, 1, 22, 12, 45, 15, 466, DateTimeKind.Local).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 23, 12, 45, 15, 466, DateTimeKind.Local).AddTicks(7523), new DateTime(2020, 2, 21, 12, 35, 15, 466, DateTimeKind.Local).AddTicks(7524) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 23, 12, 45, 15, 466, DateTimeKind.Local).AddTicks(7526), new DateTime(2020, 2, 21, 12, 29, 15, 466, DateTimeKind.Local).AddTicks(7526) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(9788));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(9789));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(9790));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78c0e9ca-7dfd-4e28-8909-86f6d707ad70", "264dc9b5-eb27-4fd2-87a2-30c48f233b77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8cccc5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bd397a6-2e85-4197-9369-a8d01a2b7fe7", "776132c6-1738-462a-bf09-5854e977fe27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35180361-14ea-4eaf-bd1b-815c49fabcc6", "5c35b3b3-b815-4adf-9818-cf4dbff3f31d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01b11987-d5f7-4368-86e0-294c696741dd", "e4bd57e5-133b-414d-b2f3-8150cb5fd418" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 19, 12, 48, 37, 681, DateTimeKind.Local).AddTicks(8310), new DateTime(2020, 2, 19, 13, 38, 37, 682, DateTimeKind.Local).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 19, 10, 48, 37, 682, DateTimeKind.Local).AddTicks(7116), new DateTime(2020, 2, 19, 13, 46, 37, 682, DateTimeKind.Local).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 48, 37, 682, DateTimeKind.Local).AddTicks(7125), new DateTime(2020, 1, 20, 13, 48, 37, 682, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 48, 37, 682, DateTimeKind.Local).AddTicks(7127), new DateTime(2020, 2, 19, 13, 38, 37, 682, DateTimeKind.Local).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 48, 37, 682, DateTimeKind.Local).AddTicks(7129), new DateTime(2020, 2, 19, 13, 32, 37, 682, DateTimeKind.Local).AddTicks(7129) });
        }
    }
}
