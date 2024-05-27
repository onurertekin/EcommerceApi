﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class EntitiesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Orders_OrderId",
                table: "CustomerAddresses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddresses_OrderId",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CustomerAddresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CustomerAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_OrderId",
                table: "CustomerAddresses",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Orders_OrderId",
                table: "CustomerAddresses",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}