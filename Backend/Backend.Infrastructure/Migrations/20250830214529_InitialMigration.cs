using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_Products_Price", "[Price] > 0");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Portátil de 14 pulgadas con procesador Intel i7, 16GB RAM y 512GB SSD.", "Portátil Ultrabook Avanzado", 1250.99m },
                    { 2, "Teléfono móvil con pantalla AMOLED de 6.7 pulgadas y triple cámara.", "Smartphone de Gama Alta", 980.50m },
                    { 3, "Monitor para gaming y diseño gráfico con resolución UHD y 144Hz.", "Monitor Curvo 32\" 4K", 750.00m },
                    { 4, "Teclado retroiluminado con switches Cherry MX Blue para una escritura precisa.", "Teclado Mecánico RGB", 155.75m },
                    { 5, "Mouse con diseño vertical para reducir la tensión en la muñeca.", "Mouse Inalámbrico Ergonómico", 89.90m },
                    { 6, "Auriculares Bluetooth con tecnología de cancelación activa de ruido.", "Auriculares con Cancelación de Ruido", 250.00m },
                    { 7, "Silla con soporte lumbar ajustable y reposabrazos 4D.", "Silla de Oficina Ergonómica", 320.40m },
                    { 8, "Prepara espressos y capuccinos con solo pulsar un botón.", "Cafetera Superautomática", 480.00m },
                    { 9, "Robot que mapea tu hogar y se controla desde una app móvil.", "Robot Aspirador Inteligente", 399.99m },
                    { 10, "Unidad de almacenamiento portátil USB 3.1 de alta velocidad.", "Disco Duro Externo 2TB", 110.00m },
                    { 11, "GPU de última generación para gaming en 1440p y creación de contenido.", "Tarjeta Gráfica RTX 4070", 850.25m },
                    { 12, "Bicicleta con cuadro de aluminio, 21 velocidades y frenos de disco.", "Bicicleta de Montaña R29", 650.00m },
                    { 13, "Televisor inteligente con tecnología Quantum Dot para colores más vivos.", "Smart TV 55\" QLED", 1150.95m },
                    { 14, "Consola de última generación con unidad de estado sólido y gráficos avanzados.", "Consola de Videojuegos Next-Gen", 599.99m },
                    { 15, "Mochila con compartimentos ocultos y material resistente a cortes.", "Mochila para Portátil Anti-robo", 75.50m },
                    { 16, "Herramienta de 18V con dos baterías de litio y maletín de transporte.", "Taladro Percutor Inalámbrico", 130.00m },
                    { 17, "Set de 3 sartenes de diferentes tamaños con recubrimiento de titanio.", "Juego de Sartenes Antiadherentes", 95.80m },
                    { 18, "Lámpara con control táctil, brillo ajustable y temperatura de color variable.", "Lámpara de Escritorio LED", 45.99m },
                    { 19, "Freidora sin aceite con capacidad para toda la familia y panel digital.", "Freidora de Aire 5L", 125.00m },
                    { 20, "Conjunto de altavoces para una experiencia de cine en casa.", "Sistema de Sonido Envolvente 5.1", 450.60m },
                    { 21, "Cámara IP con visión nocturna, detección de movimiento y audio bidireccional.", "Cámara de Seguridad WiFi", 65.00m },
                    { 22, "Imprime, escanea y copia con conexión WiFi y alta velocidad de impresión.", "Impresora Multifunción Láser", 210.00m },
                    { 23, "Proyector con 8000 lúmenes y capacidad para pantallas de hasta 300 pulgadas.", "Proyector de Vídeo Full HD", 290.50m },
                    { 24, "Patinete con autonomía de 30km y velocidad máxima de 25 km/h.", "Patinete Eléctrico Plegable", 420.00m },
                    { 25, "Smartwatch con GPS, medidor de frecuencia cardíaca y seguimiento de sueño.", "Reloj Inteligente Deportivo", 199.95m },
                    { 26, "Elimina el 99.97% de alérgenos y contaminantes del aire en habitaciones medianas.", "Purificador de Aire con Filtro HEPA", 150.00m },
                    { 27, "Olla de 6 litros ideal para preparar guisos y carnes tiernas.", "Olla de Cocción Lenta Programable", 85.70m },
                    { 28, "Par de mancuernas que permiten cambiar el peso de 2.5kg a 24kg.", "Set de Mancuernas Ajustables", 280.00m },
                    { 29, "Esterilla de caucho natural para una práctica de yoga segura y cómoda.", "Esterilla de Yoga Antideslizante", 55.20m },
                    { 30, "Tienda impermeable y fácil de montar, ideal para excursiones en familia.", "Tienda de Campaña para 4 Personas", 140.00m }
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
