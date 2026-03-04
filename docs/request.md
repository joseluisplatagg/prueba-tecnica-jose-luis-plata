# 📦 API de Gestión de Paquetes - Guía de Referencia cURL

Esta guía contiene los comandos necesarios para probar los endpoints de la API de paquetes.

## 🔧 Configuración Base
- **URL Base:** `http://localhost:8080/api/v1`
- **Content-Type:** `application/json`

---

## 1. Paquetes (Packages)

🟢 1. LISTAR TODOS LOS PAQUETES (GET)
Recupera la colección completa. Admite filtros opcionales en la URL.
Comando:
curl -X GET "http://localhost:8080/api/v1/packages" -H "accept: application/json"
Con Filtros (Estado y Fechas) (*PENDIENTE*):
curl -X GET "http://localhost:8080/api/v1/packages?estadoId=GUID&fechaInicio=2024-01-01" -H "accept: application/json"

🔵 2. OBTENER DETALLE POR ID (GET)
Busca un paquete específico y devuelve su información y costo calculado.
Comando:
curl -X GET "http://localhost:8080/api/v1/packages/CAMBIAR_POR_ID" -H "accept: application/json"

🟡 3. CREAR NUEVO PAQUETE (POST)
Registra un paquete en el sistema. El costo se simula en el momento de la creación.
Comando:
curl -X POST "http://localhost:8080/api/v1/packages" -H "Content-Type: application/json" -d "{ "numeroRastreo": "TRK-100", "peso": 5.5, "alto": 10.0, "ancho": 10.0, "largo": 10.0, "estadoId": "GUID_REGISTRADO" }"

🟠 4. SIMULAR COSTO (GET)
Calcula el costo dinámico sin modificar la base de datos ni asignar rutas.
Comando:
curl -X GET "http://localhost:8080/api/v1/packages/CAMBIAR_POR_ID/shipping-cost" -H "accept: application/json"


🔴 5. ACTUALIZAR ESTADO (PATCH)
Cambia el estatus del paquete validando las reglas de negocio (Transitions).
Comando:
curl -X PATCH "http://localhost:8080/api/v1/packages/CAMBIAR_POR_ID/status" -H "Content-Type: application/json" -d "{ "estadoId": "GUID_NUEVO_ESTADO" }"

🟣 6. ASIGNAR RUTA A UN PAQUETE (POST)
Establece la ruta definitiva para un paquete existente. Esto activará el cálculo final de costos y logística.
Comando:
curl -X POST "http://localhost:8080/api/v1/packages/ID_DEL_PAQUETE/assign-route" -H "Content-Type: application/json" -d ""GUID_DE_LA_RUTA_AQUÍ""
