using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccessLayer.Models;

#nullable disable

namespace DataAccessLayer.Data
{
    public partial class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TRAINEE-09; Database=EmployeeManagement; User ID=sa; Password=412417105083Vj;Trusted_Connection=false;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Aadhar).IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('GS'+right('0'+CONVERT([varchar](2),[ID]),(2)))", true);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Pan).IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__employee__Gender__412EB0B6");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Gender1).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
