using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AskAMech.Infrastructure.Migrations
{
    public partial class rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 197, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 198, DateTimeKind.Local).AddTicks(1044));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 198, DateTimeKind.Local).AddTicks(1060));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 198, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 198, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6,
                column: "Date",
                value: new DateTime(2020, 2, 17, 15, 24, 58, 198, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5c",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b34e3e6c-964e-4d29-b2e6-f0e2f8f5c7fc", "76a4c721-35d6-4587-a6ea-8b5093d298a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f7999f-28be-4322-bc69-612ef8bbbb5G",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "efbfc8f7-3268-403a-87f6-9d44a7c2e5ed", "345935e6-2dac-4c3a-b155-1d2bc1eab6ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36b2db51-238e-4224-ad1d-fe3077a5e4e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2bd03b3-d578-450f-88fb-7f8a7a33e880", "9327a39d-c35d-4e57-8bd4-3db9b470e5b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ffc183dc-78c2-413d-96f8-2091600c0b69",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "596f98dd-fa7f-421a-8342-9349c79a96b5", "0e99e094-9cf6-41aa-b38c-be7ad1ecec48" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 17, 14, 40, 58, 196, DateTimeKind.Local).AddTicks(3541), new DateTime(2020, 2, 17, 15, 30, 58, 197, DateTimeKind.Local).AddTicks(6301) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2020, 2, 17, 12, 40, 58, 197, DateTimeKind.Local).AddTicks(7068), new DateTime(2020, 2, 17, 15, 38, 58, 197, DateTimeKind.Local).AddTicks(7081) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 40, 58, 197, DateTimeKind.Local).AddTicks(7087), new DateTime(2020, 1, 18, 15, 40, 58, 197, DateTimeKind.Local).AddTicks(7089) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 40, 58, 197, DateTimeKind.Local).AddTicks(7091), new DateTime(2020, 2, 17, 15, 30, 58, 197, DateTimeKind.Local).AddTicks(7092) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "LastModified" },
                values: new object[] { new DateTime(2019, 12, 19, 15, 40, 58, 197, DateTimeKind.Local).AddTicks(7094), new DateTime(2020, 2, 17, 15, 24, 58, 197, DateTimeKind.Local).AddTicks(7095) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
