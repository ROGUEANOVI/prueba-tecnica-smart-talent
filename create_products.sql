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
('Port�til Ultrabook Avanzado', 'Port�til de 14 pulgadas con procesador Intel i7, 16GB RAM y 512GB SSD.', 1250.99),
('Smartphone de Gama Alta', 'Tel�fono m�vil con pantalla AMOLED de 6.7 pulgadas y triple c�mara.', 980.50),
('Monitor Curvo 32" 4K', 'Monitor para gaming y dise�o gr�fico con resoluci�n UHD y 144Hz.', 750.00),
('Teclado Mec�nico RGB', 'Teclado retroiluminado con switches Cherry MX Blue para una escritura precisa.', 155.75),
('Mouse Inal�mbrico Ergon�mico', 'Mouse con dise�o vertical para reducir la tensi�n en la mu�eca.', 89.90),
('Auriculares con Cancelaci�n de Ruido', 'Auriculares Bluetooth con tecnolog�a de cancelaci�n activa de ruido.', 250.00),
('Silla de Oficina Ergon�mica', 'Silla con soporte lumbar ajustable y reposabrazos 4D.', 320.40),
('Cafetera Superautom�tica', 'Prepara espressos y capuccinos con solo pulsar un bot�n.', 480.00),
('Robot Aspirador Inteligente', 'Robot que mapea tu hogar y se controla desde una app m�vil.', 399.99),
('Disco Duro Externo 2TB', 'Unidad de almacenamiento port�til USB 3.1 de alta velocidad.', 110.00),
('Tarjeta Gr�fica RTX 4070', 'GPU de �ltima generaci�n para gaming en 1440p y creaci�n de contenido.', 850.25),
('Bicicleta de Monta�a R29', 'Bicicleta con cuadro de aluminio, 21 velocidades y frenos de disco.', 650.00),
('Smart TV 55" QLED', 'Televisor inteligente con tecnolog�a Quantum Dot para colores m�s vivos.', 1150.95),
('Consola de Videojuegos Next-Gen', 'Consola de �ltima generaci�n con unidad de estado s�lido y gr�ficos avanzados.', 599.99),
('Mochila para Port�til Anti-robo', 'Mochila con compartimentos ocultos y material resistente a cortes.', 75.50),
('Taladro Percutor Inal�mbrico', 'Herramienta de 18V con dos bater�as de litio y malet�n de transporte.', 130.00),
('Juego de Sartenes Antiadherentes', 'Set de 3 sartenes de diferentes tama�os con recubrimiento de titanio.', 95.80),
('L�mpara de Escritorio LED', 'L�mpara con control t�ctil, brillo ajustable y temperatura de color variable.', 45.99),
('Freidora de Aire 5L', 'Freidora sin aceite con capacidad para toda la familia y panel digital.', 125.00),
('Sistema de Sonido Envolvente 5.1', 'Conjunto de altavoces para una experiencia de cine en casa.', 450.60),
('C�mara de Seguridad WiFi', 'C�mara IP con visi�n nocturna, detecci�n de movimiento y audio bidireccional.', 65.00),
('Impresora Multifunci�n L�ser', 'Imprime, escanea y copia con conexi�n WiFi y alta velocidad de impresi�n.', 210.00),
('Proyector de V�deo Full HD', 'Proyector con 8000 l�menes y capacidad para pantallas de hasta 300 pulgadas.', 290.50),
('Patinete El�ctrico Plegable', 'Patinete con autonom�a de 30km y velocidad m�xima de 25 km/h.', 420.00),
('Reloj Inteligente Deportivo', 'Smartwatch con GPS, medidor de frecuencia card�aca y seguimiento de sue�o.', 199.95),
('Purificador de Aire con Filtro HEPA', 'Elimina el 99.97% de al�rgenos y contaminantes del aire en habitaciones medianas.', 150.00),
('Olla de Cocci�n Lenta Programable', 'Olla de 6 litros ideal para preparar guisos y carnes tiernas.', 85.70),
('Set de Mancuernas Ajustables', 'Par de mancuernas que permiten cambiar el peso de 2.5kg a 24kg.', 280.00),
('Esterilla de Yoga Antideslizante', 'Esterilla de caucho natural para una pr�ctica de yoga segura y c�moda.', 55.20),
('Tienda de Campa�a para 4 Personas', 'Tienda impermeable y f�cil de montar, ideal para excursiones en familia.', 140.00);
GO

PRINT 'La base de datos ProductsDB y la tabla Products se han creado y poblado exitosamente.';
GO