using System.Collections.Generic;
using Equipos.dominio;      
using Equipos.Aplicacion;  

namespace EstadisticasAplicacion
{
    public class ConsultasEstadisticas
    {
        private readonly IEquipoRepositorio _repoEquipos;

        public ConsultasEstadisticas(IEquipoRepositorio _repoEquipos)
        {
            _repoEquipos = repoEquipos;
        }
        public Equipo? ObtenerLider() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposInvictos() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerTop3() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasGolesAFavor() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMenosGolesEnContra() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasGanados() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasEmpates() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConMasDerrotas() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposSinVictorias() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConDiferenciaGolPositiva() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposConPuntosMayoresOIgualesA(int minPuntos) => throw new System.NotImplementedException();
        public Equipo? BuscarEquipoPorNombre(string nombre) => throw new System.NotImplementedException();
        public double ObtenerPromedioGolesAFavor() => throw new System.NotImplementedException();
        public double ObtenerPromedioGolesEnContra() => throw new System.NotImplementedException();
        public int ObtenerTotalGolesMarcados() => throw new System.NotImplementedException();
        public int ObtenerTotalPuntosSumados() => throw new System.NotImplementedException();
        public IEnumerable<Equipo> ObtenerEquiposPorDebajoDelPromedioPuntos() => throw new System.NotImplementedException();
    }
}
