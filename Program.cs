using System;
using Equipos.Aplicacion;
using Equipos.Infraestructura;
using Estadisticas.Aplicacion;
using Partidos.Aplicacion;

internal class Program
{
    private static void Main(string[] args)
    {
        var repoEquipos = new RepositorioEquiposMemoria();
        var registrarEquipo = new RegistrarEquipoCasoUso(repoEquipos);
        var listarEquipos = new ListarEquiposCasoUno(repoEquipos);
        var simularPartido = new SimularPartidoCasoUso(repoEquipos);
        var consultas = new ConsultasEstadisticas(repoEquipos);

        while (true)
        {
            Console.Clear();
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
            Console.WriteLine("4. Ver líder del torneo");
            Console.WriteLine("5. Salir");
            Console.Write("Opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarEquipo(registrarEquipo);
                    break;
                case "2":
                    ListarEquipos(listarEquipos);
                    break;
                case "3":
                    SimularPartido(simularPartido);
                    break;
                case "4":
                    VerLider(consultas);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void RegistrarEquipo(RegistrarEquipoCasoUso registrar)
    {
        Console.Clear();
        Console.WriteLine("=== Registrar equipo ===");
        Console.Write("Nombre del equipo: ");
        var nombre = Console.ReadLine() ?? string.Empty;

        try
        {
            registrar.Ejecutar(nombre);
            Console.WriteLine("Equipo registrado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    private static void ListarEquipos(ListarEquiposCasoUno listar)
    {
        Console.Clear();
        Console.WriteLine("=== Lista de equipos ===");

        var equipos = listar.Ejecutar();

        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
        }
        else
        {
            foreach (var e in equipos)
            {
                Console.WriteLine($"- {e.Nombre}");
            }
        }

        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    private static void SimularPartido(SimularPartidoCasoUso simular)
    {
        Console.Clear();
        Console.WriteLine("=== Simular partido ===");

        Console.Write("Nombre equipo local: ");
        var local = Console.ReadLine() ?? string.Empty;

        Console.Write("Nombre equipo visitante: ");
        var visitante = Console.ReadLine() ?? string.Empty;

        Console.Write("Goles local: ");
        var gLocalTxt = Console.ReadLine() ?? "0";

        Console.Write("Goles visitante: ");
        var gVisTxt = Console.ReadLine() ?? "0";

        if (!int.TryParse(gLocalTxt, out var gLocal) ||
            !int.TryParse(gVisTxt, out var gVis))
        {
            Console.WriteLine("Goles inválidos.");
            Console.ReadKey();
            return;
        }

        try
        {
            simular.Ejecutar(local, visitante, gLocal, gVis);
            Console.WriteLine("Partido simulado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    private static void VerLider(ConsultasEstadisticas consultas)
    {
        Console.Clear();
        Console.WriteLine("=== Líder del torneo ===");

        var lider = consultas.ObtenerLider();

        if (lider is null)
        {
            Console.WriteLine("No hay equipos registrados.");
        }
        else
        {
            var s = lider.Estadisticas;
            Console.WriteLine($"Equipo: {lider.Nombre}");
            Console.WriteLine($"PJ: {s.PartidosJugados}  PG: {s.PartidosGanados}  PE: {s.PartidosEmpatados}  PP: {s.PartidosPerdidos}");
            Console.WriteLine($"GF: {s.GolesAFavor}  GC: {s.GolesEnContra}  DG: {s.DiferenciaGoles}");
            Console.WriteLine($"Puntos: {s.Puntos}");
        }

        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }
}
