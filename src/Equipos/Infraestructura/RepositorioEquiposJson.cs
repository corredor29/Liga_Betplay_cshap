using System.Text.Json;
using Equipos.Aplicacion;
using Equipos.Dominio;

namespace Equipos.Infraestructura;

public class RepositorioEquiposJson : IEquipoRepositorio
{
    private readonly string _rutaArchivo;
    private readonly List<Equipo> _equipos = new();

    public RepositorioEquiposJson(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
        CargarDesdeArchivo();
    }

    public void Agregar(Equipo equipo)
    {
        if (equipo is null) throw new ArgumentNullException(nameof(equipo));
        _equipos.Add(equipo);
        GuardarEnArchivo();
    }

    public Equipo? ObtenerPorNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre)) return null;
        return _equipos.FirstOrDefault(e =>
            e.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyCollection<Equipo> ObtenerTodos() => _equipos.AsReadOnly();

    private void CargarDesdeArchivo()
    {
        if (!File.Exists(_rutaArchivo)) return;

        var json = File.ReadAllText(_rutaArchivo);
        var dtos = JsonSerializer.Deserialize<List<EquipoDto>>(json);
        if (dtos is null) return;

        foreach (var dto in dtos)
        {
            var equipo = new Equipo(dto.Nombre);
            equipo.Estadisticas.Restaurar(
                dto.PartidosJugados,
                dto.PartidosGanados,
                dto.PartidosEmpatados,
                dto.PartidosPerdidos,
                dto.GolesAFavor,
                dto.GolesEnContra,
                dto.Puntos
            );
            _equipos.Add(equipo);
        }
    }

    private void GuardarEnArchivo()
    {
        var dtos = _equipos.Select(e => new EquipoDto
        {
            Nombre            = e.Nombre,
            PartidosJugados   = e.Estadisticas.PartidosJugados,
            PartidosGanados   = e.Estadisticas.PartidosGanados,
            PartidosEmpatados = e.Estadisticas.PartidosEmpatados,
            PartidosPerdidos  = e.Estadisticas.PartidosPerdidos,
            GolesAFavor       = e.Estadisticas.GolesAFavor,
            GolesEnContra     = e.Estadisticas.GolesEnContra,
            Puntos            = e.Estadisticas.Puntos
        }).ToList();

        var opciones = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(_rutaArchivo, JsonSerializer.Serialize(dtos, opciones));
    }
}