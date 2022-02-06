using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FurnitureAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Furniture");

            migrationBuilder.CreateTable(
                name: "AuthTokens",
                schema: "Furniture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFurnitures",
                schema: "Furniture",
                columns: table => new
                {
                    CategoryFurnitureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFurnitureName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryFurnitureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFurnitures", x => x.CategoryFurnitureId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMaterials",
                schema: "Furniture",
                columns: table => new
                {
                    CategoryMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryMaterialName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMaterials", x => x.CategoryMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Furniture",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientSurname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ClientPesel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientEmail = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ClientTown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientNumberHome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPostPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientInterested = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Furniture",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmployeeIsDelivered = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumberHome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmployeeSeniority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Furniture",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                schema: "Furniture",
                columns: table => new
                {
                    StatusOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusOrderName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StatusOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.StatusOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "Furniture",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryMaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialPrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MaterialUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialStockStatus = table.Column<int>(type: "int", nullable: false),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_CategoryMaterials_CategoryMaterialId",
                        column: x => x.CategoryMaterialId,
                        principalSchema: "Furniture",
                        principalTable: "CategoryMaterials",
                        principalColumn: "CategoryMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Furniture",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Furniture",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Furniture",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StatusOrderId = table.Column<int>(type: "int", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDateSubmission = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 6, 21, 28, 10, 190, DateTimeKind.Utc).AddTicks(754)),
                    OrderDateRealization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeadlineRealization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPrePayment = table.Column<double>(type: "float", nullable: false),
                    OrderPayment = table.Column<double>(type: "float", nullable: false),
                    OrderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Furniture",
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Furniture",
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalSchema: "Furniture",
                        principalTable: "StatusOrders",
                        principalColumn: "StatusOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                schema: "Furniture",
                columns: table => new
                {
                    FurnitureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CategoryFurnitureId = table.Column<int>(type: "int", nullable: false),
                    FurnitureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FurniturePrice = table.Column<double>(type: "float", nullable: false),
                    FurnitureUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnitureWidth = table.Column<double>(type: "float", nullable: false),
                    FurnitureHeight = table.Column<double>(type: "float", nullable: false),
                    FurnitureDepth = table.Column<double>(type: "float", nullable: false),
                    FurnitureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.FurnitureId);
                    table.ForeignKey(
                        name: "FK_Furnitures_CategoryFurnitures_CategoryFurnitureId",
                        column: x => x.CategoryFurnitureId,
                        principalSchema: "Furniture",
                        principalTable: "CategoryFurnitures",
                        principalColumn: "CategoryFurnitureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furnitures_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Furniture",
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterials",
                schema: "Furniture",
                columns: table => new
                {
                    FurnitureMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    FurnitureMaterialAmount = table.Column<int>(type: "int", nullable: false),
                    FurnitureMaterialPrice = table.Column<double>(type: "float", nullable: false),
                    FurnitureMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterials", x => x.FurnitureMaterialId);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterials_Furnitures_FurnitureId",
                        column: x => x.FurnitureId,
                        principalSchema: "Furniture",
                        principalTable: "Furnitures",
                        principalColumn: "FurnitureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalSchema: "Furniture",
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterials_FurnitureId",
                schema: "Furniture",
                table: "FurnitureMaterials",
                column: "FurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterials_MaterialId",
                schema: "Furniture",
                table: "FurnitureMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_CategoryFurnitureId",
                schema: "Furniture",
                table: "Furnitures",
                column: "CategoryFurnitureId");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_OrderId",
                schema: "Furniture",
                table: "Furnitures",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryMaterialId",
                schema: "Furniture",
                table: "Materials",
                column: "CategoryMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                schema: "Furniture",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                schema: "Furniture",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                schema: "Furniture",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "Furniture",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthTokens",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "FurnitureMaterials",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Furnitures",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "CategoryFurnitures",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "CategoryMaterials",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Furniture");

            migrationBuilder.DropTable(
                name: "StatusOrders",
                schema: "Furniture");
        }
    }
}
