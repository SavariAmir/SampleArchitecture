using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductManagement.Persistence.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ProductManagement");

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventPublishDateTime = table.Column<DateTime>(nullable: false),
                    ProcessedDate = table.Column<DateTime>(nullable: false),
                    IsProcessed = table.Column<bool>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    LeafCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeafCategories",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SubCategoryId = table.Column<int>(nullable: false),
                    MainCategoryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Image_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeafCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategories",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Image_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    EnglishTitle = table.Column<string>(nullable: true),
                    Overview_AtAGlance = table.Column<string>(nullable: true),
                    Overview_Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    ProductDimension_Image_Name = table.Column<string>(nullable: true),
                    ProductDimension_Description = table.Column<string>(nullable: true),
                    ProductSpecification_Description = table.Column<string>(nullable: true),
                    ProductVideo_ProductVideoLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    LeafCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DimensionGroups",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    DimensionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimensionGroups_Dimensions_DimensionId",
                        column: x => x.DimensionId,
                        principalSchema: "ProductManagement",
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Image_Name = table.Column<string>(nullable: true),
                    MainCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalSchema: "ProductManagement",
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColorVarieties",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorType = table.Column<int>(nullable: false),
                    ColorImage_Name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    DiscountAmount = table.Column<decimal>(nullable: true),
                    DueAmount = table.Column<decimal>(nullable: true),
                    ProductPrice_DiscountPercent = table.Column<int>(nullable: true),
                    ProductImageType = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorVarieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColorVarieties_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ProductManagement",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDimensionItemValues",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensionItemId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDimensionItemValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDimensionItemValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ProductManagement",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecificationValues",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationItemId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "ProductManagement",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationGroups",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SpecificationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationGroups_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalSchema: "ProductManagement",
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimensionItems",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UnitOfMeasurementType = table.Column<int>(nullable: false),
                    DimensionGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimensionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DimensionItems_DimensionGroups_DimensionGroupId",
                        column: x => x.DimensionGroupId,
                        principalSchema: "ProductManagement",
                        principalTable: "DimensionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColorVarietyImages",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductColorVarietyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColorVarietyImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductColorVarietyImages_ProductColorVarieties_ProductColorVarietyId",
                        column: x => x.ProductColorVarietyId,
                        principalSchema: "ProductManagement",
                        principalTable: "ProductColorVarieties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationItems",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    SpecificationItemValueType = table.Column<int>(nullable: false),
                    SpecificationGroupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationItems_SpecificationGroups_SpecificationGroupId",
                        column: x => x.SpecificationGroupId,
                        principalSchema: "ProductManagement",
                        principalTable: "SpecificationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationItemsOptions",
                schema: "ProductManagement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    SpecificationItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationItemsOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationItemsOptions_SpecificationItems_SpecificationItemId",
                        column: x => x.SpecificationItemId,
                        principalSchema: "ProductManagement",
                        principalTable: "SpecificationItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryId",
                schema: "ProductManagement",
                table: "Categories",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionGroups_DimensionId",
                schema: "ProductManagement",
                table: "DimensionGroups",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionItems_DimensionGroupId",
                schema: "ProductManagement",
                table: "DimensionItems",
                column: "DimensionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorVarieties_ProductId",
                schema: "ProductManagement",
                table: "ProductColorVarieties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductColorVarietyImages_ProductColorVarietyId",
                schema: "ProductManagement",
                table: "ProductColorVarietyImages",
                column: "ProductColorVarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDimensionItemValues_ProductId",
                schema: "ProductManagement",
                table: "ProductDimensionItemValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationValues_ProductId",
                schema: "ProductManagement",
                table: "ProductSpecificationValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationGroups_SpecificationId",
                schema: "ProductManagement",
                table: "SpecificationGroups",
                column: "SpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationItems_SpecificationGroupId",
                schema: "ProductManagement",
                table: "SpecificationItems",
                column: "SpecificationGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationItemsOptions_SpecificationItemId",
                schema: "ProductManagement",
                table: "SpecificationItemsOptions",
                column: "SpecificationItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "DimensionItems",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "LeafCategories",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "ProductColorVarietyImages",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "ProductDimensionItemValues",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "ProductSpecificationValues",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "SpecificationItemsOptions",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "MainCategories",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "DimensionGroups",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "ProductColorVarieties",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "SpecificationItems",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "Dimensions",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "SpecificationGroups",
                schema: "ProductManagement");

            migrationBuilder.DropTable(
                name: "Specifications",
                schema: "ProductManagement");
        }
    }
}
