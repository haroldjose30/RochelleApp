using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2._4_Infra.Data.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParamConfigurations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointRules",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invites",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    CustomerFromId = table.Column<string>(nullable: true),
                    CustomerToId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invites_Customers_CustomerFromId",
                        column: x => x.CustomerFromId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invites_Customers_CustomerToId",
                        column: x => x.CustomerToId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointCustomers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreOrders",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerFromId = table.Column<string>(nullable: true),
                    StoreOrderStatusId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOrders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrders_Customers_CustomerFromId",
                        column: x => x.CustomerFromId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrders_StoreOrderStatus_StoreOrderStatusId",
                        column: x => x.StoreOrderStatusId,
                        principalTable: "StoreOrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    History = table.Column<string>(nullable: true),
                    CustomerId = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    PointExtractType = table.Column<int>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: true),
                    PointAccountId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointAccountDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointAccountDetails_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PointAccountDetails_Customers_CustomerId",
                        column: x => x.CustomerId,
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
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    StoreOrderId = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrderItems_StoreProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "StoreProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreOrderItems_StoreOrders_StoreOrderId",
                        column: x => x.StoreOrderId,
                        principalTable: "StoreOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CompanyId",
                table: "Invites",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerFromId",
                table: "Invites",
                column: "CustomerFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_CustomerToId",
                table: "Invites",
                column: "CustomerToId");

            migrationBuilder.CreateIndex(
                name: "IX_ParamConfigurations_CompanyId",
                table: "ParamConfigurations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_CompanyId",
                table: "PointAccountDetails",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_CustomerId",
                table: "PointAccountDetails",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccountDetails_PointAccountId",
                table: "PointAccountDetails",
                column: "PointAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccounts_CompanyId",
                table: "PointAccounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointAccounts_CustomerId",
                table: "PointAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PointCustomers_CompanyId",
                table: "PointCustomers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PointCustomers_CustomerId",
                table: "PointCustomers",
                column: "CustomerId");

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
                name: "IX_StoreOrderItems_ProductId",
                table: "StoreOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrderItems_StoreOrderId",
                table: "StoreOrderItems",
                column: "StoreOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_CompanyId",
                table: "StoreOrders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_CustomerFromId",
                table: "StoreOrders",
                column: "CustomerFromId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrders_StoreOrderStatusId",
                table: "StoreOrders",
                column: "StoreOrderStatusId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");
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
