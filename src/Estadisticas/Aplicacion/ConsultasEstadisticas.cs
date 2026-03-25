using System;
using System.Collections.Generic;
using System.Linq;
using Equipos.Dominio;
using Equipos.Aplicacion;

namespace Estadisticas.Aplicacion
{
    public class ConsultasEstadisticas
    {
        private readonly IEquipoRepositorio _repoEquipos;

        public ConsultasEstadisticas(IEquipoRepositorio repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }
        public Equipo? ObtenerLider()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return null;

            return equipos
                .OrderByDescending(e => e.Estadisticas.Puntos)
                .ThenByDescending(e => e.Estadisticas.DiferenciaGoles)
                .ThenByDescending(e => e.Estadisticas.GolesAFavor)
                .ThenBy(e => e.Nombre)
                .FirstOrDefault();
        }

        public IEnumerable<Equipo> ObtenerEquiposInvictos() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerTop3() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasGolesAFavor() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMenosGolesEnContra() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasGanados() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasEmpates() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasDerrotas() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposSinVictorias() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConDiferenciaGolPositiva() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConPuntosMayoresOIgualesA(int minPuntos) => throw new NotImplementedException();
        public Equipo? BuscarEquipoPorNombre(string nombre) => throw new NotImplementedException();
        public double ObtenerPromedioGolesAFavor() => throw new NotImplementedException();
        public double ObtenerPromedioGolesEnContra() => throw new NotImplementedException();
        public int ObtenerTotalGolesMarcados() => throw new NotImplementedException();
        public int ObtenerTotalPuntosSumados() => throw new NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposPorDebajoDelPromedioPuntos() => throw new NotImplementedException();
    }
}
