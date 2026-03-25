using System;
using System.Collections.Generic;
using System.Linq;
using Equipos.Aplicacion;
using Equipos.Dominio;

namespace Equipos.Infraestructura
{
    public class RepositorioEquiposMemoria : IEquipoRepositorio
    {
        private readonly List<Equipo> _equipos = new();

        public void Agregar(Equipo equipo)
        {
            if (equipo is null)
                throw new ArgumentNullException(nameof(equipo));

            _equipos.Add(equipo);
        }

        public Equipo? ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            return _equipos
                .FirstOrDefault(e => e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public IReadOnlyCollection<Equipo> ObtenerTodos()
        {
            return _equipos.AsReadOnly();
        }
    }
}
