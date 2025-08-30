using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                entity.Property(p => p.Description)
                    .IsRequired(false)
                    .HasMaxLength(255);

                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");

                entity.Property(p => p.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");
                
                entity.HasIndex(p => p.Name).IsUnique()
                    .HasDatabaseName("UQ_Products_Name");
                
                entity.ToTable(t => t.HasCheckConstraint("CK_Products_Price", "[Price] > 0"));

                entity.HasData(
                    new Product { Id = 1, Name = "Portátil Ultrabook Avanzado", Description = "Portátil de 14 pulgadas con procesador Intel i7, 16GB RAM y 512GB SSD.", Price = 1250.99m },
                    new Product { Id = 2, Name = "Smartphone de Gama Alta", Description = "Teléfono móvil con pantalla AMOLED de 6.7 pulgadas y triple cámara.", Price = 980.50m },
                    new Product { Id = 3, Name = "Monitor Curvo 32\" 4K", Description = "Monitor para gaming y diseño gráfico con resolución UHD y 144Hz.", Price = 750.00m },
                    new Product { Id = 4, Name = "Teclado Mecánico RGB", Description = "Teclado retroiluminado con switches Cherry MX Blue para una escritura precisa.", Price = 155.75m },
                    new Product { Id = 5, Name = "Mouse Inalámbrico Ergonómico", Description = "Mouse con diseño vertical para reducir la tensión en la muñeca.", Price = 89.90m },
                    new Product { Id = 6, Name = "Auriculares con Cancelación de Ruido", Description = "Auriculares Bluetooth con tecnología de cancelación activa de ruido.", Price = 250.00m },
                    new Product { Id = 7, Name = "Silla de Oficina Ergonómica", Description = "Silla con soporte lumbar ajustable y reposabrazos 4D.", Price = 320.40m },
                    new Product { Id = 8, Name = "Cafetera Superautomática", Description = "Prepara espressos y capuccinos con solo pulsar un botón.", Price = 480.00m },
                    new Product { Id = 9, Name = "Robot Aspirador Inteligente", Description = "Robot que mapea tu hogar y se controla desde una app móvil.", Price = 399.99m },
                    new Product { Id = 10, Name = "Disco Duro Externo 2TB", Description = "Unidad de almacenamiento portátil USB 3.1 de alta velocidad.", Price = 110.00m },
                    new Product { Id = 11, Name = "Tarjeta Gráfica RTX 4070", Description = "GPU de última generación para gaming en 1440p y creación de contenido.", Price = 850.25m },
                    new Product { Id = 12, Name = "Bicicleta de Montaña R29", Description = "Bicicleta con cuadro de aluminio, 21 velocidades y frenos de disco.", Price = 650.00m },
                    new Product { Id = 13, Name = "Smart TV 55\" QLED", Description = "Televisor inteligente con tecnología Quantum Dot para colores más vivos.", Price = 1150.95m },
                    new Product { Id = 14, Name = "Consola de Videojuegos Next-Gen", Description = "Consola de última generación con unidad de estado sólido y gráficos avanzados.", Price = 599.99m },
                    new Product { Id = 15, Name = "Mochila para Portátil Anti-robo", Description = "Mochila con compartimentos ocultos y material resistente a cortes.", Price = 75.50m },
                    new Product { Id = 16, Name = "Taladro Percutor Inalámbrico", Description = "Herramienta de 18V con dos baterías de litio y maletín de transporte.", Price = 130.00m },
                    new Product { Id = 17, Name = "Juego de Sartenes Antiadherentes", Description = "Set de 3 sartenes de diferentes tamaños con recubrimiento de titanio.", Price = 95.80m },
                    new Product { Id = 18, Name = "Lámpara de Escritorio LED", Description = "Lámpara con control táctil, brillo ajustable y temperatura de color variable.", Price = 45.99m },
                    new Product { Id = 19, Name = "Freidora de Aire 5L", Description = "Freidora sin aceite con capacidad para toda la familia y panel digital.", Price = 125.00m },
                    new Product { Id = 20, Name = "Sistema de Sonido Envolvente 5.1", Description = "Conjunto de altavoces para una experiencia de cine en casa.", Price = 450.60m },
                    new Product { Id = 21, Name = "Cámara de Seguridad WiFi", Description = "Cámara IP con visión nocturna, detección de movimiento y audio bidireccional.", Price = 65.00m },
                    new Product { Id = 22, Name = "Impresora Multifunción Láser", Description = "Imprime, escanea y copia con conexión WiFi y alta velocidad de impresión.", Price = 210.00m },
                    new Product { Id = 23, Name = "Proyector de Vídeo Full HD", Description = "Proyector con 8000 lúmenes y capacidad para pantallas de hasta 300 pulgadas.", Price = 290.50m },
                    new Product { Id = 24, Name = "Patinete Eléctrico Plegable", Description = "Patinete con autonomía de 30km y velocidad máxima de 25 km/h.", Price = 420.00m },
                    new Product { Id = 25, Name = "Reloj Inteligente Deportivo", Description = "Smartwatch con GPS, medidor de frecuencia cardíaca y seguimiento de sueño.", Price = 199.95m },
                    new Product { Id = 26, Name = "Purificador de Aire con Filtro HEPA", Description = "Elimina el 99.97% de alérgenos y contaminantes del aire en habitaciones medianas.", Price = 150.00m },
                    new Product { Id = 27, Name = "Olla de Cocción Lenta Programable", Description = "Olla de 6 litros ideal para preparar guisos y carnes tiernas.", Price = 85.70m },
                    new Product { Id = 28, Name = "Set de Mancuernas Ajustables", Description = "Par de mancuernas que permiten cambiar el peso de 2.5kg a 24kg.", Price = 280.00m },
                    new Product { Id = 29, Name = "Esterilla de Yoga Antideslizante", Description = "Esterilla de caucho natural para una práctica de yoga segura y cómoda.", Price = 55.20m },
                    new Product { Id = 30, Name = "Tienda de Campaña para 4 Personas", Description = "Tienda impermeable y fácil de montar, ideal para excursiones en familia.", Price = 140.00m }
                );
            });
        }
    }
}
