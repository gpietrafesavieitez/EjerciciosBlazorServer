using Microsoft.EntityFrameworkCore;

namespace EjerciciosBlazorServer.Data.Organizador
{
    public class Contexto : DbContext
    {
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Paso> Pasos { get; set; }
        public Contexto(DbContextOptions options) : base(options)
        {

        }
    }
}