using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiForeignKeys.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_Designations_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeTypeIdOne = table.Column<int>(nullable: true),
                    EmployeeTypeIdTwo = table.Column<int>(nullable: true),
                    EmployeeTypeIdThree = table.Column<int>(nullable: true),
                    DesignationIdOne = table.Column<int>(nullable: true),
                    DesignationIdTwo = table.Column<int>(nullable: true),
                    DesignationIdThree = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Designations_DesignationIdOne",
                        column: x => x.DesignationIdOne,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Designations_DesignationIdThree",
                        column: x => x.DesignationIdThree,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Designations_DesignationIdTwo",
                        column: x => x.DesignationIdTwo,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeIdOne",
                        column: x => x.EmployeeTypeIdOne,
                        principalTable: "EmployeeType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeIdThree",
                        column: x => x.EmployeeTypeIdThree,
                        principalTable: "EmployeeType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeIdTwo",
                        column: x => x.EmployeeTypeIdTwo,
                        principalTable: "EmployeeType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Designations_EmployeeTypeId",
                table: "Designations",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationIdOne",
                table: "Employee",
                column: "DesignationIdOne");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationIdThree",
                table: "Employee",
                column: "DesignationIdThree");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationIdTwo",
                table: "Employee",
                column: "DesignationIdTwo");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeIdOne",
                table: "Employee",
                column: "EmployeeTypeIdOne");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeIdThree",
                table: "Employee",
                column: "EmployeeTypeIdThree");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeIdTwo",
                table: "Employee",
                column: "EmployeeTypeIdTwo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeType");
        }
    }
}
