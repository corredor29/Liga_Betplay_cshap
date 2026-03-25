using System;
using Estadisticas.Aplicacion;

namespace ConsolaUI.Menus
{
    public class MenuEstadisticas
    {
        private readonly ConsultasEstadisticas _consultas;

        public MenuEstadisticas(ConsultasEstadisticas consultas)
        {
            _consultas = consultas;
        }

        public void Mostrar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@" 
                 _____     _            _ _     _   _                     _      _   _                              
                 | ____|___| |_ __ _  __| (_)___| |_(_) ___ __ _ ___    __| | ___| | | |_ ___  _ __ _ __   ___  ___  
                 |  _| / __| __/ _` |/ _` | / __| __| |/ __/ _` / __|  / _` |/ _ \ | | __/ _ \| '__| '_ \ / _ \/ _ \ 
                 | |___\__ \ || (_| | (_| | \__ \ |_| | (_| (_| \__ \ | (_| |  __/ | | || (_) | |  | | | |  __/ (_) |
                 |_____|___/\__\__,_|\__,_|_|___/\__|_|\___\__,_|___/  \__,_|\___|_|  \__\___/|_|  |_| |_|\___|\___/ 
                ");
                Console.WriteLine("1. Ver líder del torneo");
                Console.WriteLine("2. Ver equipos invictos");
                Console.WriteLine("3. Ver Top 3");
                Console.WriteLine("4. Equipos con más goles a favor");
                Console.WriteLine("5. Equipos con menos goles en contra");
                Console.WriteLine("6. Equipos con diferencia de gol positiva");
                Console.WriteLine("7. Equipos por debajo del promedio de puntos");
                Console.WriteLine("0. Volver al menú principal");
                Console.Write("Opción: ");

                var opcion = Console.ReadLine();

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
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void MostrarLider()
        {
            Console.Clear();
            Console.WriteLine("=== Líder del torneo ===");

            var lider = _consultas.ObtenerLider();

            if (lider is null)
            {
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

        private void MostrarInvictos()
        {
            Console.Clear();
            Console.WriteLine("Equipos invictos (pendiente de implementar consultas).");
            Console.ReadKey();
        }

        private void MostrarTop3()
        {
            Console.Clear();
            Console.WriteLine("Top 3 (pendiente de implementar consultas).");
            Console.ReadKey();
        }

        private void MostrarMasGolesAFavor()
        {
            Console.Clear();
            Console.WriteLine("Equipos con más goles a favor (pendiente).");
            Console.ReadKey();
        }

        private void MostrarMenosGolesEnContra()
        {
            Console.Clear();
            Console.WriteLine("Equipos con menos goles en contra (pendiente).");
            Console.ReadKey();
        }

        private void MostrarDiferenciaGolPositiva()
        {
            Console.Clear();
            Console.WriteLine("Equipos con diferencia de gol positiva (pendiente).");
            Console.ReadKey();
        }

        private void MostrarPorDebajoPromedioPuntos()
        {
            Console.Clear();
            Console.WriteLine("Equipos por debajo del promedio de puntos (pendiente).");
            Console.ReadKey();
        }
    }
}
