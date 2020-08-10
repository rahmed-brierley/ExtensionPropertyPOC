using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Postgres_1.ProductsAndStores;

namespace Postgres_1.ProductsAndStores
{
    public partial class ProductsAndStoresContext : DbContext
    {
        public ProductsAndStoresContext()
        {
        }

        public ProductsAndStoresContext(DbContextOptions<ProductsAndStoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfmigrationHistory> EfmigrationHistory { get; set; }
        public virtual DbSet<ExtensionProperty> ExtensionProperty { get; set; }
        public virtual DbSet<ExtensionPropertyEntity> ExtensionPropertyEntity { get; set; }
        public virtual DbSet<ExtensionPropertySchema> ExtensionPropertySchema { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDefinitions> ProductDefinitions { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreGroup> StoreGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseNpgsql("Host=13.59.22.211;Port=30504;Database=ProductsAndStores;Username=productsadmin;Password=Konastoresandproducts@123");
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ProductsAndStores;Username=postgres;Password=mysecretpassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfmigrationHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationHistory", "stopro");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<ExtensionProperty>(entity =>
            {
                entity.HasKey(e => e.ExtensionPropertyId);

                entity.ToTable("ExtensionProperty", "stopro");

                entity.HasIndex(e => e.ParentExtensionPropertyId);

                entity.Property(e => e.ExtensionPropertyId).HasIdentityOptions(100L, null, null, null, null, null);

                entity.Property(e => e.Alias).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DisplayText).HasMaxLength(50);

                entity.Property(e => e.EncryptionType).HasMaxLength(255);

                entity.Property(e => e.IsDsar).HasColumnName("IsDSAR");

                entity.Property(e => e.IsRtbf).HasColumnName("IsRTBF");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.ParentExtensionProperty)
                    .WithMany(p => p.InverseParentExtensionProperty)
                    .HasForeignKey(d => d.ParentExtensionPropertyId)
                    .HasConstraintName("FK_ExtensionProperty_ExtensionProperty_ParentExtensionProperty~");
            });

            modelBuilder.Entity<ExtensionPropertyEntity>(entity =>
            {
                entity.HasKey(e => e.ExtensionPropertyEntityId);

                entity.ToTable("ExtensionPropertyEntity", "stopro");

                entity.HasIndex(e => e.ExtensionPropertySchemaId);

                entity.Property(e => e.ExtensionPropertyEntityId).HasIdentityOptions(100L, null, null, null, null, null);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.ExtensionPropertySchema)
                    .WithMany(p => p.ExtensionPropertyEntity)
                    .HasForeignKey(d => d.ExtensionPropertySchemaId)
                    .HasConstraintName("FK_ExtensionPropertyEntity_ExtensionPropertySchema_ExtensionPr~");
            });

            modelBuilder.Entity<ExtensionPropertySchema>(entity =>
            {
                entity.HasKey(e => e.ExtensionPropertySchemaId);

                entity.ToTable("ExtensionPropertySchema", "stopro");

                entity.HasIndex(e => e.ExtensionPropertyId);

                entity.Property(e => e.ExtensionPropertySchemaId).HasIdentityOptions(100L, null, null, null, null, null);

                entity.Property(e => e.Alias).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.DisplayText).HasMaxLength(150);

                entity.Property(e => e.JsonSchema).HasColumnType("jsonb");

                entity.Property(e => e.TargetTableName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.ExtensionProperty)
                    .WithMany(p => p.ExtensionPropertySchema)
                    .HasForeignKey(d => d.ExtensionPropertyId)
                    .HasConstraintName("FK_ExtensionPropertySchema_ExtensionProperty_ExtensionProperty~");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Product", "stopro");

                entity.HasIndex(e => e.ExternalId)
                    .IsUnique();

                entity.Property(e => e.ProductId).HasIdentityOptions(1000L, null, null, null, null, null);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.ExtensionProperty).HasColumnType("jsonb");

                entity.Property(e => e.ExternalId).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<ProductDefinitions>(entity =>
            {
                entity.ToTable("ProductDefinitions", "stopro");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(e => e.ProductGroupId);

                entity.ToTable("ProductGroup", "stopro");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.ToTable("Store", "stopro");

                entity.HasIndex(e => e.StoreCode)
                    .IsUnique();

                entity.Property(e => e.StoreId).HasIdentityOptions(1000L, null, null, null, null, null);

                entity.Property(e => e.AddressLineOne).HasMaxLength(150);

                entity.Property(e => e.AddressLineTwo).HasMaxLength(150);

                entity.Property(e => e.BrandStoreNumber).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CloseDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.District).HasMaxLength(50);

                entity.Property(e => e.ExtensionProperty).HasColumnType("jsonb");

                entity.Property(e => e.Latitude).HasMaxLength(20);

                entity.Property(e => e.Longitude).HasMaxLength(20);

                entity.Property(e => e.OpenDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.Property(e => e.StateOrProvince).HasMaxLength(50);

                entity.Property(e => e.StoreName).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Zone).HasMaxLength(50);
            });

            modelBuilder.Entity<StoreGroup>(entity =>
            {
                entity.HasKey(e => e.StoreGroupId);

                entity.ToTable("StoreGroup", "stopro");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
