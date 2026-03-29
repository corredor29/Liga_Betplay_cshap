namespace Equipos.Dominio
{
    public class EstadisticasEquipo
    {
        public int PartidosJugados {get; private set;}
        public int PartidosGanados{get; private set;}
        public int PartidosEmpatados{get; private set;}
        public int PartidosPerdidos{get; private set;}
        public int GolesAFavor{get; private set;}
        public int GolesEnContra {get; private set;}
        public int Puntos{get; private set;}

        public int DiferenciaGoles => GolesAFavor - GolesEnContra;
        public void RegistrarPartido(int golesAFavor, int golesEnContra)
        {
            if (golesAFavor < 0 || golesEnContra< 0)
                throw new ArgumentException("Los goles no pueden ser negativos.");
            
            PartidosJugados++;

            GolesAFavor+= golesAFavor;
            GolesEnContra+=golesEnContra;

            if (golesAFavor>golesEnContra)
            {
                PartidosGanados++;
                Puntos += 3;
            }
            else if (golesAFavor == golesEnContra)
            {
                PartidosEmpatados ++;
                Puntos += 1;
            }
            else
            {
                PartidosPerdidos ++;   
            } 

        }
        public void Restaurar(
            int partidosJugados,
            int partidosGanados,
            int partidosEmpatados,
            int partidosPerdidos,
            int golesAFavor,
            int golesEnContra,
            int puntos
        )
        {
            if (partidosJugados < 0 || partidosGanados < 0 || partidosEmpatados < 0 || partidosPerdidos < 0 || golesAFavor < 0 || golesEnContra < 0 || puntos < 0)
                throw new ArgumentException("Los valores no pueden ser negativos.");

            PartidosJugados = partidosJugados;
            PartidosGanados = partidosGanados;
            PartidosEmpatados = partidosEmpatados;
            PartidosPerdidos = partidosPerdidos;
            GolesAFavor = golesAFavor;
            GolesEnContra = golesEnContra;
            Puntos = puntos;
        }
    
    }
}