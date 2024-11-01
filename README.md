LibrosApi
LibrosApi es una API RESTful para la gestión de libros, que permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) en una base de datos de libros. La arquitectura del proyecto sigue un diseño en capas:

Presentation (API): Define los endpoints y controla las solicitudes HTTP. Incluye el controlador para manejar libros y la configuración de Swagger para la documentación de la API. La conexión a la base de datos se configura de manera dinámica, utilizando el nombre de la máquina donde se ejecuta la API.

Application (Lógica de Negocio): Contiene los servicios e interfaces que implementan la lógica de negocio, como la gestión de operaciones CRUD en libros. Coordina la interacción entre la API y la capa de acceso a datos.

Domain (Entidades del Dominio): Define las entidades, como Book, y las interfaces de repositorio. Esta capa representa el modelo de datos y las reglas del negocio.

Infrastructure (Acceso a Datos): Implementa los repositorios que interactúan con la base de datos a través de ApplicationDbContext, utilizando Entity Framework Core para realizar operaciones en la base de datos.

Configuración Dinámica de la Base de Datos
La cadena de conexión se configura dinámicamente en Program.cs usando el nombre de la máquina, permitiendo que la API se adapte a diferentes entornos:

csharp
Copiar código
string machineName = Environment.MachineName;
string connectionString = $"Data Source={machineName};Initial Catalog=LibraryDB;Integrated Security=True;";
Ejecución
Clona el repositorio y configura la cadena de conexión en Program.cs.
Ejecuta las migraciones de Entity Framework: dotnet ef database update.
Inicia la API con dotnet run.