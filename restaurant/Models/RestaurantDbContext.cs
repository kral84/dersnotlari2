using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace restaurant.Models
{

    public partial class RestaurantDbContext : DbContext
    {
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<Masa> Masalar { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public RestaurantDbContext()
        {
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menu { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-Z3RB8T6\\SQLEXPRESS01;Database=db_restaurant;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aciklama)
                    .HasColumnName("aciklama")
                    .HasMaxLength(255);

                entity.Property(e => e.Fiyat)
                    .HasColumnName("fiyat")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Kategori)
                    .HasColumnName("kategori")
                    .HasMaxLength(50);

                entity.Property(e => e.Stok).HasColumnName("stok");

                entity.Property(e => e.YemekAdi)
                    .IsRequired()
                    .HasColumnName("yemek_adi")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
