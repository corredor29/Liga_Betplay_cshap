using System.Collections.Generic;
using Equipos.Dominio;

namespace LigaBetPlay.src.Equipos.Aplicacion
{
    public interface IEquipoRepositorio
    {
        void Agregar(Equipo Equipo);
        Equipo? ObtenerPorNombre(string Nombre);
        IReadOnlyCollection<Equipo> ObtenerTodos();
    }
}