using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.PracticalTest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeRutaNulleable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paquetes_rutas_ruta_id",
                table: "paquetes");

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("81827279-4bc1-4015-9350-2d87ec21dbaf"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("c2f16a60-ee52-454b-9eb3-0a465857a610"));

            migrationBuilder.DeleteData(
                table: "rutas",
                keyColumn: "id",
                keyValue: new Guid("cd68ce3b-f466-475d-946d-9f704e16e44d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "rutas",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "rutas",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "paquetes",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ruta_id",
                table: "paquetes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "paquetes",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "paquete_historial",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_hora_cambio",
                table: "paquete_historial",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "paquete_historial",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "estados",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "estados",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abc"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("5604ea37-b304-475b-a214-d8b37581260c"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abe"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a24915f5-38d3-4f08-9889-40a776092d6a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bcd"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("602e793a-645c-4de9-b656-eb348e18c471"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bce"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8c833b7e-dfcc-428d-8ae2-1094c70c55f7"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cdc"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("7c5dddef-711a-4620-bffe-b97d38bb1ad0"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cde"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b45dacc7-74ae-42be-8fcb-08c0c7c81337"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

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
                name: "fk_paquetes_rutas_ruta_id",
                table: "paquetes",
                column: "ruta_id",
                principalTable: "rutas",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paquetes_rutas_ruta_id",
                table: "paquetes");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "rutas",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "rutas",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "paquetes",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ruta_id",
                table: "paquetes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "paquetes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "paquete_historial",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "fecha_hora_cambio",
                table: "paquete_historial",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "paquete_historial",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "estados",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "estados",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abc"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7202), new Guid("cd743b4f-d67d-4fed-af03-ab1dde078ef5"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7204) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("d12a3456-7890-abcd-ef01-234567890abe"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7211), new Guid("a5794df4-6fc3-4f7c-a091-87de51a12d37"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7211) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bcd"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7207), new Guid("a0e2c25f-91bb-4d76-9be2-ca2bad132599"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7207) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("e23b4567-8901-bcde-f012-345678901bce"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7212), new Guid("e9f8941f-70e4-4d09-9f2a-7b569b619bf2"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7212) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cdc"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7214), new Guid("38fe8cf4-4db1-4d67-ad79-09478853f1db"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "estados",
                keyColumn: "estado_id",
                keyValue: new Guid("f34c5678-9012-cdef-0123-456789012cde"),
                columns: new[] { "created_at", "id", "updated_at" },
                values: new object[] { new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7209), new Guid("bc0b8c32-16bd-4e58-ac30-60c83f76ffc2"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(7209) });

            migrationBuilder.InsertData(
                table: "rutas",
                columns: new[] { "id", "created_at", "created_by", "destino", "distancia", "is_active", "origen", "ruta_id", "tiempo_estimado", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { new Guid("81827279-4bc1-4015-9350-2d87ec21dbaf"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3592), new Guid("00000000-0000-0000-0000-000000000000"), "Guadalajara", 550.5m, true, "Ciudad de México", new Guid("c67f8901-2345-f012-3456-789012345f01"), 6.5m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3578), null },
                    { new Guid("c2f16a60-ee52-454b-9eb3-0a465857a610"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3597), new Guid("00000000-0000-0000-0000-000000000000"), "Nuevo Laredo", 220.0m, true, "Monterrey", new Guid("a45d6789-0123-def0-1234-567890123def"), 2.8m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3596), null },
                    { new Guid("cd68ce3b-f466-475d-946d-9f704e16e44d"), new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3635), new Guid("00000000-0000-0000-0000-000000000000"), "Mérida", 300.2m, true, "Cancún", new Guid("b56e7890-1234-ef01-2345-678901234ef0"), 4.0m, new DateTime(2026, 2, 8, 19, 54, 5, 699, DateTimeKind.Utc).AddTicks(3634), null }
                });

            migrationBuilder.AddForeignKey(
                name: "fk_paquetes_rutas_ruta_id",
                table: "paquetes",
                column: "ruta_id",
                principalTable: "rutas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
