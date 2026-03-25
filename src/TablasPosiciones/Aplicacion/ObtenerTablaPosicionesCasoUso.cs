using System.Collections.Generic;
using System.Linq;
using Equipos.Dominio;
using Equipos.Aplicacion;
using TablasPosiciones.Dominio;

namespace TablasPosiciones.Aplicacion
{
    // Caso de uso que construye la tabla de posiciones a partir de los equipos
    public class ObtenerTablaPosicionesCasoUso
    {
        // Repositorio desde donde obtengo todos los equipos con sus estadísticas
        private readonly IEquipoRepositorio _repoEquipos;

        // En el constructor recibo el repositorio de equipos
        public ObtenerTablaPosicionesCasoUso(IEquipoRepositorio repoEquipos)
        {
           _repoEquipos = repoEquipos;
        }

        // Genera la tabla de posiciones ordenada según los criterios del torneo
        public IEnumerable<FilaTabla> Ejecutar()
        {
            // Traigo todos los equipos registrados
            var Equipos = _repoEquipos.ObtenerTodos();

            // Proyección a FilaTabla y orden por:
            // 1. Puntos (desc), 2. DG (desc), 3. GF (desc), 4. Nombre (asc)
            var Tabla = Equipos
                .Select(e => new FilaTabla(e))
                .OrderByDescending(f => f.Puntos)
                .ThenByDescending(f => f.DiferenciaGol)
                .ThenByDescending(f => f.GolesAFavor)
                .ThenBy(f => f.NombreEquipo);

            // Devuelvo la tabla ya ordenada
            return Tabla;
        }
    }
}
