using System.ComponentModel.DataAnnotations;

namespace EjerciciosBlazorServer.Data.Organizador
{
    public class Tarea
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Estado { get; set; }
        public string Comentario { get; set; }
        [Required]
        public int Lista { get; set; }
    }
}
