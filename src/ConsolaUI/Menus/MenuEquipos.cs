using System;
using Equipos.Aplicacion;

namespace ConsolaUI.Menus
{
    // Menú para gestionar todo lo relacionado con equipos (registrar y listar)
    public class MenuEquipos
    {
        // Caso de uso para registrar un nuevo equipo
        private readonly RegistrarEquipoCasoUso _registrar;

        // Caso de uso para listar todos los equipos registrados
        private readonly ListarEquiposCasoUno _listar;

        // En el constructor recibo los casos de uso que necesito para este menú
        public MenuEquipos(RegistrarEquipoCasoUso registrar, ListarEquiposCasoUno listar)
        {
            _registrar = registrar;
            _listar = listar;
        }

        // Muestra la pantalla para registrar un nuevo equipo
        public void MostrarRegistro()
        {
            // Limpio la consola antes de mostrar el formulario
            Console.Clear();

            // Título decorativo del módulo de registro de equipos
            Console.WriteLine(@"                 _     _                                     _                 
                _ __ ___  __ _(_)___| |_ _ __ __ _ _ __    ___  __ _ _   _(_)_ __   ___  ___ 
                | '__/ _ \/ _` | / __| __| '__/ _` | '__|  / _ \/ _` | | | | | '_ \ / _ \/ __|
                | | |  __/ (_| | \__ \ |_| | | (_| | |    |  __/ (_| | |_| | | |_) | (_) \__ \
                |_|  \___|\__, |_|___/\__|_|  \__,_|_|     \___|\__, |\__,_|_| .__/ \___/|___/
                        |___/                                    |_|       |_|              ");

            // Pido al usuario el nombre del equipo a registrar
            Console.WriteLine("Ingrese el nombre del equipo:");
            var nombre = Console.ReadLine() ?? string.Empty;

            try
            {
                // Llamo al caso de uso que se encarga de registrar el equipo
                _registrar.Ejecutar(nombre);
                Console.WriteLine("Equipo registrado correctamente");
            }
            catch (Exception ex)
            {
                // Si algo sale mal muestro el mensaje de error
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Pausa para que el usuario pueda leer el resultado
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }

        // Muestra la lista de equipos registrados
        public void MostrarListado()
        {
            // Limpio la consola antes de mostrar el listado
            Console.Clear();
            Console.WriteLine("=== Lista de equipos ===");

            // Obtengo todos los equipos usando el caso de uso de listado
            var equipos = _listar.Ejecutar();

            // Si no hay equipos registrados informo al usuario
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                // Recorro la lista y muestro el nombre de cada equipo
                foreach (var equipo in equipos)
                {
                    Console.WriteLine($"- {equipo.Nombre}");
                }
            }

            // Pausa para que el usuario pueda revisar el listado
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
