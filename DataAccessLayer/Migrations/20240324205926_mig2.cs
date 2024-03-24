using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user",
                table: "supportForm",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "subject",
                table: "supportForm",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "supportForm",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "supportForm",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "supportForm",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "formStatu",
                table: "supportForm",
                newName: "FormStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User",
                table: "supportForm",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "supportForm",
                newName: "subject");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "supportForm",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "supportForm",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "supportForm",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FormStatus",
                table: "supportForm",
                newName: "formStatu");
        }
    }
}
