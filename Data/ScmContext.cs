using IdentityServer4.EntityFramework.Options;
using Scm.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Scm.Data
{
    public class ScmContext : DbContext
    {
        public DbSet <Estudiantes> Estudiantes {get; set;}
        public DbSet <User> users{get; set;}
        public DbSet <Maestros> maestros{get; set;}
        public DbSet <Horarios> horarios{get; set;}
        public DbSet <Materias> materias{get; set;}
        public ScmContext(DbContextOptions<ScmContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //put mappings database here
            builder.Entity<User>(x=>{
                x.HasKey(x=>x.email);
                x.Property(x=>x.password).HasMaxLength(200).IsRequired();
                x.Property(x=>x.name).HasMaxLength(200).IsRequired();
                x.Property(x=>x.lastName).HasMaxLength(200).IsRequired();
                x.Property(x=>x.role).HasMaxLength(200).IsRequired();
            });
            builder.Entity<Estudiantes>(x=>{
                x.HasKey(x=>x.IdEstudiantes);
                x.Property(x=>x.IdEstudiantes).ValueGeneratedOnAdd();
                x.Property(x=>x.Nombre).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Apellido1).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Apellido2).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Edad).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Genero).HasMaxLength(200);
            });
            builder.Entity<Maestros>(x=>{
                x.HasKey(x=>x.Rfc);
                x.Property(x=>x.Nombres).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Apellidos).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Email).HasMaxLength(200).IsRequired();
                x.HasMany(x=>x.Horarios);
            });
            builder.Entity<Horarios>(x=>{
                x.HasKey(x=>x.Clave);
                x.Property(x=>x.Dias).HasMaxLength(200).IsRequired();
                x.Property(x=>x.Salon).HasMaxLength(200).IsRequired();
                x.HasOne(x=>x.Materias).WithMany().HasForeignKey(x=>x.Materia);
            });
            builder.Entity<Materias>(x=>{
                x.HasKey(x=>x.Materia);
            });
            base.OnModelCreating(builder);
        }
    }
}