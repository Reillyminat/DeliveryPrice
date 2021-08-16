using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore5.Data.Migrations
{
    public partial class triggerAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER ApplyBlackFridayDiscount ON Products AFTER INSERT AS UPDATE Products SET Price=Price*0.9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER ApplyBlackFridayDiscount");
        }
    }
}
