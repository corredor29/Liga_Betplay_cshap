using System;
using System.Linq;
using Estadisticas.Aplicacion;

namespace ConsolaUI.Menus
{
    // Menú de consola para ver las estadísticas del torneo
    public class MenuEstadisticas
    {
        // Servicio que encapsula todas las consultas con LINQ sobre los equipos
        private readonly ConsultasEstadisticas _consultas;

        // En el constructor recibo la clase de consultas de estadísticas
        public MenuEstadisticas(ConsultasEstadisticas consultas)
        {
            _consultas = consultas;
        }

        // Muestra el submenú de estadísticas y mantiene el ciclo hasta que el usuario vuelva
        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                // Título decorativo del módulo de estadísticas
                Console.WriteLine(@" 
                 _____     _            _ _     _   _                     _      _   _                              
                 | ____|___| |_ __ _  __| (_)___| |_(_) ___ __ _ ___    __| | ___| | | |_ ___  _ __ _ __   ___  ___  
                 |  _| / __| __/ _` |/ _` | / __| __| |/ __/ _` / __|  / _` |/ _ \ | | __/ _ \| '__| '_ \ / _ \/ _ \ 
                 | |___\__ \ || (_| | (_| | \__ \ |_| | (_| (_| \__ \ | (_| |  __/ | | || (_) | |  | | | |  __/ (_) |
                 |_____|___/\__\__,_|\__,_|_|___/\__|_|\___\__,_|___/  \__,_|\___|_|  \__\___/|_|  |_| |_|\___|\___/ 
                ");

                // Opciones disponibles de estadísticas
                Console.WriteLine("1. Ver líder del torneo");
                Console.WriteLine("2. Ver equipos invictos");
                Console.WriteLine("3. Ver Top 3");
                Console.WriteLine("4. Equipos con más goles a favor");
                Console.WriteLine("5. Equipos con menos goles en contra");
                Console.WriteLine("6. Equipos con diferencia de gol positiva");
                Console.WriteLine("7. Equipos por debajo del promedio de puntos");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Opción: ");

                // Leo la opción que ingresa el usuario
                var opcion = Console.ReadLine();

                // Según la opción, llamo al método correspondiente
                switch (opcion)
                {
                    case "1":
                        MostrarLider();
                        break;
                    case "2":
                        MostrarInvictos();
                        break;
                    case "3":
                        MostrarTop3();
                        break;
                    case "4":
                        MostrarMasGolesAFavor();
                        break;
                    case "5":
                        MostrarMenosGolesEnContra();
                        break;
                    case "6":
                        MostrarDiferenciaGolPositiva();
                        break;
                    case "7":
                        MostrarPorDebajoPromedioPuntos();
                        break;
                    case "0":
                        // Salgo del submenú de estadísticas y regreso al menú principal
                        return;
                    default:
                        // Mensaje cuando la opción no es válida
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Muestra el líder actual del torneo (según puntos y criterios definidos en ConsultasEstadisticas)
        private void MostrarLider()
        {
            Console.Clear();
            Console.WriteLine("=== Líder del torneo ===");

            // Obtengo el equipo líder desde las consultas
            var lider = _consultas.ObtenerLider();

            if (lider is null)
            {
                // Si no hay equipos registrados todavía
                Console.WriteLine("No hay equipos registrados todavía.");
            }
            else
            {
                var s = lider.Estadisticas;
                Console.WriteLine($"Equipo: {lider.Nombre}");
                Console.WriteLine($"PJ: {s.PartidosJugados}  PG: {s.PartidosGanados}  PE: {s.PartidosEmpatados}  PP: {s.PartidosPerdidos}");
                Console.WriteLine($"GF: {s.GolesAFavor}  GC: {s.GolesEnContra}  DG: {s.DiferenciaGoles}");
                Console.WriteLine($"Puntos: {s.Puntos}");
            }

            Console.WriteLine();
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra todos los equipos que no han perdido ningún partido
        private void MostrarInvictos()
        {
            Console.Clear();
            Console.WriteLine("=== Equipos invictos ===");

            // Traigo la lista de equipos invictos y la materializo en memoria
            var invictos = _consultas.ObtenerEquiposInvictos().ToList();

            if (invictos.Count == 0)
            {
                Console.WriteLine("No hay equipos invictos.");
            }
            else
            {
                // Recorro y muestro datos básicos de cada equipo invicto
                foreach (var e in invictos)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{e.Nombre} - PJ:{s.PartidosJugados} PG:{s.PartidosGanados} PE:{s.PartidosEmpatados} PP:{s.PartidosPerdidos} Pts:{s.Puntos}");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra el Top 3 de la tabla de posiciones
        private void MostrarTop3()
        {
            Console.Clear();
            Console.WriteLine("=== Top 3 equipos ===");

            // Obtengo los 3 mejores equipos según la lógica de ConsultasEstadisticas
            var top3 = _consultas.ObtenerTop3().ToList();

            if (top3.Count == 0)
            {
                Console.WriteLine("No hay equipos suficientes.");
            }
            else
            {
                var pos = 1;
                // Recorro el Top 3 y muestro posición y estadísticas importantes
                foreach (var e in top3)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{pos}. {e.Nombre} - Pts:{s.Puntos} DG:{s.DiferenciaGoles} GF:{s.GolesAFavor} PJ:{s.PartidosJugados}");
                    pos++;
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra los equipos con más goles a favor
        private void MostrarMasGolesAFavor()
        {
            Console.Clear();
            Console.WriteLine("=== Equipos con más goles a favor ===");

            // Consulto los equipos que tienen la mejor ofensiva
            var equipos = _consultas.ObtenerEquiposConMasGolesAFavor().ToList();

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                foreach (var e in equipos)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{e.Nombre} - GF:{s.GolesAFavor} PJ:{s.PartidosJugados} Pts:{s.Puntos}");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra los equipos con menos goles en contra (mejor defensa)
        private void MostrarMenosGolesEnContra()
        {
            Console.Clear();
            Console.WriteLine("=== Equipos con menos goles en contra ===");

            // Consulto los equipos con mejor defensa
            var equipos = _consultas.ObtenerEquiposConMenosGolesEnContra().ToList();

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                foreach (var e in equipos)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{e.Nombre} - GC:{s.GolesEnContra} PJ:{s.PartidosJugados} Pts:{s.Puntos}");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra los equipos que tienen diferencia de gol positiva
        private void MostrarDiferenciaGolPositiva()
        {
            Console.Clear();
            Console.WriteLine("=== Equipos con diferencia de gol positiva ===");

            // Consulto los equipos que anotan más de lo que les marcan
            var equipos = _consultas.ObtenerEquiposConDiferenciaGolPositiva().ToList();

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos con diferencia de gol positiva.");
            }
            else
            {
                foreach (var e in equipos)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{e.Nombre} - DG:{s.DiferenciaGoles} GF:{s.GolesAFavor} GC:{s.GolesEnContra} Pts:{s.Puntos}");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra los equipos que están por debajo del promedio de puntos del torneo
        private void MostrarPorDebajoPromedioPuntos()
        {
            Console.Clear();
            Console.WriteLine("=== Equipos por debajo del promedio de puntos ===");

            // Consulto los equipos que tienen menos puntos que el promedio general
            var equipos = _consultas.ObtenerEquiposPorDebajoDelPromedioPuntos().ToList();

            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos por debajo del promedio (or no hay equipos).");
            }
            else
            {
                foreach (var e in equipos)
                {
                    var s = e.Estadisticas;
                    Console.WriteLine($"{e.Nombre} - Pts:{s.Puntos} PJ:{s.PartidosJugados}");
                }
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
