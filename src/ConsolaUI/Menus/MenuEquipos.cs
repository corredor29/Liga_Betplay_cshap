using System;
using Equipos.Aplicacion;

namespace ConsolaUI.Menus
{
    public class MenuEquipos
    {
        private readonly RegistrarEquipoCasoUso _registrar;
        private readonly ListarEquiposCasoUno _listar;

        public MenuEquipos(RegistrarEquipoCasoUso Registrar, ListarEquiposCasoUno Listar)
        {
            _registrar= Registrar;
            _listar = Listar;
        }

        public void MostrarRegistro()
        {
            Console.Clear();
            Console.WriteLine(@"                 _     _                                     _                 
                _ __ ___  __ _(_)___| |_ _ __ __ _ _ __    ___  __ _ _   _(_)_ __   ___  ___ 
                | '__/ _ \/ _` | / __| __| '__/ _` | '__|  / _ \/ _` | | | | | '_ \ / _ \/ __|
                | | |  __/ (_| | \__ \ |_| | | (_| | |    |  __/ (_| | |_| | | |_) | (_) \__ \
                |_|  \___|\__, |_|___/\__|_|  \__,_|_|     \___|\__, |\__,_|_| .__/ \___/|___/
                        |___/                                    |_|       |_|              ");
            Console.WriteLine("Ingrese el nombre del equipo:");
            string Nombre = Console.ReadLine()??"";

            try
            {
                _registrar.Ejecutar(Nombre);
                Console.WriteLine("Equipo registrado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void MostrarListado()
        {
            var Equipos = _listar.Ejecutar();
            Console.WriteLine("Listado de equipos");

            foreach (var Equipo in Equipos)
            {
                Console.WriteLine($"-{Equipo.Nombre}");
            }
        }
    }
}