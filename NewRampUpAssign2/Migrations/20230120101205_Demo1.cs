using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewRampUpAssign2.Migrations
{
    public partial class Demo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpInfo",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    City = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Mobile_no = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpInfo");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
