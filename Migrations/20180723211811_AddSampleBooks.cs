using Microsoft.EntityFrameworkCore.Migrations;

namespace bookglobebackend.Migrations
{
    public partial class AddSampleBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Books (Title, Author, PageLength, Price) VALUES ('The Help', 'Kathryn Stockett', 444, 13.80)");
            migrationBuilder.Sql("INSERT INTO Books (Title, Author, PageLength, Price) VALUES ('Harry Potter and the Sorcerers Stone', 'J.K. Rowling', 320, 15.00)");
            migrationBuilder.Sql("INSERT INTO Books (Title, Author, PageLength, Price) VALUES ('To Kill a Mockingbird', 'Harper Lee', 324, 11.99)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Books WHERE Title IN ('The Help', 'Harry Potter and the Sorcerers Stone', 'To Kill a Mockingbird')");
        }
    }
}
