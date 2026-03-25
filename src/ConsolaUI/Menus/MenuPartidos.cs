using System.Xml.Linq;
using System;

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

            Console.WriteLine("nombre del equipo local: ");
            string nombreLocal = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("nombre del equipo visitante: ");
            string nombreVisitante = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Goles local: ");
            var golesLocalTexto = Console.ReadLine() ?? "0";

            Console.WriteLine("goles visitantes:");
            var golesVisitantesTexto = Console.ReadLine() ?? "0";

            if(!int.TryParse(golesLocalTexto, out var golesLocal) || !int.TryParse(golesVisitantesTexto, out var golesVisitantes))
            {
                Console.WriteLine("Goles invalidos, Deben ser numeros enteros ");
                Console.WriteLine("Presiona una tecla para continuar... ");
                Console.ReadKey();
                return;
            }
            try
            {
                _simularPartido.Ejecutar(nombreLocal,nombreVisitante,golesLocal,golesVisitantes);
                Console.WriteLine("Partido simulado correstamente ");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error al simular partido: {ex.Message}");
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
