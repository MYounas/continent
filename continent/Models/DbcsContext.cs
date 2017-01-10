namespace continent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbcsContext : DbContext
    {
        public DbcsContext()
            : base("name=DbcsContext")
        {
        }

        public virtual DbSet<area> areas { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<country> countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<area>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.areas)
                .WithRequired(e => e.city)
                .HasForeignKey(e => e.CI_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.country)
                .HasForeignKey(e => e.CO_id)
                .WillCascadeOnDelete(false);
        }
    }
}
