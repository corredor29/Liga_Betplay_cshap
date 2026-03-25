using System.Collections.Generic;
using System.Linq;
using Equipos.Dominio;
using Equipos.Aplicacion;
using TablasPosiciones.Dominio;

namespace TablasPosiciones.Aplicacion
{
    public class ObtenerTablaPosicionesCasoUso
    {
        private readonly IEquipoRepositorio _repoEquipos;

        public ObtenerTablaPosicionesCasoUso(IEquipoRepositorio repoEquipos)
        {
           _repoEquipos = repoEquipos;
        }

        public IEnumerable<FilaTabla> Ejecutar()
        {
            var Equipos = _repoEquipos.ObtenerTodos();

            var Tabla = Equipos
                .Select(e => new FilaTabla(e))
                .OrderByDescending(f => f.Puntos)
                .ThenByDescending(f => f.DiferenciaGol)
                .ThenByDescending(f => f.GolesAFavor)
                .ThenBy(f => f.NombreEquipo);

            return Tabla;
        }
    }
}