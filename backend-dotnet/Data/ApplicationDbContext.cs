using backend_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Segment> Segments { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<SegmentManufacturer> SegmentManufacturers { get; set; }

        public DbSet<SegMfg> SegMfgs { get; set; }

        public DbSet<Component> Components { get; set; }

        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<AlternateComponent> AlternateComponents { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
