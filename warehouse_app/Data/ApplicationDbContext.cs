using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

            builder.Entity<Company>().HasMany(c => c.Deliveries).WithOne(i => i.Supplier).HasForeignKey(i => i.SupplierId);
            builder.Entity<Company>().HasMany(c => c.Waters).WithOne(i => i.Producer).HasForeignKey(i => i.ProducerId);
            
            builder.Entity<Water>().HasMany(w => w.Cations).WithOne(w => w.Water).HasForeignKey(w => w.WaterId);
            builder.Entity<Water>().HasMany(w => w.Anions).WithOne(w => w.Water).HasForeignKey(w => w.WaterId);
            builder.Entity<Water>().HasMany(w => w.DeliveryDetails).WithOne(d => d.Water).HasForeignKey(d => d.WaterId);
            builder.Entity<Water>().HasMany(w => w.SaleDetails).WithOne(s => s.Water).HasForeignKey(s => s.WaterId);

            builder.Entity<WaterType>().HasMany(w => w.Waters).WithOne(w => w.Type).HasForeignKey(w => w.TypeId);

            builder.Entity<PackagingType>().HasMany(p => p.Waters).WithOne(w => w.Packaging).HasForeignKey(w => w.PackagingId);

            builder.Entity<Delivery>().HasMany(d => d.DeliveryDetails).WithOne(d => d.Delivery).HasForeignKey(d => d.DeliveryId);

            builder.Entity<Sale>().HasMany(s => s.SaleDetails).WithOne(s => s.Sale).HasForeignKey(s => s.SaleId);

            builder.Entity<Person>().HasMany(p => p.Sales).WithOne(s => s.Customer).HasForeignKey(s => s.CustomerId);
            builder.Entity<Person>().HasMany(p => p.Deliveries).WithOne(d => d.Employee).HasForeignKey(d => d.EmployeeId);
        }
    }
}