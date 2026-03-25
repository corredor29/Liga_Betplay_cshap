namespace Equipos.Dominio
{
    // Representa un equipo dentro del torneo
    public class Equipo
    {
        // Nombre del equipo (solo lectura)
        public string Nombre { get; }

        // Estadísticas asociadas a este equipo (partidos, goles, puntos, etc.)
        public EstadisticasEquipo Estadisticas { get; }

        // Al crear un equipo, obligo a que tenga un nombre válido
        public Equipo(string nombre)
        {
            // Valido que el nombre no sea nulo, vacío ni solo espacios
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre del equipo no puede estar vacio");

            // Asigno el nombre y creo el objeto de estadísticas en cero
            Nombre = nombre;
            Estadisticas = new EstadisticasEquipo();
        }
    }
}
