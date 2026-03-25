using System.Xml.Linq;
using System;
using Partidos.Aplicacion;


namespace ConsolaUI.Menus
{
    public class MenuPartido
    {
        private readonly SimularPartidoCasoUso _simularPartido;
        public MenuPartido(SimularPartidoCasoUso simularPartido)
        {
            _simularPartido = simularPartido;
        }
        public void Mostrar()
        {
            Console.Clear();
            Console.WriteLine(@"
            ___(_)_ __ ___  _   _| | __ _  ___(_) ___  _ __     __| | ___   _ __   __ _ _ __| |_(_) __| | ___  
            / __| | '_ ` _ \| | | | |/ _` |/ __| |/ _ \| '_ \   / _` |/ _ \ | '_ \ / _` | '__| __| |/ _` |/ _ \ 
            \__ \ | | | | | | |_| | | (_| | (__| | (_) | | | | | (_| |  __/ | |_) | (_| | |  | |_| | (_| | (_) |
            |___/_|_| |_| |_|\__,_|_|\__,_|\___|_|\___/|_| |_|  \__,_|\___| | .__/ \__,_|_|   \__|_|\__,_|\___/ ");

            Console.Write("Nombre equipo local: ");
            var nombreLocal = Console.ReadLine() ?? string.Empty;

            Console.Write("Nombre equipo visitante: ");
            var nombreVisitante = Console.ReadLine() ?? string.Empty;

            Console.Write("Goles local: ");
            var golesLocalTexto = Console.ReadLine() ?? "0";

            Console.Write("Goles visitante: ");
            var golesVisitanteTexto = Console.ReadLine() ?? "0";

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
                _simularPartido.Ejecutar(nombreLocal, nombreVisitante, golesLocal, golesVisitante);
                Console.WriteLine("Partido simulado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al simular partido: {ex.Message}");
            }

            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}