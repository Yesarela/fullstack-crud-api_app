# FullStack CRUD - ReactJS & ASP.NET

## Requerimientos

`.NET Core SDK`: [Descargar versión v8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

`Microsoft SQL Server Express`: [Descargar versión 2022+](https://go.microsoft.com/fwlink/p/?linkid=2216019&clcid=0x40A&culture=es-es&country=es)

`Git`: [Descargar versión v2.45+](https://git-scm.com/downloads)

`NodeJS 20+`: [Descargar versión v20.14.0](https://nodejs.org/dist/v20.14.0/node-v20.14.0-x64.msi)

# API

## Pasos a seguir

### Configurar la versión de ejecución del SDK

Para esto necesitamos editar el archivo `./global.json` en base a la versión que tengamos instalada de .NET 8, debemos verificar con el siguiente comando:

    dotnet --version

Una vez sabemos que versión exacta es la que contamos editamos el archivo `./global.json` en base a la versión que contamos de .NET y nos quedaría de la siguiente manera:    

```
{
  "sdk": {
    "version": "8.0.300",
    "rollForward": "latestMajor"
  }
}
```

### Configurar el `appsettings.json` con nuestra cadena de conexión

Debemos de editar el archivo que se encuentra `./src/API_CleanArchitecture.Web/appsettings.json` y en el deberá estar la cadena de conexión con las credenciales del servidor que configuramos en la instalación de `Microsoft SQL Server Express` quedando algo similar a esto:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=db_customer;User=user;Password=pass"
  },
  "Serilog": {
    "MinimumLevel": {
      "Default": "Information"
    },
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      }
    ]
  },
  "Mailserver": {
    "Server": "localhost",
    "Port": 25
  }
}
```

### Restaurar el proyecto

Para restaurar el proyecto debemos estar en la raíz del repositorio y ejecutar lo siguiente:

    dotnet restore

### Compilar la solución

Siempre desde la raíz del repositorio ejecutamos el siguiente comando:

    dotnet build

### Ejecutar la solución

Para ejecutar la solución debidamente, nos dirigimos a la siguiente ruta `./src/API_CleanArchitecture.Web/` una vez dentro de la ruta ejecutamos el siguiente comando:

    dotnet run

Si todo está correctamente configurado y se ha seguido hasta este punto los pasos anteriores, el proyecto al ejecutar nos creará la base de datos en `MySQL` con el nombre `db_customer` y dentro del esquema la tabla para guardar registros `customer`, al finalizar el proceso y terminar de ejecutarse, podremos dirigirnos a nuestro navegador y consultar el `swagger` del API en la siguiente url [https://localhost:57679/swagger/index.html](https://localhost:57679/swagger/index.html), o podemos dirigirnos directamente a nuestros `endpoints` a través del siguiente url [https://localhost:57679/swagger/index.html#/Customer](https://localhost:57679/swagger/index.html#/Customer)

### Configuraciones opcionales

#### CORS

En caso de querer utilizar este API para consumirse a través de una interfaz externa o de manera remota, es necesario agregar la regla para nuestro `CORS` e indicarle cuales serían los `dominios`/`ip` que se estarán conectando, para ello editaremos el siguiente archivo `./src/API_CleanArchitecture.Web/Program.cs`:

```
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowLocalhost",
                    builder =>
                    {
                      builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
});
```

Y en los origenes podemos cambiar el `dominio`/`ip` o agregar más de ser necesarios. Esto es requerido realizarlo para consumir el servicio y es una capa de seguridad para el proyecto.

# APP

## Pasos a seguir

### Instalar Dependencias

    npm install

### Ejecutar el proyecto

    npm start

## Troubleshooting    

### Ruta (URL) al Backend

En caso de necesitar cambiar el url del endpoint del backend, se deberá de modificar en el archivo `.env` en la raíz del proyecto.
