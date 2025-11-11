using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nume_Pren_Lab2.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Category' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[Category](
        [ID] INT NOT NULL IDENTITY(1,1),
        [CategoryName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([ID])
    );
END
");

            migrationBuilder.Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'BookCategory' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE [dbo].[BookCategory](
        [BookID] INT NOT NULL,
        [CategoryID] INT NOT NULL,
        CONSTRAINT [PK_BookCategory] PRIMARY KEY ([BookID],[CategoryID]),
        CONSTRAINT [FK_BookCategory_Book_BookID] FOREIGN KEY ([BookID]) REFERENCES [dbo].[Book]([ID]) ON DELETE CASCADE,
        CONSTRAINT [FK_BookCategory_Category_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category]([ID]) ON DELETE CASCADE
    );
    CREATE INDEX [IX_BookCategory_CategoryID] ON [dbo].[BookCategory]([CategoryID]);
END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID('dbo.BookCategory', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookCategory];
");
            // Intenționat nu se șterge Category aici, pentru că putea exista dinainte.
        }
    }
}
