using System;
using Partidos.Aplicacion;

namespace ConsolaUI.Menus
{
    // Menú de consola para simular partidos entre dos equipos
    public class MenuPartidos
    {
        // Caso de uso que contiene la lógica para simular un partido y actualizar estadísticas
        private readonly SimularPartidoCasoUso _simularPartido;

        // En el constructor recibo el caso de uso que voy a usar en este menú
        public MenuPartidos(SimularPartidoCasoUso simularPartido)
        {
            _simularPartido = simularPartido;
        }

        // Muestra la pantalla para ingresar los datos de un partido y simularlo
        public void Mostrar()
        {
            // Limpio la consola antes de pedir la información del partido
            Console.Clear();
            Console.WriteLine(@"
            ___(_)_ __ ___  _   _| | __ _  ___(_) ___  _ __     __| | ___   _ __   __ _ _ __| |_(_) __| | ___  
            / __| | '_ ` _ \| | | | |/ _` |/ __| |/ _ \| '_ \   / _` |/ _ \ | '_ \ / _` | '__| __| |/ _` |/ _ \ 
            \__ \ | | | | | | |_| | | (_| | (__| | (_) | | | | | (_| |  __/ | |_) | (_| | |  | |_| | (_| | (_) |
            |___/_|_| |_| |_|\__,_|_|\__,_|\___|_|\___/|_| |_|  \__,_|\___| | .__/ \__,_|_|   \__|_|\__,_|\___/ ");

            // Pido el nombre del equipo local
            Console.Write("Nombre equipo local: ");
            var nombreLocal = Console.ReadLine() ?? string.Empty;

            // Pido el nombre del equipo visitante
            Console.Write("Nombre equipo visitante: ");
            var nombreVisitante = Console.ReadLine() ?? string.Empty;

            // Pido los goles del equipo local como texto
            Console.Write("Goles local: ");
            var golesLocalTexto = Console.ReadLine() ?? "0";

            // Pido los goles del equipo visitante como texto
            Console.Write("Goles visitante: ");
            var golesVisitanteTexto = Console.ReadLine() ?? "0";

            // Valido que los goles ingresados se puedan convertir a enteros
            if (!int.TryParse(golesLocalTexto, out var golesLocal) ||
                !int.TryParse(golesVisitanteTexto, out var golesVisitante))
            {
                Console.WriteLine("Goles inválidos. Deben ser números enteros.");
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            try
            {
                // Llamo al caso de uso para simular el partido y aplicar el resultado a ambos equipos
                _simularPartido.Ejecutar(nombreLocal, nombreVisitante, golesLocal, golesVisitante);
                Console.WriteLine("Partido simulado correctamente.");
            }
            catch (Exception ex)
            {
                // Si hay algún problema (equipos no existen, nombres iguales, etc.) muestro el error
                Console.WriteLine($"Error al simular partido: {ex.Message}");
            }

            // Pausa para que el usuario pueda ver el resultado antes de volver al menú
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
