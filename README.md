
# Documentación del Proyecto RealEstate

Este proyecto es una solución modular desarrollada con .NET Core, siguiendo los principios de la Arquitectura Limpia para la gestión de propiedades inmobiliarias. La documentación a continuación cubre la configuración inicial, la estructura del proyecto, las tecnologías utilizadas y las consideraciones relevantes para su implementación.

---

## 🧭 Instrucciones de Configuración Inicial

1. **Clonar el repositorio**:
   Ejecuta el siguiente comando en la consola para clonar el repositorio:

```bash
git clone [https://github.com/usuario/RealEstate.git](https://github.com/AndrewBabativa/RealEstate.git)
```

2. **Abrir el proyecto en Visual Studio**:

   - Abre el archivo `RealEstate.sln` en Visual Studio.
   - Restaura los paquetes NuGet si es necesario.

3. **Verificar puertos de ejecución**:

   - La API se ejecuta por defecto en los puertos 5000 y 5001 (HTTP/HTTPS). Verifica en el archivo `appsettings.json` si estos puertos están disponibles o cambia los valores si es necesario.
   
4. **Ejecutar el script de base de datos ó restaurar Backup de BD**:

   - Ejecutar el script de base de datos
      - Se incluye un script SQL para crear la base de datos `RealEstate\RealEstate.API\Settings\Database\Sc_RealEstateDB.sql` junto con las tablas necesarias.
      - Ejecuta este script en SQL Server Management Studio o cualquier herramienta equivalente.
    
   - Restaurar Backup de BD
      - Restaurar este backup en SQL Server Management Studio incluido en `RealEstate\RealEstate.API\Settings\Database\RealEstate_DB.sql`.
     
5. **Configurar la cadena de conexión**:

   Modifica el archivo `appsettings.json` dentro del proyecto `RealEstate.API` para incluir tu cadena de conexión local a la base de datos:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=RealEstateDB;Trusted_Connection=True;"
}
```

6. **Importar la colección de Postman**:

   - Abre Postman, haz clic en *Importar* y selecciona el archivo `RealEstate\RealEstate.API\Settings\Postman\RealEstate.postman_collection.json`.
   - Asegúrate de importar los endpoints definidos en la colección para realizar las pruebas de la API.

---

## 📁 Estructura del Proyecto

```text
RealEstate
│
├── RealEstate.sln
│
├── RealEstate.Core
│   ├── RealEstate.Core.csproj
│   └── Contracts
│       ├── IOwnerRepository.cs
│       ├── IPropertyRepository.cs
│       ├── IPropertyImageRepository.cs
│       └── IPropertyTraceRepository.cs
│   └── Domain
│       └── Entity
│           ├── OwnerEntity.cs
│           ├── PropertyEntity.cs
│           ├── PropertyImageEntity.cs
│           └── PropertyTraceEntity.cs
│   └── ValueObjects
│           └── AuthCredentials.cs
│
├── RealEstate.Application
│   ├── RealEstate.Application.csproj
│   ├── Mappings
│   │   └── MappingProfile.cs
│   └── UseCases
│       ├── Auth
│       │   ├── LoginHandler.cs
│       │   └── RegisterHandler.cs
│       ├── Owner
│       │   └── CreateOwnerHandler.cs
│       ├── Property
│       │   ├── CreatePropertyHandler.cs
│       │   ├── UpdatePropertyHandler.cs
│       │   ├── ChangePropertyPriceHandler.cs
│       │   └── ListPropertiesHandler.cs
│       ├── PropertyImage
│       │   └── AddImageToPropertyHandler.cs
│       └── PropertyTrace
│           └── CreatePropertyTraceHandler.cs
│   └── Validators
│       ├── Owner
│       │   └── CreateOwnerRequestValidator.cs
│       ├── Property
│       │   ├── AddImageRequestValidator.cs
│       │   ├── ChangePriceRequestValidator.cs
│       │   ├── CreatePropertyRequestValidator.cs
│       │   └── UpdatePropertyRequestValidator.cs
│       ├── Users
│       │   └── LoginAuthRequestValidator.cs
│       │   └── RegisterAuthRequestValidator.cs
│
├── RealEstate.Common
│   ├── RealEstate.Common.csproj
│   └── Contracts
│       ├── Owner
│       │   ├── Requests
│       │   │   └── CreateOwnerRequest.cs
│       │   └── Responses
│       │       └── OwnerResponse.cs
│       ├── Property
│       │   ├── Requests
│       │   │   ├── CreatePropertyRequest.cs
│       │   │   ├── UpdatePropertyRequest.cs
│       │   │   └── ChangePriceRequest.cs
│       │   ├── Responses
│       │   │   └── PropertyResponse.cs
│       │   └── Filters
│       │       └── PropertyFilter.cs
│       ├── PropertyImage
│       │   ├── Requests
│       │   │   └── AddImageRequest.cs
│       │   └── Responses
│       │       └── PropertyImageResponse.cs
│       └── PropertyTrace
│           ├── Requests
│           │   └── CreatePropertyTraceRequest.cs
│           └── Responses
│               └── PropertyTraceResponse.cs
│
├── RealEstate.Infrastructure
│   ├── RealEstate.Infrastructure.csproj
│   ├── Persistence
│   │   └── RealEstateDbContext.cs
│   ├── Migrations
│   ├── Repositories
│   │   ├── OwnerRepository.cs
│   │   ├── PropertyRepository.cs
│   │   ├── PropertyImageRepository.cs
│   │   └── PropertyTraceRepository.cs
│   └── Services
│       ├── AuthService.cs
│       └── CloudinaryService.cs
│
├── RealEstate.API
│   ├── RealEstate.API.csproj
│   ├── Program.cs
│   ├── Startup.cs
│   ├── Controllers
│   │   ├── AuthController.cs
│   │   ├── OwnerController.cs
│   │   ├── PropertyController.cs
│   │   ├── PropertyImageController.cs
│   │   └── PropertyTraceController.cs
│   ├── Middlewares
│   │   └── ExceptionMiddleware.cs
│   └── Security
│       └── JwtSettings.cs
│
├── RealEstate.Tests
│   ├── RealEstate.Tests.csproj
│   ├── CreatePropertyHandlerTests.cs
│   └── UpdatePropertyHandlerTests.cs
```
# Validación de la Arquitectura con NDepend

Esta sección explica cómo utilizamos **NDepend** para analizar y asegurar que la arquitectura de la aplicación siga las mejores prácticas y principios de diseño. Las siguientes capturas de **NDepend** demuestran la calidad y estructura del código.

## 1. Gráfico de Dependencias

![image](https://github.com/user-attachments/assets/82223a9d-d8fc-4efc-b5d1-0cdd51b4a510)


El **Gráfico de Dependencias** muestra las relaciones entre los diferentes módulos o capas del sistema. Esto ayuda a asegurar que la arquitectura siga una correcta separación de responsabilidades y que no existan dependencias no deseadas entre las capas (por ejemplo, que la lógica de negocio dependa directamente de las capas de acceso a datos).

## 2. Matriz de Dependencias

![image](https://github.com/user-attachments/assets/4ac8774e-6b05-45b9-a0ef-17a66da0be6f)

La **Matriz de Dependencias** muestra una matriz de dependencias entre los módulos, destacando qué módulos dependen de cuáles otros. Esta herramienta es útil para visualizar y prevenir dependencias circulares, asegurando que el sistema se mantenga modular y fácil de mantener.

## 3. Métricas de NDepend

![image](https://github.com/user-attachments/assets/d4c79f94-4c43-450f-b266-ba342de3edb3)


Las **Métricas de NDepend** proporcionan estadísticas detalladas sobre la calidad del código, como la complejidad ciclomática, la cobertura del código y la mantenibilidad. Esto nos permite monitorear la salud del proyecto e identificar áreas que pueden requerir refactorización o atención adicional.

---

## 🔗 Esquema de Relaciones de Base de Datos

```text
Users

Owners
└──< Properties
     ├──< PropertyImages
     └──< PropertyTrace
```

---

## ⚙️ Tecnologías y Aplicación Técnica

En el desarrollo del sistema **RealEstate**, se aplicaron múltiples tecnologías enfocadas en mantener una arquitectura robusta, escalable y segura. A continuación se detallan las principales herramientas y conceptos aplicados:

- **🔄 AutoMapper**  
  Utilizado para mapear objetos entre entidades de dominio y DTOs de forma automática. Esto reduce el código repetitivo y centraliza la lógica de transformación en `MappingProfile.cs`, lo cual mejora el mantenimiento y consistencia entre capas.

- **🔐 JWT Authentication (JSON Web Tokens)**  
  El sistema implementa autenticación basada en tokens JWT para proteger los endpoints de la API.  
  - La configuración del token se define en `JwtSettings.cs`.  
  - La lógica de generación, validación y extracción de claims se maneja en `AuthService.cs`.  
  Esto permite mantener la sesión sin almacenar información sensible en el servidor.

- **🧱 Arquitectura Limpia (Clean Architecture)**  
  Se adoptó una estructura en capas (Domain, Application, Infrastructure, API), lo cual permite:  
  - Separar las reglas del negocio de la lógica de infraestructura.  
  - Facilitar pruebas unitarias.  
  - Reducir el acoplamiento y mejorar la escalabilidad del proyecto.

- **🌐 Entity Framework Core (EF Core)**  
  Se implementaron repositorios por entidad para encapsular el acceso a la base de datos utilizando `DbContext`.  
  Aunque no se aplicó Unit of Work explícitamente, se mantuvo una buena separación de responsabilidades y acceso controlado a través de interfaces.  
  Las operaciones de persistencia están contenidas dentro de los métodos del repositorio, manteniendo el enfoque transaccional en cada operación específica.

- **☁️ Cloudinary**  
  Integración con el servicio Cloudinary para el almacenamiento y gestión de imágenes en la nube.  
  - Implementado en `CloudinaryService.cs`.  
  - Permite subir imágenes, obtener sus URLs y eliminarlas fácilmente.  
  - Mejora el rendimiento del backend al delegar el almacenamiento de archivos.

- **🛠️ Middlewares Personalizados**  
  Se desarrolló un middleware global para manejo centralizado de excepciones (`ExceptionMiddleware.cs`).  
  - Captura y formatea errores de forma uniforme.  
  - Protege al sistema de errores no controlados y mejora la experiencia del cliente.

- **📦 Inyección de Dependencias (DI)**  
  Toda la configuración de servicios y repositorios está gestionada desde `Program.cs`, siguiendo los principios de SOLID, en especial la inversión de dependencias.

 - **🧩 Capa `RealEstate.Common` (Transversal de Contratos)**
   
   La solución cuenta con una capa transversal denominada `RealEstate.Common`, cuyo objetivo principal es **centralizar los contratos de comunicación (DTOs)** que fluyen entre las capas del sistema, especialmente entre el frontend, la 
   API y la lógica de dominio.
   
   Esta capa está organizada por **módulos funcionales** (`Owner`, `Property`, `PropertyImage`, `PropertyTrace`) y contiene:
   
   - `Requests/`: Definen la estructura de los datos que se reciben en los endpoints (por ejemplo, `CreatePropertyRequest`, `ChangePriceRequest`).
   - `Responses/`: Estandarizan las respuestas que expone la API, separando las entidades de dominio del modelo expuesto públicamente.
   - `Filters/`: Permiten aplicar filtros de forma tipada y clara en consultas (ej. `PropertyFilter` para búsquedas dinámicas).
   -  Ventajas:
      - **Reutilización y mantenibilidad**: Al tener los contratos centralizados, se evita la duplicación y facilita su reutilización tanto en pruebas como en integraciones externas.
      - **Separación de preocupaciones**: La lógica de negocio no depende de cómo se estructura la petición o respuesta en la API, manteniendo el dominio limpio.
      - **Escalabilidad**: Al crecer el sistema, esta capa permite escalar funcionalidades y endpoints sin afectar las capas internas.
      - **Claridad en la evolución del modelo**: Cualquier cambio en los contratos se concentra en un solo lugar, haciendo que las revisiones y ajustes sean más controlados.
      - **Compatibilidad con herramientas de documentación (como Swagger)**: Ayuda a generar documentación clara y basada en modelos definidos, mejorando la comunicación entre equipos.
      - 
- **✅ FluentValidation**  
  Se implementó la biblioteca **FluentValidation** para la validación de los objetos de solicitud en el sistema, lo que permite definir reglas de validación de manera fluida y centralizada.  
  - Se definen validadores para cada tipo de solicitud, como `CreatePropertyRequestValidator` o `ChangePriceRequestValidator`, donde se especifican reglas como **campo obligatorio**, **longitud máxima**, y **valores mínimos y máximos**. 
  - Los validadores están organizados en clases específicas dentro de la carpeta `Validators`, lo que facilita la reutilización y el mantenimiento de las reglas de validación.  
  - La validación se ejecuta de forma automática antes de realizar las operaciones en el sistema, asegurando que las solicitudes sean consistentes y seguras.

- **🧪 Pruebas Unitarias (NUnit)**  
  Se implementaron pruebas unitarias para los casos de uso más críticos, usando `NUnit` y `Moq` para simular dependencias y verificar comportamientos esperados.

- **📁 Swagger/OpenAPI**  
  Documentación de endpoints generada automáticamente usando Swagger.  
  - Permite probar directamente desde el navegador.  
  - Mejora la comunicación con frontend y QA.

- **📦 Scripts SQL y Postman**  
  Se incluyó un archivo `.sql` para la creación inicial de la base de datos y un archivo `.json` de Postman para probar todos los endpoints del sistema de manera automatizada y estandarizada.

---

## 🧪 Pruebas Manuales

### Requisitos previos:

1. **Asegúrate de que el proyecto esté corriendo en tu entorno local** y la base de datos esté configurada correctamente.
2. **Importa la colección de Postman** para probar los endpoints disponibles, el archivo esta dentro de la soluciòn en RealEstate\Postman\RealEstate.postman_collection.json.

### Procedimiento de prueba:

# Real Estate API - Documentación

## 🔐 1. Registro de Usuario

**POST** `https://localhost:7185/api/auth/register`

**Headers:**

```http
Content-Type: application/json
```

**Body:**

```json
{
  "username": "AndrewBg",
  "password": "12345"
}
```

**Response si el usuario ya existe:**

```json
{
  "message": "User already exists"
}
```

**Response si fue creado correctamente:**

```json
{
  "message": "User registered successfully"
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/3fd41b5b-d33d-4560-8585-8681a8dd3a92)

---

## 🔐 2. Login de Usuario

**POST** `https://localhost:7185/api/auth/login`

**Headers:**

```http
Content-Type: application/json
```

**Body:**

```json
{
  "username": "AndrewBg",
  "password": "12345"
}
```

**Response si las credenciales son correctas:**

```json
{
  "username": "AndrewBg",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

**Response si las credenciales son incorrectas:**

```json
{
  "message": "Invalid credentials"
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/ddfaa927-c900-4385-9556-ce4cb113ae73)
![image](https://github.com/user-attachments/assets/46a262de-1162-4a94-ba88-84de93a77d6e)

****El token de autenticación se genera y almacena en la variable global authToken, la cual se utiliza en los headers de todos los servicios para autorizar las solicitudes.****

---

## 🖼️ 3.1. Crear Owner

**POST** `https://localhost:7185/api/owners`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: multipart/form-data
```

**Body (form-data):**

* `photo`: archivo tipo *file*
* `name`: valor tipo *text*, ejemplo: `Yenny Jimenez`
* `address`: valor tipo *text*, ejemplo: `Calle 123 #45-67`
* `birthday`: valor tipo *date*, ejemplo: `1990-05-10T00:00:00`
* `photo`: archivo tipo *file*

**Response:**

```json
{
    "ownerId": 1,
    "name": "Yenny Jimenez",
    "address": "Calle 123 #45-67",
    "photo": "https://res.cloudinary.com/dxpt8odsh/image/upload/v1746470784/njjytdihgarkr0j1ybho.jpg",
    "birthday": "1990-05-10T00:00:00"
}
```
**Evidencia:**
![image](https://github.com/user-attachments/assets/20172b1c-e1d4-465e-b03f-52cdd11810fe)

![image](https://github.com/user-attachments/assets/0d143dd5-01e8-41e9-aa6a-554c9f343841)

![image](https://github.com/user-attachments/assets/1745a09b-fb82-4aa7-9721-27151094a75f)



---

## 🏡 3. Obtener propiedades con filtros (query params)

**GET** `https://localhost:7185/api/property?year=2022&minPrice=1000000&maxPrice=6000000&name=Modern`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: application/json
```

**Response:**

```json
[
  {
    "propertyId": 9,
    "name": "Modern House Renovated",
    "address": "456 Ocean View Ave",
    "price": 5000000.00,
    "codeInternal": "INT-2025-001",
    "year": 2022,
    "ownerId": 1,
    "owner": {
      "ownerId": 1,
      "name": "Andres BG",
      "address": "Medellin CO",
      "photo": "profile.jpg",
      "birthday": "1991-09-28T00:00:00"
    },
    "images": [
      {
        "propertyImageId": 6,
        "url": "https://res.cloudinary.com/...png",
        "enabled": true
      },
      {
        "propertyImageId": 7,
        "url": "https://res.cloudinary.com/...png",
        "enabled": true
      }
    ]
  }
]
```

**Response si el `propertyId` no existe:**

```json
{
  "type": "https://httpstatuses.com/400",
  "title": "Bad Request - Invalid Argument",
  "status": 400,
  "detail": "Property with ID 4 not found.",
  "instance": {
    "Value": "/api/Property",
    "HasValue": true
  },
  "timestamp": "2025-05-05T16:32:52.8855799Z"
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/550f1cfb-1734-4d1a-80ab-99ebeb7212cd)


---

## 🏗️ 4. Crear propiedad

**POST** `https://localhost:7185/api/Property`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: application/json
```

**Body:**

```json
{
  "name": "Casa en la playa",
  "address": "Calle 123, Miami Beach",
  "codeInternal": "INT-2025-001",
  "price": 1500000,
  "year": 2021,
  "ownerId": 1
}
```

**Response:**

```json
{
  "propertyId": 15,
  "name": "Casa en la playa",
  "address": "Calle 123, Miami Beach",
  "price": 1500000,
  "codeInternal": "INT-2025-001",
  "year": 2021,
  "ownerId": 1,
  "owner": {
    "ownerId": 1,
    "name": "Andres BG",
    "address": "Medellin CO",
    "photo": "profile.jpg",
    "birthday": "1991-09-28T00:00:00"
  },
  "images": []
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/eea4ea65-894c-4466-8dbe-87e8c6b82c6a)

---

## 🖼️ 5. Subir imagen de propiedad

**POST** `https://localhost:7185/api/propertyimage/upload`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: multipart/form-data
```

**Body (form-data):**

* `image`: archivo tipo *file*
* `PropertyId`: valor tipo *text*, ejemplo: `15`

**Response:**

```json
{
  "message": "Image uploaded and property updated successfully."
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/56819ff6-3893-437b-86df-7fb4657fdf33)

![image](https://github.com/user-attachments/assets/b17905ee-e503-40d2-9b09-745b0d5dcbc3)

![image](https://github.com/user-attachments/assets/b216bea5-0eb6-4d29-9cbf-cdbbb65aec0a)


---

## 💰 6. Actualizar precio de propiedad

**PUT** `https://localhost:7185/api/Property`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: application/json
```

**Body:**

```json
{
  "PropertyId": 10,
  "NewPrice": 1000000
}
```

**Response:**

```json
{
  "propertyId": 10,
  "name": "Casa en la playa",
  "address": "Calle 123, Miami Beach",
  "price": 1000000,
  "codeInternal": "INT-2025-001",
  "year": 2021,
  "ownerId": 1,
  "owner": {
    "ownerId": 1,
    "name": "Andres BG",
    "address": "Medellin CO",
    "photo": "profile.jpg",
    "birthday": "1991-09-28T00:00:00"
  },
  "images": [
    {
      "propertyImageId": 8,
      "url": "https://cdn.ejemplo.com/images/casa1.jpg",
      "enabled": true
    },
    {
      "propertyImageId": 9,
      "url": "https://cdn.ejemplo.com/images/casa2.jpg",
      "enabled": true
    }
  ]
}
```

**Evidencia:**

![image](https://github.com/user-attachments/assets/992c2909-4e3e-4aae-8673-9d052d613933)

---

## 🛠️ 7. Actualizar datos de propiedad (excepto precio)

**PUT** `https://localhost:7185/api/Property`

**Headers:**

```http
Authorization: Bearer {{authToken}}
Content-Type: application/json
```

**Body:**

```json
{
  "propertyId": 9,
  "name": "Modern House Renovated",
  "address": "456 Ocean View Ave",
  "codeInternal": "00-1",
  "year": 2022
}
```

**Response:**

```json
{
  "propertyId": 11,
  "name": "Modern House Renovated",
  "address": "456 Ocean View Ave",
  "price": 1500000.00,
  "codeInternal": "INT-2025-001",
  "year": 2022,
  "ownerId": 1,
  "owner": {
    "ownerId": 1,
    "name": "Andres BG",
    "address": "Medellin CO",
    "photo": "profile.jpg",
    "birthday": "1991-09-28T00:00:00"
  },
  "images": []
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/078b953f-7d2b-43fc-8221-21dc6f3bb367)

---

## ❌ 8. Simulación de error desde el middleware

**GET** `https://localhost:7185/api/test/error`

**Headers:**

```http
Authorization: Bearer {{authToken}}
```

**Response:**

```json
{
  "type": "https://httpstatuses.com/500",
  "title": "Internal Server Error",
  "status": 500,
  "detail": "Simulated exception from TestController",
  "instance": {
    "Value": "/api/test/error",
    "HasValue": true
  },
  "timestamp": "2025-05-05T16:33:54.6111461Z"
}
```
**Evidencia:**

![image](https://github.com/user-attachments/assets/6daa4940-3a70-4b24-ab86-8b66e82dd1f9)


---


## Pruebas Unitarias

### `CreatePropertyHandlerTests`

Estas pruebas están orientadas a verificar el comportamiento del `CreatePropertyHandler`, el cual se encarga de la creación de propiedades. A continuación, se detallan las pruebas realizadas:

1. **Handle_ShouldCreateProperty_WhenRequestIsValid**
   - **Objetivo**: Verificar que el handler cree correctamente una propiedad cuando se proporciona una solicitud válida.
   - **Comportamiento esperado**: Se espera que el método `Handle` cree una nueva propiedad y la almacene en el repositorio. La propiedad creada se debe devolver como respuesta.
   - **Pruebas principales**:
     - El nombre, la dirección y otros detalles de la propiedad deben coincidir con los de la solicitud.
     - Se verifica que el método `AddAsync` del repositorio de propiedades haya sido llamado exactamente una vez.
   
   ```csharp
   [Test]
   public async Task Handle_ShouldCreateProperty_WhenRequestIsValid()
   {
       // Arrange
       var request = new CreatePropertyRequest { ... };
       var owner = new OwnerEntity { ... };
       var property = new PropertyEntity { ... };
       var propertyResponse = new PropertyResponse { ... };
       
       // Configuración de mocks
       _ownerRepoMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(owner);
       _mapperMock.Setup(m => m.Map<PropertyEntity>(request)).Returns(property);
       _mapperMock.Setup(m => m.Map<PropertyResponse>(It.IsAny<PropertyEntity>())).Returns(propertyResponse);
       
       // Act
       var result = await _handler.Handle(request, CancellationToken.None);

       // Assert
       Assert.AreEqual("Casa Linda", result.Name);
       Assert.AreEqual("Calle 123", result.Address);
       _propertyRepoMock.Verify(x => x.AddAsync(It.IsAny<PropertyEntity>()), Times.Once);
   }
   ```

2. **Handle_ShouldThrow_WhenOwnerDoesNotExist**
   - **Objetivo**: Verificar que el handler lance una excepción cuando el propietario no existe.
   - **Comportamiento esperado**: Si el propietario no se encuentra, se espera que se lance una `KeyNotFoundException` con un mensaje que indique que el propietario no fue encontrado.
   
   ```csharp
   [Test]
   public void Handle_ShouldThrow_WhenOwnerDoesNotExist()
   {
       // Arrange
       var request = new CreatePropertyRequest { ... };
       _ownerRepoMock.Setup(x => x.GetByIdAsync(999)).ReturnsAsync((OwnerEntity)null);
       
       // Act & Assert
       var ex = Assert.ThrowsAsync<KeyNotFoundException>(() =>
           _handler.Handle(request, CancellationToken.None));

       Assert.That(ex.Message, Does.Contain("Owner with ID 999 not found"));
   }
   ```

### `UpdatePropertyHandlerTests`

Las siguientes pruebas están diseñadas para verificar el comportamiento del `UpdatePropertyHandler`, que se encarga de actualizar una propiedad existente. A continuación, se describen las pruebas implementadas:

1. **Handle_ShouldUpdateProperty_WhenPropertyExists**
   - **Objetivo**: Verificar que el handler actualice correctamente una propiedad cuando esta ya existe en el sistema.
   - **Comportamiento esperado**: Se espera que el método `Handle` actualice la propiedad existente y la devuelva con los nuevos valores.
   - **Pruebas principales**:
     - El nombre, la dirección y otros detalles de la propiedad actualizada deben coincidir con los de la solicitud.
     - Se verifica que el método `UpdateAsync` del repositorio de propiedades haya sido llamado exactamente una vez.
   
   ```csharp
   [Test]
   public async Task Handle_ShouldUpdateProperty_WhenPropertyExists()
   {
       // Arrange
       var request = new UpdatePropertyRequest { ... };
       var existingProperty = new PropertyEntity { ... };
       var updatedResponse = new PropertyResponse { ... };
       
       // Configuración de mocks
       _propertyRepoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(existingProperty);
       _mapperMock.Setup(m => m.Map<PropertyResponse>(It.IsAny<PropertyEntity>())).Returns(updatedResponse);

       // Act
       var result = await _handler.Handle(request, CancellationToken.None);

       // Assert
       Assert.AreEqual("Casa Actualizada", result.Name);
       Assert.AreEqual("Nueva Dirección", result.Address);
       Assert.AreEqual(2021, result.Year);
       _propertyRepoMock.Verify(r => r.UpdateAsync(existingProperty), Times.Once);
   }
   ```

2. **Handle_ShouldThrow_WhenPropertyDoesNotExist**
   - **Objetivo**: Verificar que el handler lance una excepción cuando la propiedad que se intenta actualizar no existe.
   - **Comportamiento esperado**: Si la propiedad no se encuentra, se espera que se lance una `ArgumentException` con un mensaje que indique que la propiedad no fue encontrada.
   
   ```csharp
   [Test]
   public void Handle_ShouldThrow_WhenPropertyDoesNotExist()
   {
       // Arrange
       var request = new UpdatePropertyRequest { PropertyId = 99 };
       _propertyRepoMock.Setup(r => r.GetByIdAsync(99)).ReturnsAsync((PropertyEntity)null);

       // Act & Assert
       var ex = Assert.ThrowsAsync<ArgumentException>(() =>
           _handler.Handle(request, CancellationToken.None));

       Assert.That(ex.Message, Does.Contain("Property with ID 99 not found"));
   }
   ```

 **Evidecia de las pruebas ejecutadas:**

****![image](https://github.com/user-attachments/assets/bb532f0d-44f7-4935-86cf-4e9345fb5201)




