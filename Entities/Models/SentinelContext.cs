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
        public virtual DbSet<IzinMazeret> IzinMazeret { get; set; }
        public virtual DbSet<Kod> Kod { get; set; }
        public virtual DbSet<KodTip> KodTip { get; set; }
        public virtual DbSet<NobetListesi> NobetListesi { get; set; }
        public virtual DbSet<NobetListesiDetay> NobetListesiDetay { get; set; }
        public virtual DbSet<NobetSistem> NobetSistem { get; set; }
        public virtual DbSet<NobetSistemRutbeIliski> NobetSistemRutbeIliski { get; set; }
        public virtual DbSet<NobetSistemSabitNobetciIliski> NobetSistemSabitNobetciIliski { get; set; }
        public virtual DbSet<NobetSistemSubeIliski> NobetSistemSubeIliski { get; set; }
        public virtual DbSet<OperationClaims> OperationClaims { get; set; }
        public virtual DbSet<OzelGunListesi> OzelGunListesi { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<PersonelNobetDetay> PersonelNobetDetay { get; set; }
        public virtual DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-KVJU9I3\\MSSQLSERVER01;Database=Sentinel;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-V8DP315;Database=Sentinel; Trusted_Connection=true");
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

            modelBuilder.Entity<IzinMazeret>(entity =>
            {
                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.IzinMazeretKod)
                    .WithMany(p => p.IzinMazeret)
                    .HasForeignKey(d => d.IzinMazeretKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzinMazeret_Kod");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.IzinMazeret)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzinMazeret_Personel");
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

            modelBuilder.Entity<NobetListesi>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKaydedenKullaniciId)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.NobetSistem)
                    .WithMany(p => p.NobetListesi)
                    .HasForeignKey(d => d.NobetSistemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetListesi_NobetSistem");
            });

            modelBuilder.Entity<NobetListesiDetay>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Tarih).HasColumnType("datetime");

                entity.HasOne(d => d.NobetListesi)
                    .WithMany(p => p.NobetListesiDetay)
                    .HasForeignKey(d => d.NobetListesiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetListesiDetay_NobetListesi");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.NobetListesiDetay)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetListesiDetay_Personel");

                entity.HasOne(d => d.TurKod)
                    .WithMany(p => p.NobetListesiDetay)
                    .HasForeignKey(d => d.TurKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetListesiDetay_Kod");
            });

            modelBuilder.Entity<NobetSistem>(entity =>
            {
                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HaftaIciGeceSaat).HasMaxLength(11);

                entity.Property(e => e.HaftaIciGunduzSaat)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.HaftaSonuGeceSaat).HasMaxLength(11);

                entity.Property(e => e.HaftaSonuGunduzSaat)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.ResmiTatilGeceSaat).HasMaxLength(11);

                entity.Property(e => e.ResmiTatilGunduzSaat)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<NobetSistemRutbeIliski>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.NobetSistem)
                    .WithMany(p => p.NobetSistemRutbeIliski)
                    .HasForeignKey(d => d.NobetSistemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemRutbeIliski_NobetSistem");

                entity.HasOne(d => d.RutbeKod)
                    .WithMany(p => p.NobetSistemRutbeIliski)
                    .HasForeignKey(d => d.RutbeKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemRutbeIliski_RutbeKod");
            });

            modelBuilder.Entity<NobetSistemSabitNobetciIliski>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.NobetSistem)
                    .WithMany(p => p.NobetSistemSabitNobetciIliski)
                    .HasForeignKey(d => d.NobetSistemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemSabitNobetciIliski_NobetSistem");

                entity.HasOne(d => d.SabitNobetSistemiKod)
                    .WithMany(p => p.NobetSistemSabitNobetciIliski)
                    .HasForeignKey(d => d.SabitNobetSistemiKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemSabitNobetciIliski_Kod");

                entity.HasOne(d => d.SabitPersonel)
                    .WithMany(p => p.NobetSistemSabitNobetciIliski)
                    .HasForeignKey(d => d.SabitPersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemSabitNobetciIliski_SabitPersonel");
            });

            modelBuilder.Entity<NobetSistemSubeIliski>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.NobetSistem)
                    .WithMany(p => p.NobetSistemSubeIliski)
                    .HasForeignKey(d => d.NobetSistemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemSubeIliski_NobetSistem");

                entity.HasOne(d => d.SubeKod)
                    .WithMany(p => p.NobetSistemSubeIliski)
                    .HasForeignKey(d => d.SubeKodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NobetSistemSubeIliski_SubeKod");
            });

            modelBuilder.Entity<OperationClaims>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<OzelGunListesi>(entity =>
            {
                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.OzelGunAdi)
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

            modelBuilder.Entity<PersonelNobetDetay>(entity =>
            {
                entity.Property(e => e.IlkKayitTarihi).HasColumnType("datetime");

                entity.Property(e => e.SonKayitTarihi).HasColumnType("datetime");

                entity.HasOne(d => d.Personel)
                    .WithMany(p => p.PersonelNobetDetay)
                    .HasForeignKey(d => d.PersonelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonelNobetDetay_Personel");
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
