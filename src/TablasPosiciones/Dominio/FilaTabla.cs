using Equipos.Dominio;

namespace TablasPosiciones.Dominio
{
    // Representa una fila de la tabla de posiciones para un equipo
    public class FilaTabla
    {
        // Nombre del equipo que aparece en la tabla
        public string NombreEquipo { get; }

        // Puntos acumulados por el equipo
        public int Puntos { get; }

        // Partidos jugados por el equipo
        public int PartidosJugados { get; }

        // Partidos ganados
        public int PartidosGanados { get; }

        // Partidos empatados
        public int PartidosEmpatados { get; }

        // Partidos perdidos
        public int PartidosPerdidos { get; }

        // Goles a favor
        public int GolesAFavor { get; }

        // Goles en contra
        public int GolesEnContra { get; }

        // Diferencia de gol (GF - GC)
        public int DiferenciaGol { get; }

        // Creo la fila de la tabla a partir de un objeto Equipo y sus estadísticas
        public FilaTabla(Equipo Equipo)
        {
            NombreEquipo = Equipo.Nombre;
            Puntos = Equipo.Estadisticas.Puntos;
            PartidosJugados = Equipo.Estadisticas.PartidosJugados;
            PartidosGanados = Equipo.Estadisticas.PartidosGanados;
            PartidosEmpatados = Equipo.Estadisticas.PartidosEmpatados;
            PartidosPerdidos = Equipo.Estadisticas.PartidosPerdidos;
            GolesAFavor = Equipo.Estadisticas.GolesAFavor;
            GolesEnContra = Equipo.Estadisticas.GolesEnContra;
            DiferenciaGol = GolesAFavor - GolesEnContra;
        }
    }
}
