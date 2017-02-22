using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;


namespace WebApplication1
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Group> Group { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Employee_Group");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}