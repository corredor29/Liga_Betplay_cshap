using System;
using System.Collections.Generic;
using System.Linq;
using Equipos.Aplicacion;
using Equipos.Dominio;

namespace Equipos.Infraestructura
{
    // Implementación en memoria del repositorio de equipos
    public class RepositorioEquiposMemoria : IEquipoRepositorio
    {
        // Lista interna donde guardo todos los equipos en memoria
        private readonly List<Equipo> _equipos = new();

        // Agrega un equipo nuevo a la lista
        public void Agregar(Equipo equipo)
        {
            // Valido que el equipo no sea nulo
            if (equipo is null)
                throw new ArgumentNullException(nameof(equipo));

            _equipos.Add(equipo);
        }

        // Busca un equipo por nombre, ignorando mayúsculas y minúsculas
        public Equipo? ObtenerPorNombre(string nombre)
        {
            // Si el nombre es vacío o nulo, no busco nada
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            // Devuelvo el primer equipo que coincida por nombre (o null si no existe)
            return _equipos
                .FirstOrDefault(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        // Devuelve todos los equipos registrados como colección de solo lectura
        public IReadOnlyCollection<Equipo> ObtenerTodos()
        {
            return _equipos.AsReadOnly();
        }
    }
}
