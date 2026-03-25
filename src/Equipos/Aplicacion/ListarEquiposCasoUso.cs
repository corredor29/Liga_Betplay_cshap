using System.Collections.Generic;
using Equipos.Dominio;

namespace Equipos.Aplicacion
{
    // Caso de uso para listar todos los equipos registrados en el sistema
    public class ListarEquiposCasoUno
    {
        // Referencia al repositorio de equipos desde donde voy a leer los datos
        private readonly IEquipoRepositorio _repoEquipos;

        // En el constructor recibo el repositorio que usaré para obtener los equipos
        public ListarEquiposCasoUno(IEquipoRepositorio repoEquipo)
        {
            _repoEquipos = repoEquipo;
        }

        // Ejecuta el caso de uso y devuelve todos los equipos como colección de solo lectura
        public IReadOnlyCollection<Equipo> Ejecutar()
        {
            return _repoEquipos.ObtenerTodos();
        }
    }
}
