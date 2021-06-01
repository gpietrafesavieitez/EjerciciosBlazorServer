using System;
using System.Collections.Generic;
using EjerciciosBlazorServer.Data.Tareas;

namespace EjerciciosBlazorServer.Pages
{
    public partial class Tareas
    {
        public string Name;
        public List<Tarea> JobList;

        protected override void OnInitialized()
        {
            JobList = new();
        }

        private void NewJob()
        {
            if(!string.IsNullOrWhiteSpace(Name))
            {
                JobList.Add(new Tarea(Name));
                Name = string.Empty;
            }
        }

    }
}
