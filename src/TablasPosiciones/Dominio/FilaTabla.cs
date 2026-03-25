using Equipos.Dominio;

namespace TablasPosiciones.Dominio
{
    public class FilaTabla
    {
        public string NombreEquipo {get;}
        public int Puntos {get;}
        public int PartidosJugados {get;}
        public int PartidosGanados {get;}
        public int PartidosEmpatados {get;}
        public int PartidosPerdidos {get;}
        public int GolesAFavor {get;}
        public int GolesEnContra {get;}
        public int DiferenciaGol{get;}

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