using DUNAMIS_SA.Models;
using Microsoft.EntityFrameworkCore;

namespace DUNAMIS_SA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoCliente> TiposDeCliente { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Carga> Carga { get; set; }
        public DbSet<TipoDeCarga> TipoDeCarga { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleDeFactura> DetallesDeFactura { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<TipoImpuesto> TiposDeImpuesto { get; set; }
        public DbSet<Descuento> Descuentos { get; set; }
        public DbSet<TipoDescuento> TiposDeDescuento { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<TipoTelefono> TiposDeTelefono { get; set; }
        public DbSet<Correo> Correos { get; set; }
        public DbSet<TipoCorreo> TiposDeCorreo { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<TipoPago> TiposDePago { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provincia>()
                .HasMany(p => p.Cantones)
                .WithOne(c => c.Provincia)
                .HasForeignKey(c => c.ProvinciaID);

            modelBuilder.Entity<Canton>()
                .HasMany(c => c.Distritos)
                .WithOne(d => d.Canton)
                .HasForeignKey(d => d.CantonID);

            modelBuilder.Entity<Distrito>()
                .HasMany(d => d.Direcciones)
                .WithOne(di => di.Distrito)
                .HasForeignKey(di => di.DistritoID);

            modelBuilder.Entity<Direccion>()
                .HasMany(di => di.Personas)
                .WithOne(p => p.Direccion)
                .HasForeignKey(p => p.DireccionID);

            modelBuilder.Entity<Persona>()
                .HasMany(p => p.Clientes)
                .WithOne(c => c.Persona)
                .HasForeignKey(c => c.Cedula);

            modelBuilder.Entity<Persona>()
                .HasMany(p => p.Usuarios)
                .WithOne(u => u.Persona)
                .HasForeignKey(u => u.Cedula);

            modelBuilder.Entity<TipoCliente>()
                .HasMany(tc => tc.Clientes)
                .WithOne(c => c.TipoCliente)
                .HasForeignKey(c => c.TipoClienteID);

            modelBuilder.Entity<Rol>()
                .HasMany(r => r.Usuarios)
                .WithOne(u => u.Rol)
                .HasForeignKey(u => u.RolID);

            modelBuilder.Entity<TipoDeCarga>()
                .HasMany(tc => tc.Cargas)
                .WithOne(c => c.TipoDeCarga)
                .HasForeignKey(c => c.TipoDeCargaID);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Cargas)
                .WithOne(ca => ca.Cliente)
                .HasForeignKey(ca => ca.ClienteID);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Facturas)
                .WithOne(f => f.Cliente)
                .HasForeignKey(f => f.ClienteID);

            modelBuilder.Entity<Factura>()
                .HasMany(f => f.DetallesDeFactura)
                .WithOne(df => df.Factura)
                .HasForeignKey(df => df.FacturaID);

            modelBuilder.Entity<Impuesto>()
                .HasMany(i => i.DetallesDeFactura)
                .WithOne(df => df.Impuestos)
                .HasForeignKey(df => df.ImpuestoID);

            modelBuilder.Entity<TipoImpuesto>()
                .HasMany(ti => ti.Impuestos)
                .WithOne(i => i.TipoImpuesto)
                .HasForeignKey(i => i.TipoImpuestoID);

            modelBuilder.Entity<Descuento>()
                .HasMany(d => d.DetallesDeFactura)
                .WithOne(df => df.Descuentos)
                .HasForeignKey(df => df.DescuentoID);

            modelBuilder.Entity<TipoDescuento>()
                .HasMany(td => td.Descuentos)
                .WithOne(d => d.TipoDescuento)
                .HasForeignKey(d => d.TipoDescuentoID);

            modelBuilder.Entity<TipoTelefono>()
                .HasMany(tt => tt.Telefonos)
                .WithOne(t => t.TipoTelefono)
                .HasForeignKey(t => t.TipoTelefonoID);

            modelBuilder.Entity<TipoCorreo>()
                .HasMany(tc => tc.Correos)
                .WithOne(c => c.TipoCorreo)
                .HasForeignKey(c => c.TipoCorreoID);

            modelBuilder.Entity<Telefono>()
                .HasMany(t => t.Personas)
                .WithOne(p => p.Telefono)
                .HasForeignKey(p => p.TelefonoID);

            modelBuilder.Entity<Correo>()
                .HasMany(c => c.Personas)
                .WithOne(p => p.Correo)
                .HasForeignKey(p => p.CorreoID);

            modelBuilder.Entity<TipoPago>()
                .HasMany(tp => tp.Pagos)
                .WithOne(p => p.TipoPago)
                .HasForeignKey(p => p.TipoPagoID);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Pago)
                .WithMany(pa => pa.Clientes)
                .HasForeignKey(c => c.PagoID);
        }
    }
}
