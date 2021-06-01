namespace EjerciciosBlazorServer.Data.Tareas
{
    public class Tarea
    {
        public string Name { get; set; }
        public bool Status { get; set; } = false;

        public Tarea(string name)
        { 
            Name = name;
        }
    }
}