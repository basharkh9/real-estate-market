using Microsoft.EntityFrameworkCore.Migrations;

namespace real_estate_market.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Timber')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Stone')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Vinyl')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Glass')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('BricK')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Fibre Cement')");
            migrationBuilder.Sql("INSERT INTO Claddings (Name) VALUES ('Metal')");

            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (165, 1, 'ST : 4921  Nutters Barn Lane State : Iowa', 11000, (SELECT ID FROM Claddings WHERE Name = 'Timber'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (195, 3, 'ST : 2886  Freed Drive State : California', 11000, (SELECT ID FROM Claddings WHERE Name = 'Stone'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (175, 10, 'ST : 210  Cost Avenue State : Maryland', 11000, (SELECT ID FROM Claddings WHERE Name = 'Vinyl'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (163, 7, 'ST : 4615  Bassel Street State : Louisiana', 11000, (SELECT ID FROM Claddings WHERE Name = 'Glass'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (160, 1, 'ST : 4824  Wilkinson Street State : Tennessee', 11000, (SELECT ID FROM Claddings WHERE Name = 'Brick'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (95, 9, 'ST : 3424  Flanigan Oaks Drive State : Maryland', 11000, (SELECT ID FROM Claddings WHERE Name = 'Fibre Cement'))");
            migrationBuilder.Sql("INSERT INTO RealEstates (Area, Level, Address, Price, CladdingId) VALUES (110, 5, 'ST : 3784  Sharon Lane State : Indiana', 11000, (SELECT ID FROM Claddings WHERE Name = 'Metal'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Claddings WHERE Name IN ('Timber', 'Stone' ,'Glass' ,'Metal' , 'Fibre Cement', 'Vinyl', 'Brick')");
        }
    }
}
