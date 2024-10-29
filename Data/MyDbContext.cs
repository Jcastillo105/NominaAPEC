using Microsoft.EntityFrameworkCore;
using NominaAPEC.Models;

namespace NominaAPEC.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<RegistroTransaccion> RegistroTransacciones { get; set; }
        public DbSet<AsientoContable> AsientosContables { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoIngreso> TiposIngreso { get; set; }
        public DbSet<TipoDeduccion> TiposDeduccion { get; set; }
        
    }
}
