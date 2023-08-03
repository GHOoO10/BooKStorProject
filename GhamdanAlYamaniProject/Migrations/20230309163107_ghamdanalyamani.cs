using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhamdanAlYamaniProject.Migrations
{
    public partial class ghamdanalyamani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    A_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A_Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.A_Id);
                });

            migrationBuilder.CreateTable(
                name: "Catagorys",
                columns: table => new
                {
                    Cat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booktitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagorys", x => x.Cat_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    C_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Phone = table.Column<int>(type: "int", nullable: false),
                    C_Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.C_Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    B_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B_Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    B_Price = table.Column<int>(type: "int", nullable: false),
                    B_Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    A_Id = table.Column<int>(type: "int", nullable: false),
                    Cat_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.B_Id);
                    table.ForeignKey(
                        name: "FK_Book_Admins_A_Id",
                        column: x => x.A_Id,
                        principalTable: "Admins",
                        principalColumn: "A_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Catagorys_Cat_Id",
                        column: x => x.Cat_Id,
                        principalTable: "Catagorys",
                        principalColumn: "Cat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    O_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    O_Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    O_Amount = table.Column<int>(type: "int", nullable: false),
                    B_Id = table.Column<int>(type: "int", nullable: false),
                    C_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.O_Id);
                    table.ForeignKey(
                        name: "FK_Order_Book_B_Id",
                        column: x => x.B_Id,
                        principalTable: "Book",
                        principalColumn: "B_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customers_C_Id",
                        column: x => x.C_Id,
                        principalTable: "Customers",
                        principalColumn: "C_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_A_Id",
                table: "Book",
                column: "A_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Cat_Id",
                table: "Book",
                column: "Cat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_B_Id",
                table: "Order",
                column: "B_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_C_Id",
                table: "Order",
                column: "C_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Catagorys");
        }
    }
}
