using DUNAMIS_SA.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace DUNAMIS_SA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cargas> Cargas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<TipoDeCarga> TiposDeCarga { get; set; }
        public DbSet<DetalleDeFactura> DetallesDeFactura { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración adicional de las entidades y relaciones
        }
    }
}
