using System;
using System.Collections.Generic;
using Mega_Technical_Test_BE_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Mega_Technical_Test_BE_2024.Contexts;

public partial class MegaTechnicalTestDbContext : DbContext
{
    public MegaTechnicalTestDbContext()
    {
    }

    public MegaTechnicalTestDbContext(DbContextOptions<MegaTechnicalTestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MsStorageLocation> MsStorageLocations { get; set; }

    public virtual DbSet<MsUser> MsUsers { get; set; }

    public virtual DbSet<TabelCabang> TabelCabangs { get; set; }

    public virtual DbSet<TabelMotor> TabelMotors { get; set; }

    public virtual DbSet<TabelPembayaran> TabelPembayarans { get; set; }

    public virtual DbSet<TrBpkb> TrBpkbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Mega_Technical_Test_DB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MsStorageLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__ms_stora__771831EAA93E705C");

            entity.ToTable("ms_storage_location");

            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("location_id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("location_name");
        });

        modelBuilder.Entity<MsUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ms_user__B9BE370FA4CF0271");

            entity.ToTable("ms_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<TabelCabang>(entity =>
        {
            entity.HasKey(e => e.KodeCabang).HasName("PK__TabelCab__D63E27FC0E9FB8DE");

            entity.ToTable("TabelCabang");

            entity.Property(e => e.KodeCabang).ValueGeneratedNever();
            entity.Property(e => e.NamaCabang)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabelMotor>(entity =>
        {
            entity.HasKey(e => e.KodeMotor).HasName("PK__TabelMot__FCF067B963E3FD1D");

            entity.ToTable("TabelMotor");

            entity.Property(e => e.KodeMotor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NamaMotor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TabelPembayaran>(entity =>
        {
            entity.HasKey(e => e.NoKontrak).HasName("PK__TabelPem__390E985CE609FC70");

            entity.ToTable("TabelPembayaran");

            entity.Property(e => e.NoKontrak)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.KodeMotor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NoKwitansi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TglBayar).HasColumnType("datetime");
        });

        modelBuilder.Entity<TrBpkb>(entity =>
        {
            entity.HasKey(e => e.AgreementNumber).HasName("PK__tr_bpkb__21912C8025C83ADA");

            entity.ToTable("tr_bpkb");

            entity.Property(e => e.AgreementNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("agreement_number");
            entity.Property(e => e.BpkbDate)
                .HasColumnType("datetime")
                .HasColumnName("bpkb_date");
            entity.Property(e => e.BpkbDateIn)
                .HasColumnType("datetime")
                .HasColumnName("bpkb_date_in");
            entity.Property(e => e.BpkbNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("bpkb_no");
            entity.Property(e => e.BranchId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("branch_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.FakturDate)
                .HasColumnType("datetime")
                .HasColumnName("faktur_date");
            entity.Property(e => e.FakturNo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("faktur_no");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("last_updated_by");
            entity.Property(e => e.LastUpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("last_updated_on");
            entity.Property(e => e.LocationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("location_id");
            entity.Property(e => e.PoliceNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("police_no");

            entity.HasOne(d => d.Location).WithMany(p => p.TrBpkbs)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__tr_bpkb__locatio__2F10007B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
