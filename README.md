# Registro de Películas y Series

## 6.1. Información general

**Nombre del proyecto:** Registro de Películas y Series  
**Estudiante:** Maria Hormiga

Este proyecto consiste en una aplicación de escritorio que permite registrar y organizar información de películas y series. Surgió como una forma de tener una colección organizada, donde se puedan guardar datos como el título, el tipo de contenido, el género y el año.

La aplicación permite agregar nuevos registros, consultar los contenidos guardados, actualizar su información y eliminarlos cuando sea necesario.

Su objetivo principal es facilitar la administración de una colección de películas y series mediante una interfaz gráfica y una base de datos que permita conservar la información.

## 6.2. Funcionalidades

La aplicación cuenta con las siguientes funcionalidades:

- **Registrar:** permite agregar una película o serie ingresando su título, tipo, género y año.
- **Consultar:** muestra los contenidos registrados en una tabla.
- **Actualizar:** permite seleccionar un contenido y modificar la información que se encuentra almacenada.
- **Eliminar:** permite borrar un registro seleccionado.
- **Limpiar:** permite dejar vacíos los campos del formulario para realizar un nuevo registro.
- **Validar información:** comprueba que los campos estén completos y que el año ingresado sea válido. Si se introduce un dato incorrecto, muestra un mensaje indicando el error.

## 6.3. Tecnologías utilizadas

Para desarrollar la aplicación se utilizaron las siguientes tecnologías y herramientas:

- **C#:** lenguaje de programación utilizado para desarrollar la lógica del programa.
- **.NET 10:** plataforma utilizada para desarrollar y ejecutar la aplicación.
- **Avalonia UI 11.3.12:** utilizada para construir la interfaz gráfica mediante archivos XAML.
- **ADO.NET:** utilizado para establecer la conexión y realizar las operaciones con la base de datos.
- **SQLite:** sistema de base de datos donde se almacena la información.
- **Microsoft.Data.Sqlite 11.0.0:** biblioteca utilizada para conectar C# con SQLite.
- **Visual Studio Code:** entorno utilizado para escribir, organizar y ejecutar el código.

## 6.4. Estructura del proyecto

El proyecto está organizado en diferentes carpetas y archivos para separar la información, el acceso a los datos y la interfaz gráfica.

```text
RegistroPeliculasAvalonia/
│
├── Data/
│   └── ContenidoDAO.cs
│
├── Evidencias/
│   ├── Evidencia actualizacion.png
│   ├── Evidencia de validacion.png
│   ├── Evidencia eliminacion.png
│   ├── Evidencia persistencia parte 1 (ventana cerrada hora 12 48).png
│   ├── Evidencia persistencia parte 2 (ventana abierta).png
│   └── Evidencia registro y consulta.png
│
├── Models/
│   └── Contenido.cs
│
├── App.axaml
├── App.axaml.cs
├── app.manifest
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── Program.cs
├── RegistroPeliculasAvalonia.csproj
├── contenido.db
└── README.md
```

**Contenido.cs:** es la clase que representa cada película o serie. Contiene las propiedades Id, Titulo, Tipo, Genero y Anio, que permiten organizar la información de cada registro.

**ContenidoDAO.cs:** se encarga de la conexión con SQLite y contiene los métodos para guardar, consultar, modificar y eliminar los registros.

**MainWindow.axaml:** contiene los elementos visuales de la aplicación, como los campos de texto, las opciones para seleccionar el tipo de contenido, los botones y la tabla donde se muestran los registros.

**MainWindow.axaml.cs:** contiene los eventos de los botones, las validaciones y la comunicación entre la interfaz gráfica y la clase encargada del acceso a los datos.

**Program.cs y App.axaml:** contienen los elementos necesarios para iniciar y configurar la aplicación.

En el proyecto se aplica la programación orientada a objetos mediante la creación de clases, el uso de propiedades y métodos, y la separación de responsabilidades. De esta manera, la información de los contenidos, las operaciones de la base de datos y la interfaz gráfica se encuentran organizadas en diferentes componentes.

## 6.5. Instalación de dependencias

Para ejecutar el proyecto en otro computador se necesita tener instalado el SDK de .NET 10 y contar con Visual Studio Code o un entorno compatible.

Primero se debe descargar o clonar el repositorio de GitHub y abrir la carpeta `RegistroPeliculasAvalonia`.

Desde la terminal, dentro de la carpeta del proyecto, se ejecuta el siguiente comando para restaurar las dependencias:

```powershell
dotnet restore
```

Los paquetes de Avalonia UI y Microsoft.Data.Sqlite se encuentran declarados en el archivo `RegistroPeliculasAvalonia.csproj`, por lo que se restauran mediante el comando anterior.

También se debe conservar el archivo `contenido.db`, ya que contiene la base de datos utilizada por la aplicación.

## 6.6. Ejecución del programa

Después de descargar el proyecto y restaurar sus dependencias, se debe abrir una terminal dentro de la carpeta `RegistroPeliculasAvalonia` y ejecutar:

```powershell
dotnet run
```

Al ejecutar el comando, se inicia la aplicación y se abre la ventana de Registro de Películas y Series, desde donde se pueden utilizar las funcionalidades disponibles.

## 6.7. Base de datos

Para almacenar la información se utiliza SQLite mediante la biblioteca Microsoft.Data.Sqlite.

La base de datos se llama `contenido.db` y contiene una tabla llamada `Contenido`, que almacena los siguientes campos:

| Campo | Tipo | Descripción |
|---|---|---|
| Id | INTEGER | Identificador único del registro. |
| Titulo | TEXT | Nombre de la película o serie. |
| Tipo | TEXT | Indica si el contenido es película o serie. |
| Genero | TEXT | Género del contenido. |
| Anio | INTEGER | Año de lanzamiento. |

La conexión con la base de datos se realiza desde la clase `ContenidoDAO.cs`, donde se utilizan comandos SQL para ejecutar las operaciones CRUD.

- **Create:** se realiza mediante el método `Guardar()`, que registra un nuevo contenido.
- **Read:** se realiza mediante el método `ObtenerTodos()`, que consulta los registros almacenados.
- **Update:** se realiza mediante el método `Modificar()`, que actualiza la información de un registro.
- **Delete:** se realiza mediante el método `Eliminar()`, que borra un registro seleccionado.

Las consultas utilizan parámetros para enviar la información ingresada por el usuario y se emplean bloques `using` para administrar las conexiones y los recursos.

El proyecto incluye el archivo `contenido.db` con la tabla necesaria para su funcionamiento. Por esta razón, se debe conservar este archivo al descargar o ejecutar la aplicación.

## 6.8. Evidencias de funcionamiento

Se realizaron las pruebas solicitadas para comprobar que las operaciones de la aplicación funcionaran correctamente.

### 1. Registro y consulta

Se registró un contenido y se comprobó que apareciera en la tabla de la aplicación.

![Evidencia de registro y consulta](Evidencias/Evidencia%20registro%20y%20consulta.png)

### 2. Actualización

Se seleccionó un registro existente, se modificó su información y se comprobó que los cambios se reflejaran en la tabla.

![Evidencia de actualización](Evidencias/Evidencia%20actualizacion.png)

### 3. Eliminación

Se seleccionó un contenido y se utilizó la opción de eliminar. Después se comprobó que el registro ya no apareciera en la tabla.

![Evidencia de eliminación](Evidencias/Evidencia%20eliminacion.png)

### 4. Validación

Se ingresó un año incorrecto para comprobar que la aplicación identificara el dato inválido y mostrara un mensaje indicando el error.

![Evidencia de validación](Evidencias/Evidencia%20de%20validacion.png)

### 5. Persistencia

Se cerró la aplicación y posteriormente se volvió a abrir para comprobar que los registros guardados continuaran disponibles.

**Primera parte: aplicación cerrada.**

![Evidencia de persistencia parte 1](Evidencias/Evidencia%20persistencia%20parte%201%20%28ventana%20cerrada%20hora%2012%2048%29.png)

**Segunda parte: aplicación abierta nuevamente.**

![Evidencia de persistencia parte 2](Evidencias/Evidencia%20persistencia%20parte%202%20%28ventana%20abierta%29.png)

## 6.9. Problemas encontrados y soluciones

Durante el desarrollo se presentaron algunas dificultades al integrar la interfaz gráfica con la base de datos SQLite, especialmente al conectar los botones con las operaciones correspondientes.

Para solucionarlo, se organizó el código en diferentes clases, separando la información de los contenidos, las operaciones de acceso a datos y los eventos de la ventana principal.

También fue necesario revisar las consultas SQL y los eventos de los botones para que cada operación se ejecutara correctamente. Finalmente, se realizaron pruebas para comprobar que los registros pudieran guardarse, consultarse, modificarse y eliminarse, y que la información permaneciera almacenada después de cerrar y volver a abrir la aplicación.