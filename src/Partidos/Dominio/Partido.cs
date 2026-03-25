using System;
using Equipos.Dominio;

namespace Partidos.Dominio
{
    public class Partido
    {
        public Equipo Local { get; }
        public Equipo Visitante { get; }
        public int GolesLocal { get; }
        public int GolesVisitante { get; }

        public Partido(Equipo local, Equipo visitante, int golesLocal, int golesVisitante)
        {
            if (local is null) 
                throw new ArgumentNullException(nameof(local));
            if (visitante is null) 
                throw new ArgumentNullException(nameof(visitante));

            
            if (ReferenceEquals(local, visitante)) 
                throw new ArgumentException("Un equipo no puede jugar contra sí mismo.");

            if (golesLocal < 0 || golesVisitante < 0) 
                throw new ArgumentException("Los goles no pueden ser negativos.");


            Local = local;
            Visitante = visitante;
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
