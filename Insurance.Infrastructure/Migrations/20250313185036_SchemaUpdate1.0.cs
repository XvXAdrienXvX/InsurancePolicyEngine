using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SchemaUpdate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumAmount",
                table: "Policies");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PolicyTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPremium",
                table: "Contracts",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PolicyTypes");

            migrationBuilder.DropColumn(
                name: "TotalPremium",
                table: "Contracts");

            migrationBuilder.AddColumn<decimal>(
                name: "PremiumAmount",
                table: "Policies",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
