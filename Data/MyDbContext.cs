using Microsoft.EntityFrameworkCore;
using NominaAPEC.Models;

namespace NominaAPEC.Data // Asegúrate de usar el namespace correcto
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // DbSet de las entidades
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<TipoIngreso> TiposIngreso { get; set; }
        public DbSet<TipoDeduccion> TiposDeduccion { get; set; }
        public DbSet<RegistroTransaccion> RegistroTransacciones { get; set; }
        public DbSet<AsientoContable> AsientosContables { get; set; }
    }
}
