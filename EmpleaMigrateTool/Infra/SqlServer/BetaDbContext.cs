using System;
using EmpleaMigrateTool.BetaEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace EmpleaMigrateTool.Infra.SqlServer
{
    public partial class BetaDbContext : DbContext
    {
        private string _connectionString;
        public BetaDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public BetaDbContext(DbContextOptions<BetaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<HireTypes> HireTypes { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<JoelTest> JoelTest { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.VersionInfo'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LogoUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<HireTypes>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.HowToApply)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<JoelTest>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PlaceId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LoginProvider)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProviderKey)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });
        }
    }
}
