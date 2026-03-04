using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.PracticalTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdsDuplicated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paquete_historial_estados_estado_id",
                table: "paquete_historial");

            migrationBuilder.DropForeignKey(
                name: "fk_paquetes_estados_estado_id",
                table: "paquetes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_estados",
                table: "estados");

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abc"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abe"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bcd"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bce"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cdc"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "estado_id",
                keyColumnType: "uuid",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cde"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("282ad3ba-7852-49f1-b80c-f6c60044792a"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("f6b4c57e-c367-491a-b823-a438f6ee60f4"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("ff4ee4ca-e364-4261-ae5f-59d0da0fb9f9"));

            migrationBuilder.DropColumn(
                name: "ruta_id",
                table: "rutas");

            migrationBuilder.DropColumn(
                name: "paquete_id",
                table: "paquetes");

            migrationBuilder.DropColumn(
                name: "estado_id",
                table: "estados");

            migrationBuilder.AddPrimaryKey(
                name: "pk_estados",
                table: "estados",
                column: "id");

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "id", "created_at", "created_by", "estado_descripcion", "is_active", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Registrado", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abe"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Reparto", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bcd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Bodega", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bce"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Entregado", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cdc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Devuelto", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cde"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Transito", true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "rutas",
                columns: new[] { "id", "created_at", "created_by", "destino", "distancia", "is_active", "origen", "tiempo_estimado", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("a45d6789-0123-def0-1234-567890123def"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo Laredo", 220.0m, true, "Monterrey", 2.8m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("b56e7890-1234-ef01-2345-678901234ef0"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Mérida", 300.2m, true, "Cancún", 4.0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("c67f8901-2345-f012-3456-789012345f01"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Guadalajara", 550.5m, true, "Ciudad de México", 6.5m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_paquete_historial_estados_estado_id",
                table: "paquete_historial",
                column: "estado_id",
                principalTable: "estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_paquetes_estados_estado_id",
                table: "paquetes",
                column: "estado_id",
                principalTable: "estados",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paquete_historial_estados_estado_id",
                table: "paquete_historial");

            migrationBuilder.DropForeignKey(
                name: "fk_paquetes_estados_estado_id",
                table: "paquetes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_estados",
                table: "estados");

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abc"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abe"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bcd"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bce"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cdc"));

            migrationBuilder.DeleteData(
                table: "estados",
                keyColumn: "id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cde"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("a45d6789-0123-def0-1234-567890123def"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("b56e7890-1234-ef01-2345-678901234ef0"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("c67f8901-2345-f012-3456-789012345f01"));

            migrationBuilder.AddColumn<Guid>(
                name: "ruta_id",
                table: "rutas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "paquete_id",
                table: "paquetes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "estado_id",
                table: "estados",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_estados",
                table: "estados",
                column: "estado_id");

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "estado_id", "created_at", "created_by", "estado_descripcion", "id", "is_active", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Registrado", new Guid("5604ea37-b304-475b-a214-d8b37581260c"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("d12a3456-7890-abcd-ef01-234567890abe"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Reparto", new Guid("a24915f5-38d3-4f08-9889-40a776092d6a"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bcd"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Bodega", new Guid("602e793a-645c-4de9-b656-eb348e18c471"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("e23b4567-8901-bcde-f012-345678901bce"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Entregado", new Guid("8c833b7e-dfcc-428d-8ae2-1094c70c55f7"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cdc"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Devuelto", new Guid("7c5dddef-711a-4620-bffe-b97d38bb1ad0"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f34c5678-9012-cdef-0123-456789012cde"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "En Transito", new Guid("b45dacc7-74ae-42be-8fcb-08c0c7c81337"), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.InsertData(
                table: "rutas",
                columns: new[] { "id", "created_at", "created_by", "destino", "distancia", "is_active", "origen", "ruta_id", "tiempo_estimado", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("282ad3ba-7852-49f1-b80c-f6c60044792a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Guadalajara", 550.5m, true, "Ciudad de México", new Guid("c67f8901-2345-f012-3456-789012345f01"), 6.5m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("f6b4c57e-c367-491a-b823-a438f6ee60f4"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Mérida", 300.2m, true, "Cancún", new Guid("b56e7890-1234-ef01-2345-678901234ef0"), 4.0m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null },
                    { new Guid("ff4ee4ca-e364-4261-ae5f-59d0da0fb9f9"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo Laredo", 220.0m, true, "Monterrey", new Guid("a45d6789-0123-def0-1234-567890123def"), 2.8m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_paquete_historial_estados_estado_id",
                table: "paquete_historial",
                column: "estado_id",
                principalTable: "estados",
                principalColumn: "estado_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_paquetes_estados_estado_id",
                table: "paquetes",
                column: "estado_id",
                principalTable: "estados",
                principalColumn: "estado_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
