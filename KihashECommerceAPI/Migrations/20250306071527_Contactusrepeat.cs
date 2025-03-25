using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KihashECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Contactusrepeat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "ContactUs",
                newName: "ContactName");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ContactUs",
                newName: "ContactUsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactName",
                table: "ContactUs",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "ContactUsId",
                table: "ContactUs",
                newName: "CustomerId");
        }
    }
}
