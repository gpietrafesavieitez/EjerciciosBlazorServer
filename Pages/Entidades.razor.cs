using System.Collections.Generic;
using System.Linq;
using EjerciciosBlazorServer.Data.Entidades;

namespace EjerciciosBlazorServer.Pages
{
    public partial class Entidades
    {
        IList<Persona> Personas;
        IList<Persona> PersonasFiltradas;

        protected override void OnInitialized()
        {
            Personas = new List<Persona>()
            {
                new Persona() { Nombre = "Luis", Edad = 86 },
                new Persona() { Nombre = "Pedro", Edad = 25 },
                new Persona() { Nombre = "María", Edad = 30 },
                new Persona() { Nombre = "Pepe", Edad = 47 },
                new Persona() { Nombre = "Ana", Edad = 15 }
            };
            PersonasFiltradas = Personas;
        }

        private void FiltraPersonas()
        {
            PersonasFiltradas = Personas.Where(miPersona => miPersona.Edad > 18).OrderBy(miPersona => miPersona.Nombre).ToList();
        }
    }
}
