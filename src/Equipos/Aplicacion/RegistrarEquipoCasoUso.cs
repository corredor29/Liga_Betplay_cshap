using Equipos.Dominio;

namespace Equipos.Aplicacion
{
    public class RegistrarEquipoCasoUso
    {
        private readonly IEquipoRepositorio _repoEquipos;

        public RegistrarEquipoCasoUso (IEquipoRepositorio repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }
        public void Ejecutar(string Nombre)
        {
            var EquipoExistente = _repoEquipos.ObtenerPorNombre(Nombre);

            if (EquipoExistente != null)
            {
                throw new Exception("El equipo ya existe");
            }
            var NuevoEquipo = new Equipo(Nombre);
            _repoEquipos.Agregar(NuevoEquipo);
        }
    }
}