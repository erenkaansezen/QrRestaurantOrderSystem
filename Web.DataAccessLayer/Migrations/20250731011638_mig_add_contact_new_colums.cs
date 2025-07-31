using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_contact_new_colums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterTitle",
                table: "Conctacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDays",
                table: "Conctacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenDaysDescription",
                table: "Conctacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenHours",
                table: "Conctacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterTitle",
                table: "Conctacts");

            migrationBuilder.DropColumn(
                name: "OpenDays",
                table: "Conctacts");

            migrationBuilder.DropColumn(
                name: "OpenDaysDescription",
                table: "Conctacts");

            migrationBuilder.DropColumn(
                name: "OpenHours",
                table: "Conctacts");
        }
    }
}
