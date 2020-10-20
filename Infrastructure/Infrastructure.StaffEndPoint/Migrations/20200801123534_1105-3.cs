using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.EndPoint.Migrations
{
    public partial class _11053 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_EntityStatuses_StatusId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredTable_Users_UserId",
                table: "RegisteredTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TableReserve_Users_UserId",
                table: "TableReserve");

            migrationBuilder.DropIndex(
                name: "IX_Bills_StatusId",
                table: "Bills");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserTransactionList",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TeamMember",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Team",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TableReserve",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RegisteredTable",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ProductRate",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Message",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Bills",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("042d0c7c-028d-4a54-be9b-1b019c7b7e27"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18b746d2-7eef-46b6-8ea8-d19de794ed74"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f19acd9-54df-4898-9a73-322bb21f0827"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("211d7f77-c324-417e-9e73-ba5bcc6c42ff"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f036ba7-c577-4870-ade8-c5b71bf5378b"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fb5d92d-a5a4-44b8-8a3d-83b7688372c8"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49f637fb-7434-4429-9a3d-0b061dfd9aee"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57dda9fa-feb2-46e0-b7c3-a619497f1545"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bff0dca-8871-44ba-b0ce-fd892c70dce1"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73c6db7c-858c-42a1-a004-528fc0d41924"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e2b0815-956a-432e-b675-21e60f1b1c43"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2881e4f-43ce-47df-ab15-edb746ef281d"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b29d2e3f-839f-4666-8da6-fb15dc3e955c"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b3215f0c-eb04-4371-b11b-6d554bd7deaa"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b38671d2-aaec-40b3-bd33-37570b2b0eea"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf856381-349c-41b6-ad9c-e54a2f054447"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c056d1cb-d42e-4c66-b430-cbfd4775a842"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c5ac0554-3e81-4655-97a2-35415a96afe1"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb76002a-43d6-4516-bcb1-d2782ad7c6c0"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cd9b33b5-881e-4d01-8cb2-67e75436ce36"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfeed39b-c410-4767-927c-1be02c8c9096"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("daf5bb7e-5d45-403f-a120-230bb35928eb"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1fa6eb1-2c9b-4c19-99bd-07655f1eaf04"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f36da1d0-11f6-4b0a-9bdd-292c4eb056e2"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("44fc4a46-6bd7-45d0-a911-b989ed4a944c"),
                column: "CreatedAt",
                value: 1596285332L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8114eb2e-3588-4239-98a4-f7e3023674e8"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "dZZGkmxkG1paWfj9k24vkkqxpZKpDlcLuh13vycOeGGgACQp2/f7gg==", "RyqCnsm/BgRXHguFcJRAnzjtcP6gaaXDeCowDahKOf//2D8a4N/kPg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredTable_Users_UserId",
                table: "RegisteredTable",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TableReserve_Users_UserId",
                table: "TableReserve",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredTable_Users_UserId",
                table: "RegisteredTable");

            migrationBuilder.DropForeignKey(
                name: "FK_TableReserve_Users_UserId",
                table: "TableReserve");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserTransactionList",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TeamMember",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Team",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "TableReserve",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "RegisteredTable",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ProductRate",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Message",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Bills",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("042d0c7c-028d-4a54-be9b-1b019c7b7e27"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18b746d2-7eef-46b6-8ea8-d19de794ed74"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1f19acd9-54df-4898-9a73-322bb21f0827"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("211d7f77-c324-417e-9e73-ba5bcc6c42ff"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f036ba7-c577-4870-ade8-c5b71bf5378b"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fb5d92d-a5a4-44b8-8a3d-83b7688372c8"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("49f637fb-7434-4429-9a3d-0b061dfd9aee"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57dda9fa-feb2-46e0-b7c3-a619497f1545"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69eb1978-7fc3-4936-b43b-ca1d3d1d90ad"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6b22b8a8-4402-4127-87f2-7e6df18bf0e6"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bff0dca-8871-44ba-b0ce-fd892c70dce1"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73c6db7c-858c-42a1-a004-528fc0d41924"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7e2b0815-956a-432e-b675-21e60f1b1c43"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86e88e9c-3e6c-4bf1-9f27-86fe1550f7cc"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a2881e4f-43ce-47df-ab15-edb746ef281d"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b29d2e3f-839f-4666-8da6-fb15dc3e955c"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b3215f0c-eb04-4371-b11b-6d554bd7deaa"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b38671d2-aaec-40b3-bd33-37570b2b0eea"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf856381-349c-41b6-ad9c-e54a2f054447"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c056d1cb-d42e-4c66-b430-cbfd4775a842"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c5ac0554-3e81-4655-97a2-35415a96afe1"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb76002a-43d6-4516-bcb1-d2782ad7c6c0"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cd9b33b5-881e-4d01-8cb2-67e75436ce36"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfeed39b-c410-4767-927c-1be02c8c9096"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d340e0f7-7ebd-4b3f-bc4c-115e224546d1"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("daf5bb7e-5d45-403f-a120-230bb35928eb"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1fa6eb1-2c9b-4c19-99bd-07655f1eaf04"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f36da1d0-11f6-4b0a-9bdd-292c4eb056e2"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("44fc4a46-6bd7-45d0-a911-b989ed4a944c"),
                column: "CreatedAt",
                value: 1596270657L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8114eb2e-3588-4239-98a4-f7e3023674e8"),
                columns: new[] { "Password", "Salt" },
                values: new object[] { "sQJ49XcP6tDVnUEOHYlSm1Bfpxykqp982Mv9GER7tTpj8qZjZHLP8Q==", "xcq0PZAs8Q/PHy7TEIJSkjSO9vCV8zlBfcBsCqftDqsjsDId9omAuQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Bills_StatusId",
                table: "Bills",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_EntityStatuses_StatusId",
                table: "Bills",
                column: "StatusId",
                principalTable: "EntityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredTable_Users_UserId",
                table: "RegisteredTable",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TableReserve_Users_UserId",
                table: "TableReserve",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
