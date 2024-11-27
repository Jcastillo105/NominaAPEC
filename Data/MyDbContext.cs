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

        // Método para mapear los nombres de las tablas en la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroTransaccion>().ToTable("registrotransacciones");
            modelBuilder.Entity<AsientoContable>().ToTable("asientoscontables");
            modelBuilder.Entity<Empleado>().ToTable("empleados");
            modelBuilder.Entity<TipoIngreso>().ToTable("tiposingreso");
            modelBuilder.Entity<TipoDeduccion>().ToTable("tiposdeduccion");

            base.OnModelCreating(modelBuilder);
        }
    }
}
