using Equipos.Aplicacion;
using Equipos.Dominio;
using Partidos.Dominio;

namespace Partidos.Aplicacion
{
    // Caso de uso para simular un partido entre dos equipos y actualizar sus estadísticas
    public class SimularPartidoCasoUso
    {
        // Repositorio desde donde obtengo los equipos por nombre
        private readonly IEquipoRepositorio _repoEquipos;

        // En el constructor recibo el repositorio de equipos que voy a usar
        public SimularPartidoCasoUso(IEquipoRepositorio repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }

        // Ejecuta la simulación del partido con los datos ingresados
        public void Ejecutar(string nombreLocal, string nombreVisitante, int golesLocal, int golesVisitante)
        {
            // Valido que los nombres de los equipos no vengan vacíos o con solo espacios
            if (string.IsNullOrWhiteSpace(nombreLocal) ||
                string.IsNullOrWhiteSpace(nombreVisitante))
                throw new ArgumentException("Los nombres de los equipos no pueden estar vacíos.");

            // Valido que los dos nombres no sean el mismo equipo
            if (nombreLocal.Trim().Equals(nombreVisitante.Trim(), StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Un equipo no puede jugar contra sí mismo.");

            // Valido que los goles no sean negativos
            if (golesLocal < 0 || golesVisitante < 0)
                throw new ArgumentException("Los goles no pueden ser negativos.");

            // Busco el equipo local por nombre en el repositorio
            var local = _repoEquipos.ObtenerPorNombre(nombreLocal);
            if (local is null)
                throw new InvalidOperationException($"No existe el equipo local '{nombreLocal}'.");

            // Busco el equipo visitante por nombre en el repositorio
            var visitante = _repoEquipos.ObtenerPorNombre(nombreVisitante);
            if (visitante is null)
                throw new InvalidOperationException($"No existe el equipo visitante '{nombreVisitante}'.");

            // Creo el partido con los dos equipos y el marcador
            var partido = new Partido(local, visitante, golesLocal, golesVisitante);

            // Aplico el resultado para que se actualicen las estadísticas de ambos equipos
            partido.AplicarResultado();
        }
    }
}
