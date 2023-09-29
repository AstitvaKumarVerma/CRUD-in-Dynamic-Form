using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DF_Project_APIs.Models
{
    public partial class sdirectdbContext : DbContext
    {
        public sdirectdbContext()
        {
        }

        public sdirectdbContext(DbContextOptions<sdirectdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AstitvaAccountHolderTable> AstitvaAccountHolderTables { get; set; } = null!;
        public virtual DbSet<AstitvaNomineeTable> AstitvaNomineeTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.240;Database=sdirectdb;User ID=sdirectdb;Password=sdirectdb;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AstitvaAccountHolderTable>(entity =>
            {
                entity.HasKey(e => e.AccountholderId)
                    .HasName("PK__Astitva___DDBD376AEC91D394");

                entity.ToTable("Astitva_AccountHolderTable");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountholderName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AstitvaNomineeTable>(entity =>
            {
                entity.HasKey(e => e.NomineeId)
                    .HasName("PK__Astitva___40B5EA162005002A");

                entity.ToTable("Astitva_NomineeTable");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.NomineeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountHolder)
                    .WithMany(p => p.AstitvaNomineeTables)
                    .HasForeignKey(d => d.AccountHolderId)
                    .HasConstraintName("FK__Astitva_N__Accou__58946657");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
