using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LicenseFront",
                table: "Profiles",
                newName: "DLImageFront");

            migrationBuilder.RenameColumn(
                name: "LicenseBack",
                table: "Profiles",
                newName: "DLImageBack");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "DLImageFront",
                table: "Profiles",
                newName: "LicenseFront");

            migrationBuilder.RenameColumn(
                name: "DLImageBack",
                table: "Profiles",
                newName: "LicenseBack");
        }
    }
}
