# Aplicación .NET con demostración de herramientas genéricas

[_En progreso_] Bienvenidos a este repositorio personal. 👋🏻 </br>
A medida que se avance en el código y se agreguen funcionalidades finalizadas se irá agregando contenido en este README.

Ir al [sitio MemitoSoftware](https://www.memitosoftware.com) para ver lo último publicado.

---

## Tabla de Contenidos

- [Aplicación .NET con demostración de herramientas genéricas](#aplicación-net-con-demostración-de-herramientas-genéricas)
  - [Tabla de Contenidos](#tabla-de-contenidos)
    - [1 - Estado actual de la acción](#1---estado-actual-de-la-acción)
    - [2 - Introducción](#2---introducción)
    - [3 - Proyectos](#3---proyectos)
    - [4 - NuGets en uso](#4---nugets-en-uso)
    - [5 - Acciones](#5---acciones)
    - [6 - Licencia](#6---licencia)
    - [7 - Agradecimientos](#7---agradecimientos)

---

### 1 - Estado actual de la acción

| Workflow         | Estado                                                                 |
|------------------|------------------------------------------------------------------------|
| .NET Core Desktop | [![.NET Core Desktop](https://github.com/ramiroagm/WinFormTester/actions/workflows/dotnet-desktop.yml/badge.svg?branch=master)](https://github.com/ramiroagm/WinFormTester/actions/workflows/dotnet-desktop.yml)

### 2 - Introducción

Este proyecto está creado a modo de prueba para demostrar algunas funcionalidades y generar un repositorio genérico con herramientas en funcionamiento. </br>
El mismo estará publicado en un servidor de Google Clouds bajo una URL que próximanete se proveerá. </br>
Para más información: visitar la página en cuestión que contará con información al respecto para cada herramienta.

### 3 - Proyectos

A continuación veremos un listado de proyectos agregados a la solución e información básica de los mismos: </br>

- #### 3.1 - TestPro

  Proyecto de testeo unitario.

- #### 3.2 - TesterApi
  
  Proyecto API que genera un llamado a la librería general de esta solución para consultas genéricas parametrizadas.

- #### 3.3 - TesterBlazor

  Pantalla web en Blazor Server que conecta y testea varios de los servicios generados en la librería principal. </br>
  Contiene un menú básico para navegar entre las páginas relacionadas al proyecto, con algunos elementos de Bootstrap utilizados a modo de ejemplo (popovers, modales, etc...). </br>
  Por más información: en cada página se encontrarán ejemplos escritos, como instrucciones y otro tipo de información al respecto de cada herramienta.
  
- #### 3.4 - TesterDatabase

  Proyecto de SQL Server Database. </br>
  En este proyecto se podrá ver el tipo de estructura que se suele manejar (de forma simplificada) a la hora de generar scripts .sql. Para ejecutar local simplemente darle build al proyecto y luego publicar. Cabe destacar que se necesita SQL Server instalado. Recordar también que se generarán datos de prueba, y que no necesariamente la estructura de la base de datos estará 100% completa. </br>
  De preferir hacer pruebas con una base de datos local, recordar hacer modificaciones en el "connection string" de la aplicación, ya que es muy probable que la misma esté consumiendo uno desde una instancia de Google Clouds o Azure.

- #### 3.5 - WinFormTester
  
  Formulario de Windows básico, funcionalmente completo que demostrará acciones básicas de las librerías de forma rápida y re-programable. La intención de esta aplicación no es más que a modo de prueba.

- #### 3.6 - TesterWorkerService
  
  Servicio de Windows de prueba que se encargará de ejecutar código automatizado y aplicar distintas formas de Log (texto, visor de eventos, consola, etc...). Principalmente, este servicio se utilizará para ejecuciones del bot de Telegram, aunque, no se descata que se utilice para otros tipos de servicios (más para actualizar a futuro).

- #### 3.7 - TesterProject
  
  Core y librería principal. Esta librería .NET es la que contiene todo el código principal para cada herramienta y proyecto que se utilizará en este repositorio a modo de prueba. Chequear la librería entera para ver ejemplos y código comentado.

  Código que actualmente se encuentra presente: </br>
  - Testeo de delegados
  - Testeo de inyección de dependencia
  - Conector de Instagram (con NuGet)
    - Crear conexión
    - Enviar mensajes
    - Recibir mensajes
  - Manejo de contraseñas y keys
    - KeyVault de Azure
    - SecretManager de Google
    - Cryptography
  - Conector de Telegram (BOT (Con NuGet))
    - Conexión con BOT (generado con BotFather)
    - Guardado de información en base de datos
    - Estructura para mensajes "Inline"
    - Recibir mensajes (texto, fotos)
    - Enviar mensajes
  - Acceso general a base de datos SQL Server
    - Ejecuciones de procedimientos almacenados
    - Insert de datos

### 4 - NuGets en uso

A continuación estaré explicando las librerías se utilizan en esta solución y el objetivo de las mismas: </br>

- Azure.Security.KeyVault.Secrets - Se obtiene información del KeyVault.
- Google.Cloud.SecretManager.V1 - Se obtiene información del SecretManager
- [InstagramApiSharp](https://www.nuget.org/packages/InstagramApiSharp/1.8.0?_src=template) - Conexión con Instagram (Atención: utilizar esta API a su propio riesgo al igual que la herramienta dentro de esta aplicación)
- Serilog - Generación de Logs (todos los posibles)
- [Telegram.Bot](https://www.nuget.org/packages/Telegram.Bot/22.4.4?_src=template) - NuGet que facilita la conexión con los Bots de telegram. Ver la documentación pertinente. Utilizar el bot creado en esta aplicación a modo de prueba.

### 5 - Acciones

La acción en _master_ está preparada para publicar todo el código en una VM de Windows, creada en Google Cloud. Esta acción compilará todos los proyectos de interés a publicación (librería, api, web, servicio). Utilizando una conexión por usuario y contraseña de Windows y Powershell se transfieren los archivos al servidor a carpetas específicas, mientras que en el servidor se configuró IIS y el servicio, para automáticamente estar recibiendo archivos a demanda desde cada push a _master_ y actualizando servicio. Ver el documento de la acción para tener más información.

### 6 - Licencia

No hay una licencia pertinente actualmente, y se podrá utilizar el código y apropiarse del mismo.

### 7 - Agradecimientos

Listado de usuarios que me ayudaron con el desarrollo de esta prueba:

- [@eliana-viera](https://github.com/eliana-viera)