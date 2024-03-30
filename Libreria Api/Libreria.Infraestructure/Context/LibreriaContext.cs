

using System.Configuration;
using Libreria.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Libreria.Infraestructure.Context
{
    public class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {

        }
        
        public LibreriaContext(DbContextOptions<LibreriaContext> options):base(options) 
        {
           
        }

        public virtual DbSet<Libro> Libros {  get; set; }
        public virtual DbSet<ListaDeLectura> ListaDeLectura { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=odiseo\\ODISEO;Database=Libreria;User Id=odiseo;Password=padomo153;TrustServerCertificate=True;");



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Libro>(entidad =>
            {

                entidad.HasKey(x => x.Id);

                entidad.Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(255);

                entidad.Property(p => p.Genero)
                .HasMaxLength(50);

                entidad.Property(p => p.Autor)
                .IsRequired()
                .HasMaxLength(100);

                entidad.Property(p => p.NumeroPaginas);

                entidad.Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

                entidad.Property(p => p.Descripcion)
                    .HasColumnType("Text");

                entidad.Property(p => p.Portada)
                    .HasColumnType("Text");
                
                
                entidad.HasOne(x => x.Usuarios)
                    .WithMany(x => x.Libros)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasForeignKey(x => x.UsuarioId);

                entidad.HasOne(x => x.ListaDeLecturas)
                    .WithMany(x => x.Libros)
                    .HasForeignKey(x =>x.ListaId)
                    .OnDelete(DeleteBehavior.NoAction);

            });


            modelBuilder.Entity<ListaDeLectura>(entidad =>
            {
                entidad.HasKey(x => x.Id);

                entidad.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(50);


                entidad.HasMany(x => x.Libros)
                    .WithOne(x => x.ListaDeLecturas)
                    .HasForeignKey(x =>x.ListaId);

                entidad.HasOne(l => l.Usuario)
                    .WithMany(u => u.ListaDeLecturas)
                    .HasForeignKey(l => l.UsuarioId);

            });

            modelBuilder.Entity<Usuario>(entidad =>
            {

                entidad.HasKey(x => x.Id);

                entidad.Property(u => u.Nombre)
                .HasMaxLength(50);
                
                entidad.Property(u => u.ImagenUrl)
                    .HasColumnType("TEXT");

                entidad.HasMany(x => x.Libros)
                    .WithOne(x => x.Usuarios).OnDelete(DeleteBehavior.Cascade);

            entidad.HasMany(x => x.ListaDeLecturas)
                .WithOne(x => x.Usuario).OnDelete(DeleteBehavior.Cascade);
            });

       

            base.OnModelCreating(modelBuilder);
        }
    }
}
