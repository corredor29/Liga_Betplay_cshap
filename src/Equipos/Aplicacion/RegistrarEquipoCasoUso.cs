using Equipos.Dominio;

namespace Equipos.Aplicacion
{
    // Caso de uso para registrar un nuevo equipo en el sistema
    public class RegistrarEquipoCasoUso
    {
        // Referencia al repositorio donde se guardan los equipos
        private readonly IEquipoRepositorio _repoEquipos;

        // En el constructor recibo el repositorio que voy a usar
        public RegistrarEquipoCasoUso(IEquipoRepositorio repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }

        // Ejecuta el registro de un equipo a partir de su nombre
        public void Ejecutar(string Nombre)
        {
            // Verifico si ya existe un equipo con ese nombre
            var EquipoExistente = _repoEquipos.ObtenerPorNombre(Nombre);

            if (EquipoExistente != null)
            {
                // Si ya existe, lanzo una excepción para no duplicar equipos
                throw new Exception("El equipo ya existe");
            }

            // Creo la instancia del nuevo equipo con el nombre indicado
            var NuevoEquipo = new Equipo(Nombre);

            // Guardo el nuevo equipo en el repositorio
            _repoEquipos.Agregar(NuevoEquipo);
        }
    }
}
