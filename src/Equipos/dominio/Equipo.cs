namespace Equipos.Dominio
{
    public class Equipo
    {
        public string Nombre {get;}
        public EstadisticasEquipo Estadisticas {get;}

        public Equipo(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del equipo no puede estar vacio");
            Nombre = nombre;
            Estadisticas = new EstadisticasEquipo();
        }
    }
}