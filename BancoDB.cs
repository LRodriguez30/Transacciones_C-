using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Transacciones_C_.ClasesDB;
using Microsoft.EntityFrameworkCore;

namespace Transacciones_C_
{
    public class BancoDB : DbContext
    {
        // Tablas de la base de datos
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        // Conexión a al base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-JQQ25GV; Database = BancoSimple; Trusted_Connection = true; Encrypt = false; TrustServerCertificate = true;");
        }

        // Definición de filtro Global
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuenta>().HasQueryFilter(c => c.Estado);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaOrigen)
                .WithMany(c => c.TransaccionesOrigen)
                .HasForeignKey(t => t.CuentaOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.CuentaDestino)
                .WithMany(c => c.TransaccionesDestino)
                .HasForeignKey(t => t.CuentaDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
