using Microsoft.EntityFrameworkCore;
using AMVA.REDRIO.Models;

namespace AMVA.REDRIO.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<TipoFase> TipoFases { get; set; }
        public DbSet<Fase> Fases { get; set; }
        public DbSet<Campaña> Campañas { get; set; }
        public DbSet<ResultadoCampo> ResultadoCampos { get; set; }
        public DbSet<ReportesLaboratorio> ReportesLaboratorios { get; set; }
        public DbSet<Estacion> Estaciones { get; set; }
        public DbSet<Quimico> Quimicos { get; set; }
        public DbSet<Insitu> Insitus { get; set; }
        public DbSet<Fisico> Fisicos { get; set; }
        public DbSet<MetalAgua> MetalAguas { get; set; }
        public DbSet<Biologico> Biologicos { get; set; }
        public DbSet<Nutriente> Nutrientes { get; set; }

        public DbSet<MetalSedimental> MetalSedimentales { get; set; }
        public DbSet<HistorialExcel> HistorialExceles { get; set; }
        public DbSet <MuestraCompuesta> MuestraCompuestas { get; internal set; }
        public DbSet <TipoFuente> TipoFuentes { get; internal set; }
        public DbSet <Documento> Documentos { get; internal set; }
        public DbSet <DocsCampaña> DocsCampañas { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación entre ReportesLaboratorio y Campaña y Estacion
            modelBuilder.Entity<ReportesLaboratorio>()
                .HasOne(r => r.Campaña)
                .WithMany()
                .HasForeignKey(r => r.IdCampaña)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<ReportesLaboratorio>()
                .HasOne(r => r.ResultadoCampo)
                .WithMany()
                .HasForeignKey(r => r.IdResultadoCampo)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<ReportesLaboratorio>()
                .HasOne(r => r.Estacion)
                .WithMany()
                .HasForeignKey(r => r.IdEstacion)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            modelBuilder.Entity<ReportesLaboratorio>()
                .HasOne(r => r.MuestraCompuesta)
                .WithMany()
                .HasForeignKey(r => r.IdMuestraCompuesta)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Quimico)
                .WithMany()
                .HasForeignKey(r => r.IdQuimico)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Insitu)
                .WithMany()
                .HasForeignKey(r => r.IdInsitu)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Fisico)
                .WithMany()
                .HasForeignKey(r => r.IdFisico)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Quimico)
                .WithMany()
                .HasForeignKey(r => r.IdQuimico)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.MetalAgua)
                .WithMany()
                .HasForeignKey(r => r.IdMetalAgua)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Biologico)
                .WithMany()
                .HasForeignKey(r => r.IdBiologico)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
                
            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.Nutriente)
                .WithMany()
                .HasForeignKey(r => r.IdNutriente)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<MuestraCompuesta>()
                .HasOne(r => r.MetalSedimental)
                .WithMany()
                .HasForeignKey(r => r.IdMetalSedimental)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);


            // Configuración de la relación entre Campaña y Fase
            modelBuilder.Entity<Campaña>()
                .HasOne(c => c.Fase)
                .WithMany()
                .HasForeignKey(c => c.IdFase)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<Campaña>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            // Configuración de la relación entre Municipio y Departamento
            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Departamento)
                .WithMany()
                .HasForeignKey(m => m.Id_Departamento)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            // Configuracion de la relacion entre estacion y municipio
             modelBuilder.Entity<Estacion>()
                .HasOne(m => m.Municipio)
                .WithMany()
                .HasForeignKey(m => m.IdMunicipio)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);// Configuracion de la relacion entre estacion y TipoFuente
             modelBuilder.Entity<Estacion>()
                .HasOne(m => m.TipoFuente)
                .WithMany()
                .HasForeignKey(m => m.IdTipoFuente)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            // Configuracion de la relacion entre fase y tipo fase
            modelBuilder.Entity<Fase>()
                .HasOne(m => m.TipoFase)
                .WithMany()
                .HasForeignKey(m => m.IdTipoFase)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            // Configuracion de la relacion entre HistorialExcel y campaña
            modelBuilder.Entity<HistorialExcel>()
                .HasOne(m => m.Campaña)
                .WithMany()
                .HasForeignKey(m => m.IdCampaña)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false); 
            //Configuracion de la relacion entre DocsCampaña y campaña
            modelBuilder.Entity<DocsCampaña>()
                .HasOne(m => m.Campaña)
                .WithMany()
                .HasForeignKey(m => m.IdCampaña)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            //Configuracion de la relacion entre DocsCampaña y Documentos 
             modelBuilder.Entity<DocsCampaña>()
                .HasOne(m => m.Documento)
                .WithMany()
                .HasForeignKey(m => m.Id_Documento)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
           
           
        }
    }
}
