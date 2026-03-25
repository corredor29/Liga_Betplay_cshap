using Equipos.Dominio;

namespace LigaBetPlay.src.Equipos.Aplicacion
{
    public class RegistrarEquipoCasoUso
    {
        private readonly IEquipoRepositorio _repo;

        public RegistrarEquipoCasoUso (IEquipoRepositorio Repo)
        {
            _repo= Repo;
        }
        public void Ejecutar(string Nombre)
        {
            var EquipoExistente = _repo.ObtenerPorNombre(Nombre);

            if (EquipoExistente != null)
            {
                throw new Exception("El equipo ya existe");
            }
            var NuevoEquipo = new Equipo(Nombre);
            _repo.Agregar(NuevoEquipo);
        }
    }
}