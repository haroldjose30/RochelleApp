using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    FantasyName = table.Column<string>(nullable: true),
                    CorporateNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreOrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParamConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParamConfigurations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointToGain = table.Column<double>(nullable: false),
                    RegisterState = table.Column<int>(nullable: false),
                    PointRuleType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointRules_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RegisterState = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    CustomerFromId = table.Column<string>(nullable: true),
                    CustomerFromId1 = table.Column<Guid>(nullable: true),
                    CustomerToId = table.Column<string>(nullable: true),
                    CustomerToId1 = table.Column<Guid>(nullable: true),
                    InviteStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invites_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invites_Customers_CustomerFromId1",
                        column: x => x.CustomerFromId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invites_Customers_CustomerToId1",
                        column: x => x.CustomerToId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointAccounts_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    InvitesQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointCustomers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointCustomers_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerFromId = table.Column<string>(nullable: true),
                    CustomerFromId1 = table.Column<Guid>(nullable: true),
                    StoreOrderStatusId = table.Column<string>(nullable: true),
                    StoreOrderStatusId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOrders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreOrders_Customers_CustomerFromId1",
                        column: x => x.CustomerFromId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrders_StoreOrderStatus_StoreOrderStatusId1",
                        column: x => x.StoreOrderStatusId1,
                        principalTable: "StoreOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    ValuePoint = table.Column<decimal>(nullable: false),
                    ValueMoney = table.Column<decimal>(nullable: false),
                    RegisterState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointAccountDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    History = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    PointExtractType = table.Column<int>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    PointAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointAccountDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointAccountDetails_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointAccountDetails_PointAccounts_PointAccountId",
                        column: x => x.PointAccountId,
                        principalTable: "PointAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    StoreOrderId = table.Column<string>(nullable: true),
                    StoreOrderId1 = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductId1 = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    ValuePoint = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOrderItems_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreOrderItems_StoreProducts_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "StoreProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrderItems_StoreOrders_StoreOrderId1",
                        column: x => x.StoreOrderId1,
                        principalTable: "StoreOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CompanyName", "CorporateNumber", "CreatedBy", "CreatedDate", "Deleted", "FantasyName", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("29511eb8-1137-446f-90aa-d6947d4c9eae"), "Admin", "Admin", "Admin", "20191103 23:58:50", false, "Admin", "Admin", "20191103 23:58:50" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Deleted", "Email", "Login", "ModifiedBy", "ModifiedDate", "Name", "Password", "State" },
                values: new object[] { new Guid("799318fc-f931-4c9c-b924-e87a9b104c67"), new Guid("29511eb8-1137-446f-90aa-d6947d4c9eae"), "Admin", "20191103 23:58:50", false, "admin@admin.com", "Admin", "Admin", "20191103 23:58:50", "Admin", "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CompanyId",
                table: "Invites",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerFromId1",
                table: "Invites",
                column: "CustomerFromId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerToId1",
                table: "Invites",
                column: "CustomerToId1");

            migrationBuilder.CreateIndex(
                name: "IX_ParamConfigurations_CompanyId",
                table: "ParamConfigurations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_CompanyId",
                table: "PointAccountDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_CustomerId1",
                table: "PointAccountDetails",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_PointAccountId",
                table: "PointAccountDetails",
                column: "PointAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccounts_CompanyId",
                table: "PointAccounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccounts_CustomerId1",
                table: "PointAccounts",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PointCustomers_CompanyId",
                table: "PointCustomers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointCustomers_CustomerId1",
                table: "PointCustomers",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_PointRules_CompanyId",
                table: "PointRules",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrderItems_CompanyId",
                table: "StoreOrderItems",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrderItems_ProductId1",
                table: "StoreOrderItems",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrderItems_StoreOrderId1",
                table: "StoreOrderItems",
                column: "StoreOrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_CompanyId",
                table: "StoreOrders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_CustomerFromId1",
                table: "StoreOrders",
                column: "CustomerFromId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_StoreOrderStatusId1",
                table: "StoreOrders",
                column: "StoreOrderStatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_CompanyId",
                table: "StoreProducts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_ProductId",
                table: "StoreProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invites");

            migrationBuilder.DropTable(
                name: "ParamConfigurations");

            migrationBuilder.DropTable(
                name: "PointAccountDetails");

            migrationBuilder.DropTable(
                name: "PointCustomers");

            migrationBuilder.DropTable(
                name: "PointRules");

            migrationBuilder.DropTable(
                name: "StoreOrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PointAccounts");

            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.DropTable(
                name: "StoreOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "StoreOrderStatus");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
