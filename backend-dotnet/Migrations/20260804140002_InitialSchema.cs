using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "component",
                columns: table => new
                {
                    comp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    comp_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component", x => x.comp_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.invoice_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "manufacturer_master",
                columns: table => new
                {
                    manufacturer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    manufacturer_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer_master", x => x.manufacturer_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    company_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    company_address = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mobile = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gst_no = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    registration_no = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    st_no = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    vat_no = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tax_no = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    designation = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invoice_detail",
                columns: table => new
                {
                    invoice_detail_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    invoice_id = table.Column<int>(type: "int", nullable: false),
                    component_id = table.Column<int>(type: "int", nullable: false),
                    alternate_component_id = table.Column<int>(type: "int", nullable: false),
                    delta_price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_detail", x => x.invoice_detail_id);
                    table.ForeignKey(
                        name: "FK_invoice_detail_component_alternate_component_id",
                        column: x => x.alternate_component_id,
                        principalTable: "component",
                        principalColumn: "comp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_detail_component_component_id",
                        column: x => x.component_id,
                        principalTable: "component",
                        principalColumn: "comp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_detail_invoice_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "seg_mfg_master",
                columns: table => new
                {
                    seg_mfg_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    segment_id = table.Column<int>(type: "int", nullable: false),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seg_mfg_master", x => x.seg_mfg_id);
                    table.ForeignKey(
                        name: "FK_seg_mfg_master_manufacturer_master_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer_master",
                        principalColumn: "manufacturer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seg_mfg_master_segment_master_segment_id",
                        column: x => x.segment_id,
                        principalTable: "segment_master",
                        principalColumn: "segment_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "segment_manufacturer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    segment_id = table.Column<int>(type: "int", nullable: false),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_segment_manufacturer", x => x.id);
                    table.ForeignKey(
                        name: "FK_segment_manufacturer_manufacturer_master_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer_master",
                        principalColumn: "manufacturer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_segment_manufacturer_segment_master_segment_id",
                        column: x => x.segment_id,
                        principalTable: "segment_master",
                        principalColumn: "segment_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicle_model",
                columns: table => new
                {
                    model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    manufacturer_id = table.Column<int>(type: "int", nullable: false),
                    segment_id = table.Column<int>(type: "int", nullable: false),
                    model_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    base_price = table.Column<float>(type: "float", nullable: false),
                    minimum_quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_model", x => x.model_id);
                    table.ForeignKey(
                        name: "FK_vehicle_model_manufacturer_master_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer_master",
                        principalColumn: "manufacturer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_model_segment_master_segment_id",
                        column: x => x.segment_id,
                        principalTable: "segment_master",
                        principalColumn: "segment_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "model_master",
                columns: table => new
                {
                    model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mdl_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sm_id = table.Column<int>(type: "int", nullable: false),
                    min_qty_price = table.Column<double>(type: "double", nullable: false),
                    image_path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model_master", x => x.model_id);
                    table.ForeignKey(
                        name: "FK_model_master_segment_manufacturer_sm_id",
                        column: x => x.sm_id,
                        principalTable: "segment_manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alternate_component",
                columns: table => new
                {
                    alt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    model_id = table.Column<int>(type: "int", nullable: false),
                    comp_id = table.Column<int>(type: "int", nullable: false),
                    alt_comp_id = table.Column<int>(type: "int", nullable: false),
                    delta_price = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alternate_component", x => x.alt_id);
                    table.ForeignKey(
                        name: "FK_alternate_component_component_alt_comp_id",
                        column: x => x.alt_comp_id,
                        principalTable: "component",
                        principalColumn: "comp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alternate_component_component_comp_id",
                        column: x => x.comp_id,
                        principalTable: "component",
                        principalColumn: "comp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alternate_component_vehicle_model_model_id",
                        column: x => x.model_id,
                        principalTable: "vehicle_model",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicle_detail",
                columns: table => new
                {
                    config_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    model_id = table.Column<int>(type: "int", nullable: false),
                    comp_id = table.Column<int>(type: "int", nullable: false),
                    comp_type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_configurable = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle_detail", x => x.config_id);
                    table.ForeignKey(
                        name: "FK_vehicle_detail_component_comp_id",
                        column: x => x.comp_id,
                        principalTable: "component",
                        principalColumn: "comp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicle_detail_vehicle_model_model_id",
                        column: x => x.model_id,
                        principalTable: "vehicle_model",
                        principalColumn: "model_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_component_alt_comp_id",
                table: "alternate_component",
                column: "alt_comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_component_comp_id",
                table: "alternate_component",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_alternate_component_model_id",
                table: "alternate_component",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_detail_alternate_component_id",
                table: "invoice_detail",
                column: "alternate_component_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_detail_component_id",
                table: "invoice_detail",
                column: "component_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_detail_invoice_id",
                table: "invoice_detail",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_model_master_sm_id",
                table: "model_master",
                column: "sm_id");

            migrationBuilder.CreateIndex(
                name: "IX_seg_mfg_master_manufacturer_id",
                table: "seg_mfg_master",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_seg_mfg_master_segment_id",
                table: "seg_mfg_master",
                column: "segment_id");

            migrationBuilder.CreateIndex(
                name: "IX_segment_manufacturer_manufacturer_id",
                table: "segment_manufacturer",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_segment_manufacturer_segment_id",
                table: "segment_manufacturer",
                column: "segment_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_detail_comp_id",
                table: "vehicle_detail",
                column: "comp_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_detail_model_id",
                table: "vehicle_detail",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_manufacturer_id",
                table: "vehicle_model",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_segment_id",
                table: "vehicle_model",
                column: "segment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alternate_component");

            migrationBuilder.DropTable(
                name: "invoice_detail");

            migrationBuilder.DropTable(
                name: "model_master");

            migrationBuilder.DropTable(
                name: "seg_mfg_master");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "vehicle_detail");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "segment_manufacturer");

            migrationBuilder.DropTable(
                name: "component");

            migrationBuilder.DropTable(
                name: "vehicle_model");

            migrationBuilder.DropTable(
                name: "manufacturer_master");
        }
    }
}
