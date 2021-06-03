using System.ComponentModel.DataAnnotations;

namespace EjerciciosBlazorServer.Data.Organizador
{
    public class Lista
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
