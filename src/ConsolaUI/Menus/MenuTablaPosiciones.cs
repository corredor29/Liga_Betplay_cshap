using System;
using TablasPosiciones.Aplicacion;

namespace ConsolaUI.Menus
{
    // Menú de consola para mostrar la tabla de posiciones del torneo
    public class MenuTablaPosiciones
    {
        // Caso de uso que se encarga de armar la tabla de posiciones ordenada
        private readonly ObtenerTablaPosicionesCasoUso _casoUso;

        // En el constructor recibo el caso de uso que voy a usar para obtener la tabla
        public MenuTablaPosiciones(ObtenerTablaPosicionesCasoUso CasoUso)
        {
            _casoUso = CasoUso;
        }

        // Muestra la tabla de posiciones completa en la consola
        public void Mostrar()
        {
            // Pido la tabla de posiciones al caso de uso (ya viene ordenada según la lógica del proyecto)
            var Tabla = _casoUso.Ejecutar();

            // Título decorativo del módulo de tabla de posiciones
            Console.WriteLine(@"  _____  _    ____  _        _      ____  _____   ____   ___  ____ ___ ____ ___ ___  _   _ _____ ____  
                |_   _|/ \  | __ )| |      / \    |  _ \| ____| |  _ \ / _ \/ ___|_ _/ ___|_ _/ _ \| \ | | ____/ ___| 
                | | / _ \ |  _ \| |     / _ \   | | | |  _|   | |_) | | | \___ \| | |    | | | | |  \| |  _| \___ \ 
                | |/ ___ \| |_) | |___ / ___ \  | |_| | |___  |  __/| |_| |___) | | |___ | | |_| | |\  | |___ ___) |
                |_/_/   \_\____/|_____/_/   \_\ |____/|_____| |_|    \___/|____/___\____|___\___/|_| \_|_____|____/ ");

            // Encabezado de las columnas de la tabla
            Console.WriteLine("Nombre | Pts | PJ | PG | PE | PP | GF | GC | DG");

            // Recorro cada fila de la tabla y muestro las estadísticas del equipo
            foreach (var fila in Tabla)
            {
                Console.WriteLine(
                    $"{fila.NombreEquipo} | {fila.Puntos} | {fila.PartidosJugados} | {fila.PartidosGanados} | {fila.PartidosEmpatados} | {fila.PartidosPerdidos} | {fila.GolesAFavor} | {fila.GolesEnContra} | {fila.DiferenciaGol}"
                );
            }

            // Pausa para que el usuario pueda leer la tabla antes de volver al menú
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
