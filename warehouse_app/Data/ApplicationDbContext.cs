﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using warehouse_lib.Model;

namespace warehouse_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; } = default!;
        public DbSet<Delivery> Deliveries { get; set; } = default!;
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; } = default!;
        public DbSet<Ion> Ions { get; set; } = default!;
        public DbSet<PackagingType> PackagingTypes { get; set; } = default!;
        public DbSet<WaterType> WaterTypes { get; set; } = default!;
        public DbSet<Water> Waters { get; set; } = default!;
        public DbSet<Sale> Sales { get; set; } = default!;
        public DbSet<SaleDetails> SaleDetails { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if(!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=warehouse.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().HasMany(c => c.Deliveries).WithOne(i => i.Supplier).HasForeignKey(i => i.SupplierId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Company>().HasMany(c => c.Waters).WithOne(i => i.Producer).HasForeignKey(i => i.ProducerId).OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Water>().HasMany(w => w.Cations).WithOne(w => w.CationWater).HasForeignKey(w => w.CationWaterId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Water>().HasMany(w => w.Anions).WithOne(w => w.AnionWater).HasForeignKey(w => w.AnionWaterId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Water>().HasMany(w => w.DeliveryDetails).WithOne(d => d.Water).HasForeignKey(d => d.WaterId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Water>().HasMany(w => w.SaleDetails).WithOne(s => s.Water).HasForeignKey(s => s.WaterId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WaterType>().HasMany(w => w.Waters).WithOne(w => w.Type).HasForeignKey(w => w.TypeId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<PackagingType>().HasMany(p => p.Waters).WithOne(w => w.Packaging).HasForeignKey(w => w.PackagingId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Delivery>().HasMany(d => d.DeliveryDetails).WithOne(d => d.Delivery).HasForeignKey(d => d.DeliveryId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Sale>().HasMany(s => s.SaleDetails).WithOne(s => s.Sale).HasForeignKey(s => s.SaleId).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<warehouse_lib.Model.Anion> Anion { get; set; } = default!;

        public DbSet<warehouse_lib.Model.Cation> Cation { get; set; } = default!;
    }
}