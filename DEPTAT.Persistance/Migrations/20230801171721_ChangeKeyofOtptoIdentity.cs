using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPTAT.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeyofOtptoIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37470a99-4000-4e22-bde2-970e3acd9a5c",
                column: "ConcurrencyStamp",
                value: "ed67527a-018f-402d-9143-7164e6701640");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
                column: "ConcurrencyStamp",
                value: "ecfaa7f8-0b67-4ded-85ea-e5453e13b98f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
                column: "ConcurrencyStamp",
                value: "0c269883-b5bb-4961-8f30-8c9e7a6df95d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dabe93bd-b0d7-4031-91e8-81296292277d",
                column: "ConcurrencyStamp",
                value: "6dad76dc-922d-4d35-bf3a-d8c77885b78e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5da41c5f-c438-4b3a-b7f3-43b9759205fa", "AQAAAAEAACcQAAAAEHHYb9sZhtBiJRBC0oC6JRL26DgC0yp3SiRLXNsdbUbUbrvhl3vps/0yGqpt4RMTbA==", "0c1a61ad-9e38-44bf-a1d2-905d5f4f9ed7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88d034f7-c137-4179-b9fe-b807169dbb65", "AQAAAAEAACcQAAAAEDM8Yfvhfg9YkfWRf0/2FxmumY5bno8H/sM/rv3U/ZiU1BUE2r/Q2E2Zsn12HHhiLw==", "57288fe7-70f1-47ef-86c0-bed6b0af640f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "626621f2-3906-4f7c-a2df-873e022f4c42", "AQAAAAEAACcQAAAAEDv0OVFIGH3Pzcu1XSjnJiGKmA5Dcb/KpurxlQqto8Pl502UTo3ju6htqbg6RnKaoQ==", "294e0e87-8bdd-4b11-bdb6-c41fe2d01bf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfdd65fe-4bc4-4bc8-ad42-592f3d56cfb0", "AQAAAAEAACcQAAAAENMWkL8UDo5nF1F30BHfjbor5i6IhsxcSG9iUq5nOfbEMfa3+cVK2+n/vLaGOTOczQ==", "6b4e3a15-11fa-4a4d-800e-b6c3ea669814" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37470a99-4000-4e22-bde2-970e3acd9a5c",
                column: "ConcurrencyStamp",
                value: "38a0d339-1c3a-4686-87dd-d0259a4bde91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "561ebda5-541c-48b9-9e1a-e47e9e0ca044",
                column: "ConcurrencyStamp",
                value: "19366455-c46b-4382-88dd-82c6c26dfe6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cda07e2d-3d8e-4a54-ac3e-0ac233dfb3b6",
                column: "ConcurrencyStamp",
                value: "ba8130ec-5e64-4ab3-94fb-82587bd8a5ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dabe93bd-b0d7-4031-91e8-81296292277d",
                column: "ConcurrencyStamp",
                value: "4ab4b671-48dd-44b0-b611-09a9a043d9a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a38e1209-6272-4bc7-9cc4-e24bacc41f1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1df76c0-7941-42a6-aea7-18c9688de34e", "AQAAAAEAACcQAAAAEBX3cSgh2BRy/ocMhMrfhCfJz0+hdVg2a/s1ty/K6TISDlCToMR/FLkRz4fIKgS5qQ==", "52c54c80-726a-4c0c-922f-5c0b3c500f3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3468f1a0-bd3d-470d-8117-6fc2e605de00", "AQAAAAEAACcQAAAAEMnfb6Prr3OJYwsmDRAQppaqTAdMHuD/omc+z5TScDruOUM294VS1Il8p2/KTG2+Zg==", "c261b765-a086-40bf-b56f-c73d8a1759f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4af081e6-faf5-40e0-b9cb-f258b16cf53d", "AQAAAAEAACcQAAAAEDYmCkwUx2vqCJ/J7tSzj9G9MET7/bnv6nXx/rA8u/BMzoscY/DjoqICdzbxHWaG2w==", "4c9552da-6319-4c6b-b020-c5e44866dcdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fae05a7b-bedf-4cc2-8028-2eb5760e8505", "AQAAAAEAACcQAAAAEE/xO+PD/ZkvRSJ6nYjXYzmfNQWBeBzd+y2iX+qKvV1ELxRdFWYxx4oMOxfPH38txg==", "c9ee375c-8eb3-4aef-b190-ebe18f356cf9" });
        }
    }
}
