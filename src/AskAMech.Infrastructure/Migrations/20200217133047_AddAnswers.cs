using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class AddAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(3122));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 14, 46, 959, DateTimeKind.Local).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8ca99fa-c63d-4687-92a7-a6b8ffd9f3b3", "5ed77261-3744-49d2-a77f-e375a0e316e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9aad1f81-e750-49cd-ad8d-03a2747ccf9b", "2c33362b-5e29-41d4-a063-2bb0daab231f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e3de6acd-d55d-4f91-a3d6-436e94c6e3b7", "12fda695-a9df-4ee5-a7ba-9b59425196df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "340aacde-e683-48b2-9ada-7540eaef63f7", "fd68d76c-aa92-4f50-8a00-61242845f3cb" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 17, 14, 30, 46, 957, DateTimeKind.Local).AddTicks(4587), new DateTime(2020, 2, 17, 15, 20, 46, 958, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 17, 12, 30, 46, 958, DateTimeKind.Local).AddTicks(9080), new DateTime(2020, 2, 17, 15, 28, 46, 958, DateTimeKind.Local).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 30, 46, 958, DateTimeKind.Local).AddTicks(9098), new DateTime(2020, 1, 18, 15, 30, 46, 958, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 30, 46, 958, DateTimeKind.Local).AddTicks(9102), new DateTime(2020, 2, 17, 15, 20, 46, 958, DateTimeKind.Local).AddTicks(9103) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 30, 46, 958, DateTimeKind.Local).AddTicks(9105), new DateTime(2020, 2, 17, 15, 14, 46, 958, DateTimeKind.Local).AddTicks(9106) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
