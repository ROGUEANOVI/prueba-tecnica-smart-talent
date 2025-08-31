IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'ProductsDB')
BEGIN
    CREATE DATABASE ProductsDB;
END
GO

USE ProductsDB;
GO

IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Products;
END
GO

CREATE TABLE dbo.Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255) NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT UQ_Products_Name UNIQUE (Name),
    CONSTRAINT CK_Products_Price CHECK (Price > 0)
);
GO

INSERT INTO dbo.Products (Name, Description, Price) VALUES
('Portátil Ultrabook Avanzado', 'Portátil de 14 pulgadas con procesador Intel i7, 16GB RAM y 512GB SSD.', 1250.99),
('Smartphone de Gama Alta', 'Teléfono móvil con pantalla AMOLED de 6.7 pulgadas y triple cámara.', 980.50),
('Monitor Curvo 32" 4K', 'Monitor para gaming y diseño gráfico con resolución UHD y 144Hz.', 750.00),
('Teclado Mecánico RGB', 'Teclado retroiluminado con switches Cherry MX Blue para una escritura precisa.', 155.75),
('Mouse Inalámbrico Ergonómico', 'Mouse con diseño vertical para reducir la tensión en la muñeca.', 89.90),
('Auriculares con Cancelación de Ruido', 'Auriculares Bluetooth con tecnología de cancelación activa de ruido.', 250.00),
('Silla de Oficina Ergonómica', 'Silla con soporte lumbar ajustable y reposabrazos 4D.', 320.40),
('Cafetera Superautomática', 'Prepara espressos y capuccinos con solo pulsar un botón.', 480.00),
('Robot Aspirador Inteligente', 'Robot que mapea tu hogar y se controla desde una app móvil.', 399.99),
('Disco Duro Externo 2TB', 'Unidad de almacenamiento portátil USB 3.1 de alta velocidad.', 110.00),
('Tarjeta Gráfica RTX 4070', 'GPU de última generación para gaming en 1440p y creación de contenido.', 850.25),
('Bicicleta de Montaña R29', 'Bicicleta con cuadro de aluminio, 21 velocidades y frenos de disco.', 650.00),
('Smart TV 55" QLED', 'Televisor inteligente con tecnología Quantum Dot para colores más vivos.', 1150.95),
('Consola de Videojuegos Next-Gen', 'Consola de última generación con unidad de estado sólido y gráficos avanzados.', 599.99),
('Mochila para Portátil Anti-robo', 'Mochila con compartimentos ocultos y material resistente a cortes.', 75.50),
('Taladro Percutor Inalámbrico', 'Herramienta de 18V con dos baterías de litio y maletín de transporte.', 130.00),
('Juego de Sartenes Antiadherentes', 'Set de 3 sartenes de diferentes tamaños con recubrimiento de titanio.', 95.80),
('Lámpara de Escritorio LED', 'Lámpara con control táctil, brillo ajustable y temperatura de color variable.', 45.99),
('Freidora de Aire 5L', 'Freidora sin aceite con capacidad para toda la familia y panel digital.', 125.00),
('Sistema de Sonido Envolvente 5.1', 'Conjunto de altavoces para una experiencia de cine en casa.', 450.60),
('Cámara de Seguridad WiFi', 'Cámara IP con visión nocturna, detección de movimiento y audio bidireccional.', 65.00),
('Impresora Multifunción Láser', 'Imprime, escanea y copia con conexión WiFi y alta velocidad de impresión.', 210.00),
('Proyector de Vídeo Full HD', 'Proyector con 8000 lúmenes y capacidad para pantallas de hasta 300 pulgadas.', 290.50),
('Patinete Eléctrico Plegable', 'Patinete con autonomía de 30km y velocidad máxima de 25 km/h.', 420.00),
('Reloj Inteligente Deportivo', 'Smartwatch con GPS, medidor de frecuencia cardíaca y seguimiento de sueño.', 199.95),
('Purificador de Aire con Filtro HEPA', 'Elimina el 99.97% de alérgenos y contaminantes del aire en habitaciones medianas.', 150.00),
('Olla de Cocción Lenta Programable', 'Olla de 6 litros ideal para preparar guisos y carnes tiernas.', 85.70),
('Set de Mancuernas Ajustables', 'Par de mancuernas que permiten cambiar el peso de 2.5kg a 24kg.', 280.00),
('Esterilla de Yoga Antideslizante', 'Esterilla de caucho natural para una práctica de yoga segura y cómoda.', 55.20),
('Tienda de Campaña para 4 Personas', 'Tienda impermeable y fácil de montar, ideal para excursiones en familia.', 140.00);
GO

PRINT 'La base de datos ProductsDB y la tabla Products se han creado y poblado exitosamente.';
GO