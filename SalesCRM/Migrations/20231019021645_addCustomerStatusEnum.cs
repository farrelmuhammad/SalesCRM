﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesCRM.Migrations
{
    /// <inheritdoc />
    public partial class addCustomerStatusEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customer");
        }
    }
}
