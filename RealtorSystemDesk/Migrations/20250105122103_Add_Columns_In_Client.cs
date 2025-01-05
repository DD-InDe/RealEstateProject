using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealtorSystemDesk.Migrations
{
    /// <inheritdoc />
    public partial class Add_Columns_In_Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("phone","client", "varchar(100)", nullable:true);
            migrationBuilder.AddColumn<string>("email","client", "varchar(100)", nullable:true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("phone","client", "varchar(100)", nullable:true);
            migrationBuilder.AddColumn<string>("email","client", "varchar(100)", nullable:true);
        }
    }
}
