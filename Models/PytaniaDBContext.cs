using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ztp_projekt.Models
{
    public partial class PytaniaDBContext : DbContext
    {
        private static PytaniaDBContext Context;
        private PytaniaDBContext()
        {
            
        }

        public static PytaniaDBContext GetDBContext()
        {
            if (Context == null)
                Context = new PytaniaDBContext();
            return Context;
        }

        public virtual DbSet<Pytania> Pytania { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                var connectionString = $"Filename = {Path.Combine(Directory.GetCurrentDirectory(), "Database.sqlite")}";
                optionsBuilder.UseSqlite(connectionString);
                //optionsBuilder.UseSqlServer("Server=DESKTOP-L9K0VTG;Database=PytaniaDB;User Id=PytaniaAlpha;Password=zaq1@WSX;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pytania>(entity =>
            {
                entity.HasKey(e => e.IdPytania);

                entity.ToTable("Pytania", "dbo");

                entity.Property(e => e.IdPytania)
                    .HasColumnName("ID_Pytania")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BlednaOdpAngielski1)
                    .HasColumnName("Bledna_Odp_Angielski1")
                    .HasMaxLength(100);

                entity.Property(e => e.BlednaOdpAngielski2)
                    .HasColumnName("Bledna_Odp_Angielski2")
                    .HasMaxLength(100);

                entity.Property(e => e.BlednaOdpAngielski3)
                    .HasColumnName("Bledna_Odp_Angielski3")
                    .HasMaxLength(100);

                entity.Property(e => e.BlednaOdpPolski1)
                    .HasColumnName("Bledna_Odp_Polski1")
                    .HasMaxLength(100);

                entity.Property(e => e.BlednaOdpPolski2)
                    .HasColumnName("Bledna_Odp_Polski2")
                    .HasMaxLength(100);

                entity.Property(e => e.BlednaOdpPolski3)
                    .HasColumnName("Bledna_Odp_Polski3")
                    .HasMaxLength(100);

                entity.Property(e => e.OdpowiedzAngielski)
                    .IsRequired()
                    .HasColumnName("Odpowiedz_Angielski")
                    .HasMaxLength(100);

                entity.Property(e => e.OdpowiedzPolski)
                    .IsRequired()
                    .HasColumnName("Odpowiedz_Polski")
                    .HasMaxLength(100);

                entity.Property(e => e.TrescAngielski)
                    .IsRequired()
                    .HasColumnName("Tresc_Angielski")
                    .HasMaxLength(100);

                entity.Property(e => e.TrescPolski)
                    .IsRequired()
                    .HasColumnName("Tresc_Polski")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
