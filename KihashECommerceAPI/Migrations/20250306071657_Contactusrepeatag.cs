using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KihashECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Contactusrepeatag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactUsId",
                table: "ContactUs",
                newName: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "ContactUs",
                newName: "ContactUsId");
        }
    }
}
