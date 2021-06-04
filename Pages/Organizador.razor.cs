using System.Collections.Generic;
using System.Linq;
using EjerciciosBlazorServer.Data.Organizador;

namespace EjerciciosBlazorServer.Pages
{
    public partial class Organizador
    {
        public Lista MiLista { get; set; }
        public Tarea MiTarea { get; set; }
        public Paso MiPaso { get; set; }
        public List<Lista> MisListas { get; set; }
        public List<Tarea> MisTareas { get; set; }
        public List<Paso> MisPasos { get; set; }
        public int ListaActual { get; set; }
        public int TareaActual { get; set; }

        private string Comentario;

        protected override void OnInitialized()
        {
            MiLista = new();
            MiTarea = new();
            MiPaso = new();
            CargarListas();
        }

        private void GuardarLista()
        {
            Contexto.Listas.Add(MiLista);
            Contexto.SaveChanges();
            MiLista = new();
            CargarListas();
        }

        private void CargarListas()
        {
            MisListas = Contexto.Listas.ToList();
            MisPasos = null;
        }

        private void EditarLista(string nombre)
        {
            var entidad = Contexto.Listas.SingleOrDefault(lista => lista.Id == ListaActual);
            if (entidad.Nombre != null)
            {
                entidad.Nombre = nombre;
            }
            Contexto.SaveChanges();
        }

        private void BorrarLista(Lista miLista)
        {
            Contexto.Listas.Remove(miLista);
            Contexto.Tareas.RemoveRange(Contexto.Tareas.Where(tarea => tarea.Lista == miLista.Id));
            List<int> TareasID = Contexto.Tareas
                .Where(tarea => tarea.Lista == miLista.Id)
                .Select(tarea => tarea.Id)
                .ToList();
            foreach (var id in TareasID)
            {
                Contexto.Pasos
                    .RemoveRange(Contexto.Pasos
                    .Where(paso => paso.Tarea == id));
            }
            Contexto.SaveChanges();
            CargarListas();
            MisTareas = null;
        }

        private void GuardarTarea()
        {
            bool existe = Contexto.Listas.Where(lista => lista.Id == ListaActual).Count() > 0;
            if (existe)
            {
                MiTarea.Lista = ListaActual;
                MiTarea.Comentario = "";
                Contexto.Tareas.Add(MiTarea);
                Contexto.SaveChanges();
                MiTarea = new();
                CargarTareas(ListaActual);
            }
        }

        private void CargarTareas(int listaId)
        {
            ListaActual = listaId;
            MisTareas = Contexto.Tareas
                .Where(tarea => tarea.Lista == ListaActual)
                .ToList();
            MisPasos = null;
        }

        private void BorrarTarea(Tarea miTarea)
        {
            Contexto.Tareas.Remove(miTarea);
            Contexto.Pasos
                .RemoveRange(Contexto.Pasos
                .Where(paso => paso.Tarea == miTarea.Id));
            Contexto.SaveChanges();
            CargarTareas(ListaActual);
            MisPasos = null;
        }

        private void CambiarEstadoTarea(int idTarea)
        {
            var entidad = Contexto.Tareas.SingleOrDefault(tarea => tarea.Id == idTarea);
            if (entidad.Estado)
            {
                entidad.Estado = false;
            }
            else
            {
                entidad.Estado = true;
            }
            Contexto.SaveChanges();
        }

        private void GuardarPaso()
        {
            bool existe = Contexto.Tareas
                .Where(tarea => tarea.Id == TareaActual)
                .Count() > 0;
            if (existe)
            {
                MiPaso.Tarea = TareaActual;
                Contexto.Pasos.Add(MiPaso);
                Contexto.SaveChanges();
                MiPaso = new();
                CargarPasos(TareaActual);
            }
        }

        private void CargarPasos(int tareaId)
        {
            TareaActual = tareaId;
            MisPasos = Contexto.Pasos
                .Where(paso => paso.Tarea == TareaActual)
                .ToList();
            CargarComentario();
        }

        private void BorrarPaso(Paso miPaso)
        {
            Contexto.Pasos.Remove(miPaso);
            Contexto.SaveChanges();
            CargarPasos(TareaActual);
        }

        private void CambiarEstadoPaso(int idPaso)
        {
            var entidad = Contexto.Pasos.SingleOrDefault(paso => paso.Id == idPaso);
            if (entidad.Estado)
            {
                entidad.Estado = false;
            }
            else
            {
                entidad.Estado = true;
            }
            Contexto.SaveChanges();
        }

        private void EditarTarea(string nombre)
        {
            var entidad = Contexto.Tareas.SingleOrDefault(tarea => tarea.Id == TareaActual);
            if (entidad.Nombre != null)
            {
                entidad.Nombre = nombre;
            }
            Contexto.SaveChanges();
        }

        private void CargarComentario()
        {
            Comentario = Contexto.Tareas.SingleOrDefault(tarea => tarea.Id == TareaActual).Comentario;
        }

        private void EditarComentario(string texto)
        { 
            var entidad = Contexto.Tareas.SingleOrDefault(tarea => tarea.Id == TareaActual);
            entidad.Comentario = texto;
            Contexto.SaveChanges();
            CargarComentario();
        }
        
    }
}