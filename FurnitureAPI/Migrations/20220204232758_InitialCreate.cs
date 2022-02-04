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
                    IdCategoryFurniture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryFurnitureName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryFurnitureDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFurnitures", x => x.IdCategoryFurniture);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMaterials",
                schema: "Furniture",
                columns: table => new
                {
                    IdCategoryMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryMaterialName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CategoryMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMaterials", x => x.IdCategoryMaterial);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Furniture",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Furniture",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Furniture",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                schema: "Furniture",
                columns: table => new
                {
                    IdStatusOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusOrderName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    StatusOrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.IdStatusOrder);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "Furniture",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoryMaterial = table.Column<int>(type: "int", nullable: false),
                    CategoryMaterialIdCategoryMaterial = table.Column<int>(type: "int", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaterialPrice = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    MaterialUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialStockStatus = table.Column<int>(type: "int", nullable: false),
                    MaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.IdMaterial);
                    table.ForeignKey(
                        name: "FK_Materials_CategoryMaterials_CategoryMaterialIdCategoryMaterial",
                        column: x => x.CategoryMaterialIdCategoryMaterial,
                        principalSchema: "Furniture",
                        principalTable: "CategoryMaterials",
                        principalColumn: "IdCategoryMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Furniture",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    RoleIdRole = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleIdRole",
                        column: x => x.RoleIdRole,
                        principalSchema: "Furniture",
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Furniture",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    ClientIdClient = table.Column<int>(type: "int", nullable: false),
                    IdEmployee = table.Column<int>(type: "int", nullable: false),
                    EmployeeIdEmployee = table.Column<int>(type: "int", nullable: false),
                    IdStatusOrder = table.Column<int>(type: "int", nullable: false),
                    StatusOrderIdStatusOrder = table.Column<int>(type: "int", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderDateSubmission = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 4, 23, 27, 57, 963, DateTimeKind.Utc).AddTicks(1305)),
                    OrderDateRealization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeadlineRealization = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPrePayment = table.Column<double>(type: "float", nullable: false),
                    OrderPayment = table.Column<double>(type: "float", nullable: false),
                    OrderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalSchema: "Furniture",
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employees_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalSchema: "Furniture",
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderIdStatusOrder",
                        column: x => x.StatusOrderIdStatusOrder,
                        principalSchema: "Furniture",
                        principalTable: "StatusOrders",
                        principalColumn: "IdStatusOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                schema: "Furniture",
                columns: table => new
                {
                    IdFurniture = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    OrderIdOrder = table.Column<int>(type: "int", nullable: false),
                    IdCategoryFurniture = table.Column<int>(type: "int", nullable: false),
                    CategoryFurnitureIdCategoryFurniture = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Furnitures", x => x.IdFurniture);
                    table.ForeignKey(
                        name: "FK_Furnitures_CategoryFurnitures_CategoryFurnitureIdCategoryFurniture",
                        column: x => x.CategoryFurnitureIdCategoryFurniture,
                        principalSchema: "Furniture",
                        principalTable: "CategoryFurnitures",
                        principalColumn: "IdCategoryFurniture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furnitures_Orders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalSchema: "Furniture",
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureMaterials",
                schema: "Furniture",
                columns: table => new
                {
                    IdFurnitureMaterial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFurniture = table.Column<int>(type: "int", nullable: false),
                    FurnitureIdFurniture = table.Column<int>(type: "int", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: false),
                    MaterialIdMaterial = table.Column<int>(type: "int", nullable: false),
                    FurnitureMaterialAmount = table.Column<int>(type: "int", nullable: false),
                    FurnitureMaterialPrice = table.Column<double>(type: "float", nullable: false),
                    FurnitureMaterialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureMaterials", x => x.IdFurnitureMaterial);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterials_Furnitures_FurnitureIdFurniture",
                        column: x => x.FurnitureIdFurniture,
                        principalSchema: "Furniture",
                        principalTable: "Furnitures",
                        principalColumn: "IdFurniture",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurnitureMaterials_Materials_MaterialIdMaterial",
                        column: x => x.MaterialIdMaterial,
                        principalSchema: "Furniture",
                        principalTable: "Materials",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterials_FurnitureIdFurniture",
                schema: "Furniture",
                table: "FurnitureMaterials",
                column: "FurnitureIdFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureMaterials_MaterialIdMaterial",
                schema: "Furniture",
                table: "FurnitureMaterials",
                column: "MaterialIdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_CategoryFurnitureIdCategoryFurniture",
                schema: "Furniture",
                table: "Furnitures",
                column: "CategoryFurnitureIdCategoryFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_OrderIdOrder",
                schema: "Furniture",
                table: "Furnitures",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_CategoryMaterialIdCategoryMaterial",
                schema: "Furniture",
                table: "Materials",
                column: "CategoryMaterialIdCategoryMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientIdClient",
                schema: "Furniture",
                table: "Orders",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeIdEmployee",
                schema: "Furniture",
                table: "Orders",
                column: "EmployeeIdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderIdStatusOrder",
                schema: "Furniture",
                table: "Orders",
                column: "StatusOrderIdStatusOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleIdRole",
                schema: "Furniture",
                table: "Users",
                column: "RoleIdRole");
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
