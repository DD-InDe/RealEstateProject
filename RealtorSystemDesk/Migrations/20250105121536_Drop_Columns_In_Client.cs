using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorSystemDesk.Migrations
{
    /// <inheritdoc />
    public partial class Drop_Columns_In_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("phone","client");
            migrationBuilder.DropColumn("email","client");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
