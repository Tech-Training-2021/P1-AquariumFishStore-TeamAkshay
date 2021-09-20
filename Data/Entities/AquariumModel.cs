using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Data.Entities
{
    public partial class AquariumModel : DbContext
    {
        public AquariumModel()
            : base("name=AquariumModel")
        {
        }

        public virtual DbSet<cart> carts { get; set; }
        public virtual DbSet<gender> genders { get; set; }
        public virtual DbSet<LocationJunction> LocationJunctions { get; set; }
        public virtual DbSet<LocationTable> LocationTables { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cart>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<gender>()
                .Property(e => e.gender1)
                .IsUnicode(false);

            modelBuilder.Entity<LocationTable>()
                .Property(e => e.Branch)
                .IsUnicode(false);

            modelBuilder.Entity<LocationTable>()
                .HasMany(e => e.carts)
                .WithOptional(e => e.LocationTable)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<LocationTable>()
                .HasMany(e => e.LocationJunctions)
                .WithOptional(e => e.LocationTable)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<LocationTable>()
                .HasMany(e => e.OrderTables)
                .WithOptional(e => e.LocationTable)
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.role1)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone_Number)
                .IsUnicode(false);
        }
    }
}
