using System.Collections.Generic;
using Equipos.dominio;

namespace Equipos.Aplicacion
{
    public interface IEquipoRepositorio
    {
        void Agregar(Equipo Equipo);
        Equipo? ObtenerPorNombre(string Nombre);
        IReadOnlyCollection<Equipo> ObtenerTodos();
    }
}