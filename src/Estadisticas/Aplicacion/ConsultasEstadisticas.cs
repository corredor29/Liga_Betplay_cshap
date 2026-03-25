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

        // 1. Líder del torneo
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

        // 2. Equipos invictos (PJ > 0 y sin derrotas)
        public IEnumerable<Equipo> ObtenerEquiposInvictos()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            return equipos
                .Where(e => e.Estadisticas.PartidosJugados > 0 &&
                            e.Estadisticas.PartidosPerdidos == 0)
                .OrderByDescending(e => e.Estadisticas.Puntos)
                .ThenByDescending(e => e.Estadisticas.DiferenciaGoles)
                .ThenBy(e => e.Nombre);
        }

        // 3. Top 3 según tabla
        public IEnumerable<Equipo> ObtenerTop3()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            return equipos
                .OrderByDescending(e => e.Estadisticas.Puntos)
                .ThenByDescending(e => e.Estadisticas.DiferenciaGoles)
                .ThenByDescending(e => e.Estadisticas.GolesAFavor)
                .ThenBy(e => e.Nombre)
                .Take(3);
        }

        // 4. Equipos con más goles a favor
        public IEnumerable<Equipo> ObtenerEquiposConMasGolesAFavor()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var maxGoles = equipos.Max(e => e.Estadisticas.GolesAFavor);

            return equipos
                .Where(e => e.Estadisticas.GolesAFavor == maxGoles)
                .OrderBy(e => e.Nombre);
        }

        // 5. Equipos con menos goles en contra
        public IEnumerable<Equipo> ObtenerEquiposConMenosGolesEnContra()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var minGolesContra = equipos.Max(e => e.Estadisticas.GolesEnContra);
            // ojo: si quieres el mínimo real usa Min:
            minGolesContra = equipos.Min(e => e.Estadisticas.GolesEnContra);

            return equipos
                .Where(e => e.Estadisticas.GolesEnContra == minGolesContra)
                .OrderBy(e => e.Nombre);
        }

        // 6. Equipos con más partidos ganados
        public IEnumerable<Equipo> ObtenerEquiposConMasGanados()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var maxGanados = equipos.Max(e => e.Estadisticas.PartidosGanados);

            return equipos
                .Where(e => e.Estadisticas.PartidosGanados == maxGanados)
                .OrderBy(e => e.Nombre);
        }

        // 7. Equipos con más empates
        public IEnumerable<Equipo> ObtenerEquiposConMasEmpates()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var maxEmpates = equipos.Max(e => e.Estadisticas.PartidosEmpatados);

            return equipos
                .Where(e => e.Estadisticas.PartidosEmpatados == maxEmpates)
                .OrderBy(e => e.Nombre);
        }

        // 8. Equipos con más derrotas
        public IEnumerable<Equipo> ObtenerEquiposConMasDerrotas()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var maxDerrotas = equipos.Max(e => e.Estadisticas.PartidosPerdidos);

            return equipos
                .Where(e => e.Estadisticas.PartidosPerdidos == maxDerrotas)
                .OrderBy(e => e.Nombre);
        }

        // 9. Equipos sin victorias
        public IEnumerable<Equipo> ObtenerEquiposSinVictorias()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            return equipos
                .Where(e => e.Estadisticas.PartidosJugados > 0 &&
                            e.Estadisticas.PartidosGanados == 0)
                .OrderByDescending(e => e.Estadisticas.Puntos)
                .ThenBy(e => e.Nombre);
        }

        // 10. Equipos con diferencia de gol positiva
        public IEnumerable<Equipo> ObtenerEquiposConDiferenciaGolPositiva()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            return equipos
                .Where(e => e.Estadisticas.DiferenciaGoles > 0)
                .OrderByDescending(e => e.Estadisticas.DiferenciaGoles)
                .ThenBy(e => e.Nombre);
        }

        // 11. Equipos con puntos >= minPuntos
        public IEnumerable<Equipo> ObtenerEquiposConPuntosMayoresOIgualesA(int minPuntos)
        {
            var equipos = _repoEquipos.ObtenerTodos();

            return equipos
                .Where(e => e.Estadisticas.Puntos >= minPuntos)
                .OrderByDescending(e => e.Estadisticas.Puntos)
                .ThenBy(e => e.Nombre);
        }

        // 12. Buscar equipo por nombre
        public Equipo? BuscarEquipoPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return null;

            return _repoEquipos.ObtenerPorNombre(nombre);
        }

        // 13. Promedio de goles a favor
        public double ObtenerPromedioGolesAFavor()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return 0;

            return equipos.Average(e => e.Estadisticas.GolesAFavor);
        }

        // 14. Promedio de goles en contra
        public double ObtenerPromedioGolesEnContra()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return 0;

            return equipos.Average(e => e.Estadisticas.GolesEnContra);
        }

        // 15. Total de goles marcados en el torneo
        public int ObtenerTotalGolesMarcados()
        {
            var equipos = _repoEquipos.ObtenerTodos();
            return equipos.Sum(e => e.Estadisticas.GolesAFavor);
        }

        // 16. Total de puntos sumados por todos los equipos
        public int ObtenerTotalPuntosSumados()
        {
            var equipos = _repoEquipos.ObtenerTodos();
            return equipos.Sum(e => e.Estadisticas.Puntos);
        }

        // 17. Equipos por debajo del promedio de puntos
        public IEnumerable<Equipo> ObtenerEquiposPorDebajoDelPromedioPuntos()
        {
            var equipos = _repoEquipos.ObtenerTodos();

            if (equipos.Count == 0)
                return Enumerable.Empty<Equipo>();

            var promedio = equipos.Average(e => e.Estadisticas.Puntos);

            return equipos
                .Where(e => e.Estadisticas.Puntos < promedio)
                .OrderBy(e => e.Estadisticas.Puntos)
                .ThenBy(e => e.Nombre);
        }
    }
}
