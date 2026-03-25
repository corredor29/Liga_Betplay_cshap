using System;
using Equipos.Dominio;

namespace Partidos.Dominio
{
    // Representa un partido entre dos equipos y su resultado
    public class Partido
    {
        // Equipo que juega como local
        public Equipo Local { get; }

        // Equipo que juega como visitante
        public Equipo Visitante { get; }

        // Goles anotados por el equipo local
        public int GolesLocal { get; }

        // Goles anotados por el equipo visitante
        public int GolesVisitante { get; }

        // Al crear el partido, valido los datos y guardo el marcador
        public Partido(Equipo local, Equipo visitante, int golesLocal, int golesVisitante)
        {
            // Valido que los equipos no sean nulos
            if (local is null) 
                throw new ArgumentNullException(nameof(local));
            if (visitante is null) 
                throw new ArgumentNullException(nameof(visitante));

            // Valido que no sea el mismo objeto equipo jugando contra sí mismo
            if (ReferenceEquals(local, visitante)) 
                throw new ArgumentException("Un equipo no puede jugar contra sí mismo.");

            // Valido que los goles no sean negativos
            if (golesLocal < 0 || golesVisitante < 0) 
                throw new ArgumentException("Los goles no pueden ser negativos.");

            Local = local;
            Visitante = visitante;
            GolesLocal = golesLocal;
            GolesVisitante = golesVisitante;
        }

        // Aplica el resultado del partido a las estadísticas de ambos equipos
        public void AplicarResultado()
        {
            // Actualizo las estadísticas del local con su marcador
            Local.Estadisticas.RegistrarPartido(GolesLocal, GolesVisitante);

            // Actualizo las estadísticas del visitante invirtiendo los goles
            Visitante.Estadisticas.RegistrarPartido(GolesVisitante, GolesLocal);
        }
    }
}
