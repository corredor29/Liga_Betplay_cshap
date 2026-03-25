# ⚽ Simulador de la Liga BetPlay — C#
 
> Aplicación de consola en C# para simular y gestionar el torneo de la Liga BetPlay colombiana, con registro de equipos, simulación de partidos, tabla de posiciones y estadísticas avanzadas usando LINQ.
 
---
 
## 📋 Descripción
 
Este proyecto implementa una simulación funcional de la Liga BetPlay desde consola, aplicando **Programación Orientada a Objetos (POO)**, **estructuras de datos en memoria** y **consultas LINQ**. Permite registrar equipos, simular encuentros deportivos, actualizar estadísticas automáticamente y consultar métricas relevantes del torneo.
 
El proyecto tiene un enfoque didáctico y es útil como ejercicio práctico para estudiantes y desarrolladores que deseen fortalecer sus habilidades en C#.
 
---
 
## 🚀 Funcionalidades
 
- **Registrar equipos** al torneo (almacenados en memoria).
- **Listar equipos** registrados.
- **Simular partidos** ingresando el marcador del encuentro.
- **Actualización automática** de estadísticas tras cada partido (PJ, PG, PE, PP, GF, GC, TP).
- **Tabla de posiciones** ordenada por: puntos → diferencia de gol → goles a favor → nombre.
- **Estadísticas avanzadas con LINQ**, entre ellas:
  - Líder del torneo y Top 3.
  - Equipos con más goles a favor / menos goles en contra.
  - Equipos con más victorias, más empates o más derrotas.
  - Equipos invictos y equipos sin victorias.
  - Equipos con diferencia de gol positiva.
  - Promedio de goles a favor y en contra del torneo.
  - Total de goles y puntos acumulados.
  - Búsqueda de equipo por nombre.
  - Equipos por debajo del promedio de puntos.
  - Listado alfabético de equipos.
  - Resumen general del torneo.
 
---
 
## 🗂️ Estructura del proyecto
 
```
Liga_Betplay_cshap/
├── src/
│   ├── Equipos/
│   │   ├── Aplicacion/        # Casos de uso: RegistrarEquipo, ListarEquipos
│   │   └── Infraestructura/   # RepositorioEquiposMemoria
│   ├── Partidos/
│   │   └── Aplicacion/        # SimularPartidoCasoUso
│   ├── Estadisticas/
│   │   └── Aplicacion/        # ConsultasEstadisticas (LINQ)
│   └── ConsolaUI/
│       └── Menus/             # MenuEstadisticas
├── obj/
├── Program.cs                 # Punto de entrada y menú principal
├── LigaBetPlay.csproj
├── LigaBetPlay.sln
└── .gitignore
```
 
---
 
## 🛠️ Tecnologías
 
| Elemento | Detalle |
|---|---|
| Lenguaje | C# |
| Framework | .NET 10 |
| Paradigma | Programación Orientada a Objetos (POO) |
| Estructuras de datos | Listas en memoria (`List<T>`) |
| Consultas | LINQ |
| Entorno | Aplicación de consola |
| IDE recomendado | Visual Studio / Visual Studio Code |
 
---
 
## ⚙️ Requisitos previos
 
- [.NET SDK 10](https://dotnet.microsoft.com/download) instalado en tu máquina.
- Git (opcional, para clonar el repositorio).
 
---
 
## 📦 Instalación y ejecución
 
1. **Clona el repositorio:**
 
```bash
git clone https://github.com/corredor29/Liga_Betplay_cshap.git
cd Liga_Betplay_cshap
```
 
2. **Compila el proyecto:**
 
```bash
dotnet build
```
 
3. **Ejecuta la aplicación:**
 
```bash
dotnet run
```
 
---
 
## 🎮 Uso
 
Al iniciar la aplicación, verás el menú principal:
 
```
1. Registrar equipo
2. Listar equipos
3. Simular partido
4. Estadísticas del torneo
5. Salir
```
 
**Flujo típico de uso:**
 
1. Registra al menos dos equipos con la opción `1`.
2. Simula un partido entre ellos con la opción `3`, ingresando los nombres y el marcador.
3. Consulta la tabla de posiciones o estadísticas desde la opción `4`.
 
---
 
## 📊 Modelo de datos
 
Cada equipo almacena la siguiente información:
 
| Campo | Descripción |
|---|---|
| Nombre | Nombre del equipo |
| PJ | Partidos Jugados |
| PG | Partidos Ganados |
| PE | Partidos Empatados |
| PP | Partidos Perdidos |
| GF | Goles a Favor |
| GC | Goles en Contra |
| TP | Total de Puntos |
 
**Cálculo de puntos:** Victoria = 3 pts · Empate = 1 pt · Derrota = 0 pts.
 
---
 
## 📌 Alcance actual
 
✅ Registro y listado de equipos  
✅ Simulación de partidos con marcador manual  
✅ Actualización automática de estadísticas  
✅ Tabla de posiciones ordenada  
✅ Consultas LINQ sobre el torneo  
✅ Menú interactivo en consola  
 
❌ Persistencia en base de datos o archivos  
❌ Interfaz gráfica  
❌ Consumo de APIs externas  
❌ Gestión de goleadores individuales  
❌ Calendario de jornadas completo  
 
---
 
## 🧩 Arquitectura
 
El proyecto sigue una arquitectura en capas sencilla orientada al aprendizaje:
 
- **Aplicación:** casos de uso que orquestan la lógica del negocio.
- **Infraestructura:** repositorio en memoria que simula la persistencia de datos.
- **UI de consola:** menús que interactúan con el usuario y delegan en los casos de uso.
 
---
 
## 👤 Autor
 
**Felipe Corredor Silva**
**Wendy Angelica Vega Sanchez**  
