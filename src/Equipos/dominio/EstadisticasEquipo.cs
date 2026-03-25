namespace Equipos.Dominio
{
    // Lleva todas las estadísticas acumuladas de un equipo en el torneo
    public class EstadisticasEquipo
    {
        // Cantidad total de partidos jugados
        public int PartidosJugados { get; private set; }

        // Partidos que el equipo ha ganado
        public int PartidosGanados { get; private set; }

        // Partidos que el equipo ha empatado
        public int PartidosEmpatados { get; private set; }

        // Partidos que el equipo ha perdido
        public int PartidosPerdidos { get; private set; }

        // Goles que el equipo ha marcado
        public int GolesAFavor { get; private set; }

        // Goles que el equipo ha recibido
        public int GolesEnContra { get; private set; }

        // Puntos acumulados (3 por victoria, 1 por empate)
        public int Puntos { get; private set; }

        // Diferencia de gol calculada a partir de GF - GC
        public int DiferenciaGoles => GolesAFavor - GolesEnContra;

        // Registra un nuevo partido y actualiza todas las estadísticas
        public void RegistrarPartido(int golesAFavor, int golesEnContra)
        {
            // No permito goles negativos
            if (golesAFavor < 0 || golesEnContra < 0)
                throw new ArgumentException("Los goles no pueden ser negativos.");
            
            // Cada vez que registro un partido incremento el contador de PJ
            PartidosJugados++;

            // Acumulo los goles a favor y en contra
            GolesAFavor += golesAFavor;
            GolesEnContra += golesEnContra;

            // Según el resultado, actualizo ganados, empatados, perdidos y puntos
            if (golesAFavor > golesEnContra)
            {
                PartidosGanados++;
                Puntos += 3;
            }
            else if (golesAFavor == golesEnContra)
            {
                PartidosEmpatados++;
                Puntos += 1;
            }
            else
            {
                PartidosPerdidos++;
            }
        }
    }
}
