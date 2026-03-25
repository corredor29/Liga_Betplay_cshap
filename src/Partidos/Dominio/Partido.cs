using System;
using Equipos.Dominio;

namespace Partidos.Dominio
{
    public class Partido
    {
        public Equipo Local {get;}
        public Equipo Visitante {get;}
        public int GolesLocal { get; }
        public int GolesVisitante { get; }

        public Partido(Equipo local, Equipo visitante, int golesLocal, int golesVisitante)
        {
            if (local is null) throw new ArgumentNullException(nameof(local));
            if (visitante is null) throw new ArgumentNullException(nameof(visitante));
            if (ReferenceEquals (Local, visitante)) throw new ArgumentException("un equipo no puede jugar contra si mismo ");
            if (golesLocal < 0 || GolesVisitante < 0) throw new ArgumentException("los goles no pueden ser negativos");
            local = local;
            visitante = visitante;
            GolesLocal = golesLocal;
            GolesVisitante = golesVisitante;
         }
        public void AplicarResultado()
        {
            Local.Estadisticas.RegistrarPartido(GolesLocal, GolesVisitante);
            Visitante.Estadisticas.RegistrarPartido(GolesVisitante, GolesLocal);
        }
    }
}