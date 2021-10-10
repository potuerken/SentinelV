using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class SentinelContext : DbContext
    {
        public SentinelContext()
        {
        }

        public SentinelContext(DbContextOptions<SentinelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HardKod> HardKod { get; set; }
        public virtual DbSet<Kod> Kod { get; set; }
        public virtual DbSet<KodTip> KodTip { get; set; }
        public virtual DbSet<OperationClaims> OperationClaims { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KVJU9I3\\MSSQLSERVER01;Database=Sentinel; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HardKod>(entity =>
            {
                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.UstKod)
                    .WithMany(p => p.InverseUstKod)
                    .HasForeignKey(d => d.UstKodId)
                    .HasConstraintName("FK_HardKodUstKodId_HardKodId");
            });

            modelBuilder.Entity<Kod>(entity =>
            {
                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.KodTip)
                    .WithMany(p => p.Kod)
                    .HasForeignKey(d => d.KodTipId)
                    .HasConstraintName("FK_KodKodTipId_KodTipId");

                entity.HasOne(d => d.UstKod)
                    .WithMany(p => p.InverseUstKod)
                    .HasForeignKey(d => d.UstKodId)
                    .HasConstraintName("FK_KodUstKodId_KodId");
            });

            modelBuilder.Entity<KodTip>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.HardKod)
                    .WithMany(p => p.KodTip)
                    .HasForeignKey(d => d.HardKodId)
                    .HasConstraintName("FK_KodTipHardKodId_HardKodId");

                entity.HasOne(d => d.UstKod)
                    .WithMany(p => p.InverseUstKod)
                    .HasForeignKey(d => d.UstKodId)
                    .HasConstraintName("FK_KodTipUstKodId_KodTipId");
            });

            modelBuilder.Entity<OperationClaims>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BirimBaslamaTarihi).HasColumnType("datetime");

                entity.Property(e => e.CepNo)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Dahili)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Sicil)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tckn)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.YakinCepNo)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.HasOne(d => d.CinsiyetKod)
                    .WithMany(p => p.PersonelCinsiyetKod)
                    .HasForeignKey(d => d.CinsiyetKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personel_CinsiyetKod");

                entity.HasOne(d => d.RutbeKod)
                    .WithMany(p => p.PersonelRutbeKod)
                    .HasForeignKey(d => d.RutbeKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personel_RubetKod");

                entity.HasOne(d => d.SubeKod)
                    .WithMany(p => p.PersonelSubeKod)
                    .HasForeignKey(d => d.SubeKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personel_SubeKod");
            });

            modelBuilder.Entity<UserOperationClaims>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.OperationClaim)
                    .WithMany(p => p.UserOperationClaims)
                    .HasForeignKey(d => d.OperationClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOperationClaims_OperationClaims");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOperationClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserOperationClaims_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash).IsRequired();

                entity.Property(e => e.PasswordSalt).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
