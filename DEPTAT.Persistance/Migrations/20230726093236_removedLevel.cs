using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPTAT.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class removedLevel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37470a99-4000-4e22-bde2-970e3acd9a5c",
                column: "ConcurrencyStamp",
                value: "c67fe53c-eca5-4e81-bdfe-7d1bdf8493cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
                column: "ConcurrencyStamp",
                value: "19e0b393-3859-47eb-ad1b-6289ea91f566");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
                column: "ConcurrencyStamp",
                value: "b1cbd9b3-6757-442c-9e8d-bac26da877ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dabe93bd-b0d7-4031-91e8-81296292277d",
                column: "ConcurrencyStamp",
                value: "0d47ad29-6578-40b6-93a6-48054d34d192");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7d07b97-ae8b-473b-858a-a2fe10bd68b8", "AQAAAAEAACcQAAAAENW8TUbaofODOcB+iZZmRy+8lm9U/hmoNSExecXjUPFoX4ClT8Au5ibBY7KfuNr6gw==", "02f2a5c7-85e9-4757-bb24-a3aa2f94341a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ddf6ea4-fd19-4075-a462-f75e69d5af4c", "AQAAAAEAACcQAAAAEJBxM7SctaWRY6KbYzA6fAozSAWnLdWt0LAnHBxp4t4penoSXO90MMF4XmeXMnI5wQ==", "cfb3b988-8bb8-4c89-bf75-ae48707d7599" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "741ada47-798b-40af-b45f-bc20feb45450", "AQAAAAEAACcQAAAAEBDSXmws5CAEz8zHgSS9i0TBIsADSALioZ1VkFL6vLCT6+psDRoeSWHU8nhrj+r3YA==", "1e23dde4-b783-4bd2-8474-24b9680890f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58e1e72b-3b94-4962-bed9-13b737ea6790", "AQAAAAEAACcQAAAAEDP5XYYHS2nZSR5ipTCj4JcqwcxxOQNJyz6qdpH9eCp05g26L0MWg8wuKm6TkkZGfw==", "7ef8d7f4-b3cd-412d-b581-fd5761974225" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37470a99-4000-4e22-bde2-970e3acd9a5c",
                column: "ConcurrencyStamp",
                value: "cc7ef791-6bed-4e4d-bf99-6df456f5a806");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
                column: "ConcurrencyStamp",
                value: "b5b1c2e3-2ee6-4dab-95f1-61058b9c844a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
                column: "ConcurrencyStamp",
                value: "45f789b2-7539-4201-bafd-28727df3da6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dabe93bd-b0d7-4031-91e8-81296292277d",
                column: "ConcurrencyStamp",
                value: "a72118fc-87fc-49a7-ac1a-adc30ccd3562");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47a99c9e-15c4-4423-9d2b-b81cdf74800c", "AQAAAAEAACcQAAAAEKXb4cP9m/bJMXdprgBQidhjrb7PlEiXIiJ255jXAHIeIt7MITpEnn1hSNwWg8K3/w==", "933fa0f1-db9e-4a5e-9cec-195722587ea9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70c22d08-44b4-4ca4-894a-7c2ba647c756", "AQAAAAEAACcQAAAAEKQtBpSy9XlCkgWeiRwAc87YjQ2IA6wuMmvJcnbqclIibv5nv4QaWimERmy3NarblA==", "ac9bfa28-448f-4293-bc29-64523797188a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd1e28d5-f625-47aa-b613-5e98f92755a7", "AQAAAAEAACcQAAAAEHVA9cSJy0TDCCa6Lj4A0kueuYwUZxZ0dti6KnOaCdyU9BkqvQBDCVmMpvdDluX6RA==", "099a0b81-35e1-41bc-864b-5b447a4e6dd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdfffa0b-59a4-48f2-be3d-2416abf0013e", "AQAAAAEAACcQAAAAEJk4sXFd2st9vQDmC/IJo1bmFlog1P/Q1WPbdjLupNHYVEvReyolK7tCizX4KfJEng==", "e4bde64b-e60e-415b-8d29-6427998fb047" });
        }
    }
}
