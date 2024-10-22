using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Infrastructure.BaseDbContext
{
    public partial class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {
        }

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RealEstate.Domain.Entities.Property> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealEstate.Domain.Entities.Property>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");
                entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
