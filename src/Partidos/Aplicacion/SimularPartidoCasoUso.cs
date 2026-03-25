using Equipos.Aplicacion;
using Equipos.Dominio;
using Partidos.Dominio;

namespace Partidos.Aplicacion
{
    public class SimularPartidoCasoUso
    {
        private readonly IEquipoRepositorio _repoEquipos;

        public SimularPartidoCasoUso(IEquipoRepositorio repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }

        public void Ejecutar(string nombreLocal, string nombreVisitante, int golesLocal, int golesVisitante)
        {
            if (string.IsNullOrWhiteSpace(nombreLocal) ||
                string.IsNullOrWhiteSpace(nombreVisitante))
                throw new ArgumentException("Los nombres de los equipos no pueden estar vacíos.");

            if (nombreLocal.Trim().Equals(nombreVisitante.Trim(), StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Un equipo no puede jugar contra sí mismo.");

            if (golesLocal < 0 || golesVisitante < 0)
                throw new ArgumentException("Los goles no pueden ser negativos.");

            var local = _repoEquipos.ObtenerPorNombre(nombreLocal);
            if (local is null)
                throw new InvalidOperationException($"No existe el equipo local '{nombreLocal}'.");

            var visitante = _repoEquipos.ObtenerPorNombre(nombreVisitante);
            if (visitante is null)
                throw new InvalidOperationException($"No existe el equipo visitante '{nombreVisitante}'.");

            var partido = new Partido(local, visitante, golesLocal, golesVisitante);
            partido.AplicarResultado();
        }
    }
}

