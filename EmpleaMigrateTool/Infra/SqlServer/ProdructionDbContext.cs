using System;
using EmpleaMigrateTool.ProductionEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmpleaMigrateTool.Infra.SqlServer
{
    public partial class ProductionDbContext : DbContext
    {
        private  string _connectionString { get; }
        public ProductionDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<JobOpportunities> JobOpportunities { get; set; }
        public virtual DbSet<JobOpportunityLocations> JobOpportunityLocations { get; set; }
        public virtual DbSet<JoelTests> JoelTests { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TagJobOpportunities> TagJobOpportunities { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }
        public virtual DbSet<UserRolesJoin> UserRolesJoin { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.Companies'. Please see the warning messages.
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

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasIndex(e => e.IdentityUserId)
                    .HasName("IX_IdentityUser_Id");

                entity.Property(e => e.IdentityUserId)
                    .HasColumnName("IdentityUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdentityUser)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.IdentityUserId)
                    .HasConstraintName("FK_dbo.Claims_dbo.Users_User_Id");
            });

            modelBuilder.Entity<JobOpportunities>(entity =>
            {
                entity.HasKey(e => e.JobOpportunityId)
                    .HasName("PK_dbo.JobOpportunities");

                entity.HasIndex(e => e.JobOpportunityLocationId)
                    .HasName("IX_JobOpportunityLocationId");

                entity.HasIndex(e => e.JoelTestId)
                    .HasName("IX_JoelTestId");

                entity.HasIndex(e => e.LocationId)
                    .HasName("IX_LocationId");

                entity.HasIndex(e => e.UserProfileId)
                    .HasName("IX_UserProfileId");

                entity.Property(e => e.CompanyEmail).IsRequired();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.JobOpportunityLocation)
                    .WithMany(p => p.JobOpportunities)
                    .HasForeignKey(d => d.JobOpportunityLocationId)
                    .HasConstraintName("FK_dbo.JobOpportunities_dbo.JobOpportunityLocations_JobOpportunityLocationId");

                entity.HasOne(d => d.JoelTest)
                    .WithMany(p => p.JobOpportunities)
                    .HasForeignKey(d => d.JoelTestId)
                    .HasConstraintName("FK_dbo.JobOpportunities_dbo.JoelTests_JoelTestId");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.JobOpportunities)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_dbo.JobOpportunities_dbo.Locations_LocationId");

                entity.HasOne(d => d.UserProfile)
                    .WithMany(p => p.JobOpportunities)
                    .HasForeignKey(d => d.UserProfileId)
                    .HasConstraintName("FK_dbo.JobOpportunities_dbo.UserProfiles_UserProfileId");
            });

            modelBuilder.Entity<JobOpportunityLocations>(entity =>
            {
                entity.Property(e => e.Latitude).IsRequired();

                entity.Property(e => e.Longitude).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PlaceId)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<JoelTests>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_dbo.Locations");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_dbo.Logins");

                entity.HasIndex(e => e.IdentityUserId)
                    .HasName("IX_IdentityUser_Id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.IdentityUserId)
                    .HasColumnName("IdentityUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdentityUser)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.IdentityUserId)
                    .HasConstraintName("FK_dbo.Logins_dbo.Users_User_Id");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TagJobOpportunities>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.JobOpportunityId })
                    .HasName("PK_dbo.TagJobOpportunities");

                entity.HasIndex(e => e.JobOpportunityId)
                    .HasName("IX_JobOpportunity_Id");

                entity.HasIndex(e => e.TagId)
                    .HasName("IX_Tag_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.Property(e => e.JobOpportunityId).HasColumnName("JobOpportunity_Id");

                entity.HasOne(d => d.JobOpportunity)
                    .WithMany(p => p.TagJobOpportunities)
                    .HasForeignKey(d => d.JobOpportunityId)
                    .HasConstraintName("FK_dbo.TagJobOpportunities_dbo.JobOpportunities_JobOpportunity_Id");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagJobOpportunities)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_dbo.TagJobOpportunities_dbo.Tags_Tag_Id");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserRolesJoin>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.UserRolesJoin");

                entity.HasIndex(e => e.IdentityRoleId)
                    .HasName("IX_IdentityRole_Id");

                entity.HasIndex(e => e.IdentityUserId)
                    .HasName("IX_IdentityUser_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.Property(e => e.IdentityRoleId)
                    .HasColumnName("IdentityRole_Id")
                    .HasMaxLength(128);

                entity.Property(e => e.IdentityUserId)
                    .HasColumnName("IdentityUser_Id")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdentityRole)
                    .WithMany(p => p.UserRolesJoin)
                    .HasForeignKey(d => d.IdentityRoleId)
                    .HasConstraintName("FK_dbo.UserRolesJoin_dbo.Roles_IdentityRole_Id");

                entity.HasOne(d => d.IdentityUser)
                    .WithMany(p => p.UserRolesJoin)
                    .HasForeignKey(d => d.IdentityUserId)
                    .HasConstraintName("FK_dbo.UserRolesJoin_dbo.Users_IdentityUser_Id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(128)
                    .ValueGeneratedNever();

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            });
        }
    }
}
