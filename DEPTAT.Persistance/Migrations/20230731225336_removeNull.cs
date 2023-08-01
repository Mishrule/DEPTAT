using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEPTAT.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class removeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "YearGroup",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "OtherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AdmittedYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYear",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "YearGroup",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgrammeId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OtherName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdmittedYear",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcademicYear",
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75f0b948-b516-4a2e-97dc-db7a600d86c8", "AQAAAAEAACcQAAAAELo8o0LADCB8v8x/2Y5lWdQ3T9ZGp2PSGRSfHbRFZEXaIpIp892NPibdgfOLjjYkqA==", "7c9aaa4a-216b-4cf1-ab6f-ae4c8ad77c21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c63a3909-a67b-43e0-8c6b-6fa6ee1704c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "543bbe98-cb27-4fea-b6b4-188b717c15ba", "AQAAAAEAACcQAAAAEOWoWrB2ANbjT8yXu+rVIM48/hkW5YZ7PU+yp41of23lPn77XjRrHhlAin0WgBjEtQ==", "79248a6c-83c0-4d26-a89a-7ac77698670c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5390aff-7fab-4634-b700-2abe65cf016d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c59f3722-d834-44ea-9cf9-db03d527eb6f", "AQAAAAEAACcQAAAAECeynOvVq6ZIHI5YwaAvotSvO2xB1OzY/YJArmUKKx12a8HYezNcr/yoj6MkyoptQA==", "28e185bc-70fe-40af-968d-e53fed8dfc0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2712948-06b5-411f-b0e6-24304dc31761",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8953e206-9897-4d4d-9acf-d67606392dd0", "AQAAAAEAACcQAAAAEG0+l7t+B3cY9We8Httxqe0wQq4E5MQbqEkOBC5HqPBmBgrtto+pjNXrD68hRYtcZQ==", "e0f6cc2b-86e2-4266-ac3d-1c84b096ad47" });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programmes_ProgrammeId",
                table: "Students",
                column: "ProgrammeId",
                principalTable: "Programmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
