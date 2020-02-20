using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class AddAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(917));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(963));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 19, 13, 14, 38, 132, DateTimeKind.Local).AddTicks(964));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aca38155-10a9-4388-97af-43e969cb3b86", "ce3eda51-0e83-476a-933d-0ccf17478c1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8cccc5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8ad1ccc-0676-4026-9f78-571b5add8e52", "e5e40bdf-23e7-48c6-beb1-05cdfcd9225e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b4b0176a-86a2-4080-82a9-bbe2a0b068c4", "4d6e3db3-4801-4f79-b22c-f55a14e0f694" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bd259c70-3718-48a4-960b-7a4841e20809", "31751bea-997c-46fb-adb8-d4e6f87bf3cd" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 19, 12, 30, 38, 130, DateTimeKind.Local).AddTicks(9227), new DateTime(2020, 2, 19, 13, 20, 38, 131, DateTimeKind.Local).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 19, 10, 30, 38, 131, DateTimeKind.Local).AddTicks(8273), new DateTime(2020, 2, 19, 13, 28, 38, 131, DateTimeKind.Local).AddTicks(8279) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 30, 38, 131, DateTimeKind.Local).AddTicks(8282), new DateTime(2020, 1, 20, 13, 30, 38, 131, DateTimeKind.Local).AddTicks(8283) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 30, 38, 131, DateTimeKind.Local).AddTicks(8284), new DateTime(2020, 2, 19, 13, 20, 38, 131, DateTimeKind.Local).AddTicks(8285) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 21, 13, 30, 38, 131, DateTimeKind.Local).AddTicks(8286), new DateTime(2020, 2, 19, 13, 14, 38, 131, DateTimeKind.Local).AddTicks(8286) });
        }
    }
}
