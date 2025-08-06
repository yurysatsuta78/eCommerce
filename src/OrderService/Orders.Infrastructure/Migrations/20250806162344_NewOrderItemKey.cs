using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewOrderItemKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_CustomerOrders_CustomerOrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_CustomerOrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerOrders",
                table: "CustomerOrders");

            migrationBuilder.RenameTable(
                name: "CustomerOrders",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerOrderId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                columns: new[] { "OrderId", "ItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "CustomerOrders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "CustomerOrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerOrders",
                table: "CustomerOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CustomerOrderId",
                table: "OrderItems",
                column: "CustomerOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_CustomerOrders_CustomerOrderId",
                table: "OrderItems",
                column: "CustomerOrderId",
                principalTable: "CustomerOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
