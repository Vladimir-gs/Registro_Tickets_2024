using Microsoft.EntityFrameworkCore;
using Registro_Tickets_2024.Models;

namespace Registro_Tickets_2024.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Prioridades> Prioridades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        public Contexto(DbContextOptions<Contexto> options): base(options) { }
    }
}
