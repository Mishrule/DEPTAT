using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPTAT.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37470a99-4000-4e22-bde2-970e3acd9a5c",
                column: "ConcurrencyStamp",
                value: "0a312b5a-bb54-421c-905c-45356ebed695");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
                column: "ConcurrencyStamp",
                value: "37ead7db-484b-4692-b700-9a3727938d52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
                column: "ConcurrencyStamp",
                value: "65845f82-7aa0-47ed-b6bb-3adbcc0a4427");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dabe93bd-b0d7-4031-91e8-81296292277d",
                column: "ConcurrencyStamp",
                value: "743ca8a8-457a-4bd3-aa15-bf0775617a15");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "RoleId", "SecurityStamp" },
                values: new object[] { "75f0b948-b516-4a2e-97dc-db7a600d86c8", "AQAAAAEAACcQAAAAELo8o0LADCB8v8x/2Y5lWdQ3T9ZGp2PSGRSfHbRFZEXaIpIp892NPibdgfOLjjYkqA==", null, null, "7c9aaa4a-216b-4cf1-ab6f-ae4c8ad77c21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "RoleId", "SecurityStamp" },
                values: new object[] { "543bbe98-cb27-4fea-b6b4-188b717c15ba", "AQAAAAEAACcQAAAAEOWoWrB2ANbjT8yXu+rVIM48/hkW5YZ7PU+yp41of23lPn77XjRrHhlAin0WgBjEtQ==", null, null, "79248a6c-83c0-4d26-a89a-7ac77698670c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "RoleId", "SecurityStamp" },
                values: new object[] { "c59f3722-d834-44ea-9cf9-db03d527eb6f", "AQAAAAEAACcQAAAAECeynOvVq6ZIHI5YwaAvotSvO2xB1OzY/YJArmUKKx12a8HYezNcr/yoj6MkyoptQA==", null, null, "28e185bc-70fe-40af-968d-e53fed8dfc0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Role", "RoleId", "SecurityStamp" },
                values: new object[] { "8953e206-9897-4d4d-9acf-d67606392dd0", "AQAAAAEAACcQAAAAEG0+l7t+B3cY9We8Httxqe0wQq4E5MQbqEkOBC5HqPBmBgrtto+pjNXrD68hRYtcZQ==", null, null, "e0f6cc2b-86e2-4266-ac3d-1c84b096ad47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

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
    }
}
