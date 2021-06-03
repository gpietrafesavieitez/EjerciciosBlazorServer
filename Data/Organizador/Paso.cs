using System.ComponentModel.DataAnnotations;

namespace EjerciciosBlazorServer.Data.Organizador
{
    public class Paso
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public int Tarea { get; set; }
    }
}
