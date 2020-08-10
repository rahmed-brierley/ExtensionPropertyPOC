using Microsoft.EntityFrameworkCore;

namespace Postgres_1.ExProp
{
    public partial class CommunicationsContext : DbContext
    {
        public CommunicationsContext()
        {
        }

        public CommunicationsContext(DbContextOptions<CommunicationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfmigrationHistory> EfmigrationHistory { get; set; }
        public virtual DbSet<EmailAttributeSet> EmailAttributeSet { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<ExtensionProperty> ExtensionProperty { get; set; }
        public virtual DbSet<ExtensionPropertySchema> ExtensionPropertySchema { get; set; }
        public virtual DbSet<LoyaltyMessageTemplate> LoyaltyMessageTemplate { get; set; }
        public virtual DbSet<PushNotificationTemplate> PushNotificationTemplate { get; set; }
        public virtual DbSet<SmsTemplate> SmsTemplate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=13.59.22.211;Port=30501;Database=Communications;Username=communicationadmin;Password=Konacommunication@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfmigrationHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationHistory", "com");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<EmailAttributeSet>(entity =>
            {
                entity.HasKey(e => e.EmailAttributeSetId);

                entity.ToTable("EmailAttributeSet", "com");

                entity.HasIndex(e => e.EmailTemplateId);

                entity.Property(e => e.EmailAttributeSetId).HasIdentityOptions(1000L, null, null, null, null, null);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.EmailTemplate)
                    .WithMany(p => p.EmailAttributeSet)
                    .HasForeignKey(d => d.EmailTemplateId);
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.HasKey(e => e.EmailTemplateId);

                entity.ToTable("EmailTemplate", "com");

                entity.Property(e => e.EmailTemplateId).HasIdentityOptions(1000L, null, null, null, null, null);

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<ExtensionProperty>(entity =>
            {
                entity.HasKey(e => e.ExtensionPropertyId);

                entity.ToTable("ExtensionProperty", "com");

                entity.HasIndex(e => e.ParentExtensionPropertyId);

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

            modelBuilder.Entity<ExtensionPropertySchema>(entity =>
            {
                entity.HasKey(e => e.ExtensionPropertySchemaId);

                entity.ToTable("ExtensionPropertySchema", "com");

                entity.HasIndex(e => e.ExtensionPropertyId);

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

            modelBuilder.Entity<LoyaltyMessageTemplate>(entity =>
            {
                entity.HasKey(e => e.LoyaltyMessageTemplateId);

                entity.ToTable("LoyaltyMessageTemplate", "com");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<PushNotificationTemplate>(entity =>
            {
                entity.HasKey(e => e.PushNotificationTemplateId);

                entity.ToTable("PushNotificationTemplate", "com");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<SmsTemplate>(entity =>
            {
                entity.HasKey(e => e.SmsTemplateId);

                entity.ToTable("SmsTemplate", "com");

                entity.Property(e => e.CreatedDate).HasColumnType("timestamp with time zone");

                entity.Property(e => e.UpdatedDate).HasColumnType("timestamp with time zone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
