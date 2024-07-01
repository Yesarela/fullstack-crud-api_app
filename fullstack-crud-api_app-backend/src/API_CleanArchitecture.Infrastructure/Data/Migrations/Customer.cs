using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CleanArchitecture.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class Customer : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Customer",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Mysql:Autoincrement", true),
          Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          LastName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Identification = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Phone = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Gender = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
          Birthday = table.Column<DateOnly>(type: "DATE", nullable: false),
          CreatedDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
          LastModifiedDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Customer", x => x.Id);
        });
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Customer");
  }
}
