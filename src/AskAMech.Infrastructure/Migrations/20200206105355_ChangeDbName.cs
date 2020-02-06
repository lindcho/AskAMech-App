using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class ChangeDbName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "719b9c28-3572-47c2-a44d-5b5309cc9f23", "15342b70-1549-498e-bb1a-e55453223480" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f0561c42-ce32-4580-9bc4-b666b5e0e3d9", "711e67ff-65db-4248-9770-87bf1c42ad79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "823de93e-17c1-4e46-bf87-e5f61749d071", "9e9da093-a600-49ae-b5a7-42772c565186" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d1fe10a-2cdd-42a4-8ed8-522d24565f31", "1ac2327d-47d5-4aaa-882f-cda021de82d0" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 6, 11, 53, 55, 384, DateTimeKind.Local).AddTicks(6115), new DateTime(2020, 2, 6, 12, 43, 55, 385, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 6, 9, 53, 55, 385, DateTimeKind.Local).AddTicks(6225), new DateTime(2020, 2, 6, 12, 51, 55, 385, DateTimeKind.Local).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 53, 55, 385, DateTimeKind.Local).AddTicks(6234), new DateTime(2020, 1, 7, 12, 53, 55, 385, DateTimeKind.Local).AddTicks(6235) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 53, 55, 385, DateTimeKind.Local).AddTicks(6236), new DateTime(2020, 2, 6, 12, 43, 55, 385, DateTimeKind.Local).AddTicks(6237) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 53, 55, 385, DateTimeKind.Local).AddTicks(6238), new DateTime(2020, 2, 6, 12, 37, 55, 385, DateTimeKind.Local).AddTicks(6238) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4391d6f7-4e14-40f1-91c3-90a79e8a44dc", "a05ca472-1179-421c-a19e-500c6408d032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ffeb57a-8056-483c-b0f8-93c400beead3", "aa88c5b1-8bf5-464a-be70-1ae0a467f147" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd0968d2-7006-4af8-a810-5fdd794d0668", "f17f36d5-601d-43ab-b8c0-0bcf664da362" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9d5993f2-6e50-481b-95f7-f967b2fe4f75", "753b048a-02fd-43a8-b0aa-8b4b94a53b03" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 6, 11, 51, 59, 589, DateTimeKind.Local).AddTicks(1480), new DateTime(2020, 2, 6, 12, 41, 59, 590, DateTimeKind.Local).AddTicks(1370) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 6, 9, 51, 59, 590, DateTimeKind.Local).AddTicks(1651), new DateTime(2020, 2, 6, 12, 49, 59, 590, DateTimeKind.Local).AddTicks(1655) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1659), new DateTime(2020, 1, 7, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1661), new DateTime(2020, 2, 6, 12, 41, 59, 590, DateTimeKind.Local).AddTicks(1662) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 8, 12, 51, 59, 590, DateTimeKind.Local).AddTicks(1663), new DateTime(2020, 2, 6, 12, 35, 59, 590, DateTimeKind.Local).AddTicks(1663) });
        }
    }
}
