using System.Collections.Generic;
using Equipos.Dominio;

namespace LigaBetPlay.src.Equipos.Aplicacion
{
    public class ListarEquiposCasoUno
    {
        private readonly IEquipoRepositorio _repo;
        public ListarEquiposCasoUno(IEquipoRepositorio Repo)
        {
            _repo = Repo;
        }
        public IReadOnlyCollection<Equipo> Ejecutar()
        {
            return _repo.ObtenerTodos();
        }
    }
}