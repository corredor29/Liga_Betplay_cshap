using System;
using TablasPosiciones.Aplicacion;

namespace ConsolaUI.Menus
{
    public class MenuTablaPosiciones
    {
        private readonly ObtenerTablaPosicionesCasoUso _casoUso;

        public MenuTablaPosiciones(ObtenerTablaPosicionesCasoUso CasoUso)
        {
            _casoUso = CasoUso;
        }

        public void Mostrar()
        {
            var Tabla = _casoUso.Ejecutar();

            Console.WriteLine(@"  _____  _    ____  _        _      ____  _____   ____   ___  ____ ___ ____ ___ ___  _   _ _____ ____  
                |_   _|/ \  | __ )| |      / \    |  _ \| ____| |  _ \ / _ \/ ___|_ _/ ___|_ _/ _ \| \ | | ____/ ___| 
                | | / _ \ |  _ \| |     / _ \   | | | |  _|   | |_) | | | \___ \| | |    | | | | |  \| |  _| \___ \ 
                | |/ ___ \| |_) | |___ / ___ \  | |_| | |___  |  __/| |_| |___) | | |___ | | |_| | |\  | |___ ___) |
                |_/_/   \_\____/|_____/_/   \_\ |____/|_____| |_|    \___/|____/___\____|___\___/|_| \_|_____|____/ ");
            Console.WriteLine("Nombre | Pts | PJ | PG | PE | PP | GF | GC | DG");

            foreach (var fila in Tabla)
            {
                Console.WriteLine(
                    $"{fila.NombreEquipo} | {fila.Puntos} | {fila.PartidosJugados} | {fila.PartidosGanados} | {fila.PartidosEmpatados} | {fila.PartidosPerdidos} | {fila.GolesAFavor} | {fila.GolesEnContra} | {fila.DiferenciaGol}"
                );
            }
        }
    }
}