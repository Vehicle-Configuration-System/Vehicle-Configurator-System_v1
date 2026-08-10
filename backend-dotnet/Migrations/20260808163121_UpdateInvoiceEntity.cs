using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInvoiceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "final_amount",
                table: "invoice",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "invoice_date",
                table: "invoice",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "model_id",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "tax",
                table: "invoice",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "total_amount",
                table: "invoice",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_model_id",
                table: "invoice",
                column: "model_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_user_id",
                table: "invoice",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_users_user_id",
                table: "invoice",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_vehicle_model_model_id",
                table: "invoice",
                column: "model_id",
                principalTable: "vehicle_model",
                principalColumn: "model_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_users_user_id",
                table: "invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_invoice_vehicle_model_model_id",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_model_id",
                table: "invoice");

            migrationBuilder.DropIndex(
                name: "IX_invoice_user_id",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "final_amount",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "invoice_date",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "model_id",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "tax",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "total_amount",
                table: "invoice");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "invoice");
        }
    }
}
