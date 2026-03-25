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
    }
}