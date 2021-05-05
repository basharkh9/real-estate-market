using Microsoft.EntityFrameworkCore.Migrations;

namespace real_estate_market.Migrations
{
    public partial class SeedFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Feedbacks (Description, Rate) VALUES ('Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio iusto iste deserunt consectetur, tempore fugiat.', 4)");
            migrationBuilder.Sql("INSERT INTO Feedbacks (Description, Rate) VALUES ('Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio iusto iste deserunt consectetur, tempore fugiat.', 4)");
            migrationBuilder.Sql("INSERT INTO Feedbacks (Description, Rate) VALUES ('Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio iusto iste deserunt consectetur, tempore fugiat.', 4)");
            migrationBuilder.Sql("INSERT INTO Feedbacks (Description, Rate) VALUES ('Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio iusto iste deserunt consectetur, tempore fugiat.', 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Feedbacks");
        }
    }
}
