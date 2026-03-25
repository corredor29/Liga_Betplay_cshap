using System.Collections.Generic;
using Equipos.Dominio;

namespace Equipos.Aplicacion
{
    // Interfaz que define las operaciones básicas para trabajar con equipos
    public interface IEquipoRepositorio
    {
        // Agrega un nuevo equipo al repositorio
        void Agregar(Equipo Equipo);

        // Busca un equipo por su nombre, si no existe devuelve null
        Equipo? ObtenerPorNombre(string Nombre);

        // Devuelve todos los equipos registrados como colección de solo lectura
        IReadOnlyCollection<Equipo> ObtenerTodos();
    }
}
