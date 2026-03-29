using System;
using Equipos.Aplicacion;
using Equipos.Infraestructura;
using Estadisticas.Aplicacion;
using Partidos.Aplicacion;
using ConsolaUI.Menus;
using TablasPosiciones.Aplicacion;

internal class Program
{
    private static void Main(string[] args)
    {
        // ================== Infraestructura ==================
        // Repositorio en memoria donde se guardan todos los equipos
        var repoEquipos = new RepositorioEquiposJson("equipos.json");

        // ================== Casos de uso ==================
        // Caso de uso para registrar nuevos equipos
        var registrarEquipo = new RegistrarEquipoCasoUso(repoEquipos);
        // Caso de uso para listar todos los equipos
        var listarEquipos = new ListarEquiposCasoUno(repoEquipos);
        // Caso de uso para simular partidos y actualizar estadísticas
        var simularPartido = new SimularPartidoCasoUso(repoEquipos);
        // Servicio de consultas de estadísticas usando LINQ
        var consultas = new ConsultasEstadisticas(repoEquipos);
        // Caso de uso para obtener la tabla de posiciones
        var obtenerTabla = new ObtenerTablaPosicionesCasoUso(repoEquipos);

        // ================== Menús de la UI ==================
        // Menú para registrar y listar equipos
        var menuEquipos = new MenuEquipos(registrarEquipo, listarEquipos);
        // Menú para simular partidos desde consola
        var menuPartidos = new MenuPartidos(simularPartido);
        // Menú para ver distintas estadísticas del torneo
        var menuEstadisticas = new MenuEstadisticas(consultas);
        // Menú para mostrar la tabla de posiciones
        var menuTabla = new MenuTablaPosiciones(obtenerTabla);

        // ================== Menú principal ==================
        while (true)
        {
            Console.Clear();
            // Título principal de la aplicación
            Console.WriteLine(@" 
             ____  _                           _     _                 _         _ _               ____       _   ____  _             
             | __ )(_) ___ _ ____   _____ _ __ (_) __| | ___     __ _  | | __ _  | (_) __ _  __ _  | __ )  ___| |_|  _ \| | __ _ _   _ 
             |  _ \| |/ _ \ '_ \ \ / / _ \ '_ \| |/ _` |/ _ \   / _` | | |/ _` | | | |/ _` |/ _` | |  _ \ / _ \ __| |_) | |/ _` | | | |
             | |_) | |  __/ | | \ V /  __/ | | | | (_| | (_) | | (_| | | | (_| | | | | (_| | (_| | | |_) |  __/ |_|  __/| | (_| | |_| |
             |____/|_|\___|_| |_|\_/ \___|_| |_|_|\__,_|\___/   \__,_| |_|\__,_| |_|_|\__, |\__,_| |____/ \___|\__|_|   |_|\__,_|\__, |
                                                                                      |___/                                      |___/ 
            ");
            Console.WriteLine("1. Registrar equipo");
            Console.WriteLine("2. Listar equipos");
            Console.WriteLine("3. Simular partido");
            Console.WriteLine("4. Ver tabla de posiciones");
            Console.WriteLine("5. Estadísticas del torneo");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");

            // Leo la opción seleccionada por el usuario
            var opcion = Console.ReadLine();

            try
            {
                // Según la opción, llamo al menú o acción correspondiente
                switch (opcion)
                {
                    case "1":
                        RegistrarEquipo(menuEquipos);
                        break;
                    case "2":
                        ListarEquipos(menuEquipos);
                        break;
                    case "3":
                        SimularPartido(menuPartidos, listarEquipos);
                        break;
                    case "4":
                        VerTabla(menuTabla);
                        break;
                    case "5":
                        menuEstadisticas.Mostrar();
                        break;
                    case "6":
                        // Salgo de la aplicación
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Pausa();
                        break;
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier error inesperado en el flujo principal
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
                Pausa();
            }
        }
    }

    // Envuelvo la llamada al menú de registro con manejo de errores
    private static void RegistrarEquipo(MenuEquipos menuEquipos)
    {
        Console.Clear();
        try
        {
            menuEquipos.MostrarRegistro();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al registrar equipo: {ex.Message}");
            Pausa();
        }
    }

    // Envuelvo la llamada al menú de listado con manejo de errores
    private static void ListarEquipos(MenuEquipos menuEquipos)
    {
        Console.Clear();
        try
        {
            menuEquipos.MostrarListado();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al listar equipos: {ex.Message}");
            Pausa();
        }
    }

    // Antes de simular un partido, verifico que haya al menos 2 equipos
    private static void SimularPartido(MenuPartidos menuPartidos, ListarEquiposCasoUno listarEquipos)
    {
        Console.Clear();

        // Validación: mínimo 2 equipos registrados
        var equipos = listarEquipos.Ejecutar();
        if (equipos.Count < 2)
        {
            Console.WriteLine("Debes registrar al menos 2 equipos antes de simular un partido.");
            Pausa();
            return;
        }

        try
        {
            menuPartidos.Mostrar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al simular partido: {ex.Message}");
            Pausa();
        }
    }

    // Muestra la tabla de posiciones y maneja errores
    private static void VerTabla(MenuTablaPosiciones menuTabla)
    {
        Console.Clear();
        try
        {
            menuTabla.Mostrar();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar la tabla de posiciones: {ex.Message}");
        }
        Pausa();
    }

    // Método de utilidad para pausar la consola
    private static void Pausa()
    {
        Console.WriteLine();
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }
}
