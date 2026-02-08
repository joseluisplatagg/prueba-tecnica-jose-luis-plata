# Decisiones de Diseño

## 1. Estructura del Dominio
[¿Cómo modelaste las entidades? ¿Por qué?]
```bash
#  Para la parte de la lógica se aprovecho el espacio que existia del Middleware para evaluar Excepciones de domminio y
# validar dentro de la entidad algunas de las validaciones referentes a las reglas de negocio con ello las entidades permanecen
# sin saber que existe un Http o WebAPI

```

```mermaid
erDiagram
    PAQUETE ||--o{ PAQUETE_HISTORIAL : "has history"
    ESTADO ||--o{ PAQUETE : "defines status"
    ESTADO ||--o{ PAQUETE_HISTORIAL : "records status"
    RUTA ||--o{ PAQUETE : "assigned to"

    PAQUETE {
        Guid PaqueteId PK
        Guid EstadoId FK
        Guid RutaId FK
        decimal Costo
        decimal Alto
        decimal Ancho
        decimal Largo
        timestamp CreatedAt
        Guid CreatedBy
        timestamp UpdatedAt
        Guid UpdatedBy
    }

    ESTADO {
        Guid EstadoId PK
        string EstadoDescripcion
    }

    RUTA {
        Guid RutaId PK
        string Origen
        string Destino
        decimal Distancia
        decimal TiempoEstimado
        timestamp CreatedAt
        Guid CreatedBy
    }

    PAQUETE_HISTORIAL {
        Guid Id PK
        Guid PaqueteId FK
        Guid EstadoId FK
        timestamp CreatedAt
        string Observaciones
    } 
```


## 2. Ubicación de Reglas de Negocio  
[¿Dónde pusiste las validaciones y por qué?]
```bash
# Validaciones de Entrada - [Application - FLuentValidation] (apoyado de la IPipelineBehaivor para cada campo)
# Reglas de Estado e Invariantes [Domain - Entities] (validaciones internas con excepcionDomain)
# Validaciones de exitencia [Application - Handlers] (Orquestción de existencia de objetos en BD con UoW)
```

```mermaid
sequenceDiagram
    autonumber
    participant C as Cliente (API)
    participant P as Pipeline (FluentValidation)
    participant H as Handler (Application)
    participant E as Entidad (Domain)
    participant DB as Base de Datos

    Note over C, P: Capa 1: Validación de Entrada
    C->>P: Enviar Command/Query
    alt Datos Inválidos
        P-->>C: throw ValidationException (400)
    else Datos Correctos
        P->>H: Ejecutar Handle()
    end

    Note over H, DB: Capa 2: Orquestación y Existencia
    H->>DB: Consultar existencia (UoW)
    alt No Existe
        DB-->>H: null / empty
        H-->>C: return OperationResult.Failure (404)
    else Existe
        H->>E: Invocar Regla de Negocio
    end

    Note over E, E: Capa 3: Invariantes de Dominio
    alt Regla Violada (Estado ilegal)
        E-->>H: throw DomainException
        H-->>C: Catch & Map to API Response (400)
    else Regla Exitosa
        E->>E: Actualizar Estado Interno
        E-->>H: Retornar Éxito
    end

    H->>DB: UnitOfWork.CompleteAsync()
    DB-->>H: Commit OK
    H-->>C: return OperationResult.Success (200)
```


## 3. Patrones Utilizados
[¿Qué patrones aplicaste? ¿Cuál fue tu razonamiento?]
```bash
#  1. Repository .- Estructura las operaciones genericas para CRUD de catálogs adenmas de crear una estructura que prepara el UoW

#  2. CQRS .- Separación de las operaciones de lectura y escritura

#  3. Mediator .- Desacopla los controladores de la lógica de negocio ( sustituye a la capa se servicios)

#  4. UnitOfWork .- Permite la atomicidad para mantener varias operaciones en la BD simulando incluso COMMITS, ROLLBACKS

#  4. Result Patter .- Estructura el flujo normal del programa para la estenderización entre la capa de aplicación y de presentación

```


```mermaid
graph TD
    %% Capa de Presentación
    CTRL[API Controller]

    %% Patrón Mediator
    subgraph "Patrón Mediator (MediatR)"
        CTRL -->|1. Envía Request| MED[Mediator]
        MED -->|2. Despacha al| HAND[Handler específico]
        style MED fill:#f9f,stroke:#333,stroke-width:2px
    end

    %% Patrón CQRS
    subgraph "Patrón CQRS"
        HAND -->|Escritura| CMD[Command Handler]
        HAND -->|Lectura| QRY[Query Handler]
        style HAND fill:#bbf,stroke:#333
    end

    %% Patrón Unit of Work & Repository
    subgraph "Persistencia (UoW & Repository)"
        CMD -->|3. Coordina| UOW[Unit of Work]
        UOW -->|4. Provee| REPO[Repository Genérico / Específico]
        REPO -->|5. Operaciones CRUD| DB[(PostgreSQL)]
        UOW -->|6. Commit / Rollback| DB
        style UOW fill:#dfd,stroke:#333,stroke-width:2px
    end

    %% Patrón Result Pattern
    subgraph "Patrón Result (OperationResult)"
        QRY -.->|7. Envuelve| RES[Result Pattern]
        CMD -.->|7. Envuelve| RES
        RES -.->|8. Respuesta Estandarizada| CTRL
        style RES fill:#fff4dd,stroke:#d4a017,stroke-width:2px
    end

    %% Notas Técnicas
    classDef note font-style:italic,font-size:10px;
    N1[Sustituye Capa de Servicios] -.-> MED
    N2[Atomicidad de Operaciones] -.-> UOW
    N3[Estandariza Flujo App-API] -.-> RES
```



## 4. Trade-offs y Limitaciones
[¿Qué dejaste fuera por tiempo? ¿Cómo lo resolverías?]
```bash
#  1. Pruebas .- Termine la estrucutra, arquitectura, diseño y programación pero no realice pruebas funcionales con Postman o alguna herramienta que realice 
# peticiones a mi servicio backend.

# 2. Validar todas las pruebas unitarias .- Aunque de las pruebas que agregue pasaron la mayoria hubo algunas que me hubiera gustado terminar con apoyo de las
# herramientas de debug para las pruebas

# 3. Hubo algunas operaciones LINQ que no termine de implementar

# 4. UI .- Aunque no venía en la parte del requrimiento agregar una pequeña interfaz que apoye el registro, actualización y visualizción de paquetes con apoyo
# de una libreria como React para que el desarrollo se mas ágil y podamos interactuar visualmente con los recursos del api.

```

## 5. Supuestos
[¿Qué asumiste que no estaba explícito en los requerimientos?]
```bash
# A nivel programación el proyecto contaba con todo lo necesario para realizar la implementación sin embargo las estructuras para aplicar el CQRS no se veían
# pero se podia intuir que con las librerias y patrones aplicados ese era el camino que había que tomar

# En lo que respecta a la cadena de conexión que se comparte entre Docker y el modo Development local, se tiene que utilizar variables de entorno dentro
# del compose para al api backend

# Se define que el uso y dinamica con la BD será code first ya que se necesitaron crear primero las entidades y configurar el DbContext.cs

```