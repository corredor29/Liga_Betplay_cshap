using System.Collections.Generic;
using Equipos.dominio;

namespace Equipos.Aplicacion
{
    public class ListarEquiposCasoUno
    {
        private readonly IEquipoRepositorio _repoEquipos;
        public ListarEquiposCasoUno(IEquipoRepositorio repoEquipo)
        {
            _repoEquipos = repoEquipo;
        }
        public IReadOnlyCollection<Equipo> Ejecutar()
        {
            return  _repoEquipos.ObtenerTodos();
        }
    }
}