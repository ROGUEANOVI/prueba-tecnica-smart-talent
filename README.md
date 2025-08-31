# Prueba Técnica: Gestión de Productos

Este repositorio contiene la solución a la prueba técnica para la vacante (25019) Desarrollador Junior Plus .NET, que consiste en una aplicación web para la gestión de un catálogo de productos (CRUD).

## Stack Tecnológico

**Backend:**

- .NET 8
- ASP.NET Core Web API
- Clean Architecture
- Entity Framework Core 8
- AutoMapper
- SQL Server
- Swagger (OpenAPI) para documentación

**Frontend:**

- Angular 16
- TypeScript
- Tailwind CSS para el diseño
- RxJS para el manejo de estado
- Reactive Forms

## Requisitos Previos

Asegúrate de tener instalado el siguiente software:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js y npm](https://nodejs.org/) (v18 o superior)
- [Angular CLI](https://angular.io/cli) (v16 o superior)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (Express, Developer o cualquier edición)
- Una herramienta para gestionar Git (ej. Git Bash, Sourcetree, etc.).

---

## Guía de Instalación y Ejecución

Sigue estos pasos para levantar el proyecto en tu máquina local.

### 1. Repositorio

1.  **Clona el repositorio:**
    - Abre una terminal y ejecuta:
    ```bash
    git clone https://github.com/ROGUEANOVI/prueba-tecnica-smart-talent.git
    ```

### 2. Base de Datos

1.  Abre tu instancia de SQL Server.
2.  Ejecuta el script `create_products.sql` que se encuentra en la raíz de este repositorio. Esto creará la base de datos `ProductsDB`, la tabla `Products` y la poblará con datos de prueba.

### 3. Backend (.NET API)

1.  **Navega a la carpeta del backend:**
    ```bash
    cd Backend
    ```
2.  **Configura la cadena de conexión:** El proyecto está configurado para usar **User Secrets**. Guarda tu cadena de conexión ejecutando el siguiente comando desde la carpeta `Backend.WebApi`:
    ```bash
    dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=TU_SERVIDOR;Database=ProductsDB;User Id=TU_USUARIO;Password=TU_PASSWORD;TrustServerCertificate=True;"
    ```
    _Reemplaza los valores con tus credenciales de SQL Server._
3.  **Ejecuta la API:**
    ```bash
    dotnet run --project Backend.WebApi
    ```
4.  La API estará corriendo en `https://localhost:7165` (verifica el puerto en tu terminal). Puedes explorar la documentación de Swagger en `https://localhost:7165/swagger`.

5.  Otra alternativa para la creación de la base de datos, la tabla de los pruductos y una semilla de datos es ejecutar la migracion InitialMigration:

    - Abre una terminal en la raíz de la solución Backend.
    - Ejecuta el siguiente comando para aplicar las migraciones:

      ```bash
      dotnet ef database update --project Backend.Infrastructure --startup-project Backend.WebApi
      ```

      O desde el Package Manager Console de Visual Studio selecionando como proyecto por defecto BiblioFinder.Infrastructure:

      ```bash
      update-database
      ```

### 4. Frontend (Angular)

1.  **Abre una nueva terminal** y navega a la carpeta del frontend:
    ```bash
    cd frontend
    ```
2.  **Instala las dependencias:**
    ```bash
    npm install
    ```
3.  **Ejecuta la aplicación de Angular:**
    ```bash
    ng serve -o
    ```
4.  La aplicación se abrirá automáticamente en tu navegador en `http://localhost:4200`.

---

## Flujo de Git Utilizado

Este proyecto sigue la metodología **Git Flow**:

- `main`: Contiene el código de producción estable (el resultado final).
- `develop`: Es la rama principal de desarrollo donde se integran las funcionalidades.
- `feature/gestion-productos-HU-TEST-001`: Rama donde se desarrolló toda la historia de usuario.
