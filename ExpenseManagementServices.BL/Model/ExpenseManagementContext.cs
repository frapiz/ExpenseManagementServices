using System;
using ExpenseManagementServices.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ExpenseManagementServices.BL.Model
{
    public partial class ExpenseManagementContext : DbContext
    {
        public ExpenseManagementContext()
        {
        }

        public ExpenseManagementContext(DbContextOptions<ExpenseManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysTypeExpenses> SysTypeExpenses { get; set; }
        public virtual DbSet<WExpense> WExpense { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SharedConfig.Configuration.GetConnectionString("ExpenseManagement"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysTypeExpenses>(entity =>
            {
                entity.HasKey(e => e.SrgKey);

                entity.ToTable("SYS_TYPE_EXPENSES");

                entity.Property(e => e.SrgKey).HasColumnName("SRG_KEY");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("DESC")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeExpense)
                    .IsRequired()
                    .HasColumnName("TYPE_EXPENSE")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WExpense>(entity =>
            {
                entity.HasKey(e => e.SrgKey);

                entity.ToTable("W_EXPENSE");

                entity.Property(e => e.SrgKey).HasColumnName("SRG_KEY");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasColumnName("DESC")
                    .HasMaxLength(100);

                entity.Property(e => e.DtExpense)
                    .HasColumnName("DT_EXPENSE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TypeExpenseSrgKey).HasColumnName("TYPE_EXPENSE_SRG_KEY");

                entity.HasOne(d => d.TypeExpenseSrgKeyNavigation)
                    .WithMany(p => p.WExpense)
                    .HasForeignKey(d => d.TypeExpenseSrgKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_W_EXPENSE_SYS_TYPE_EXPENSES");
            });
        }
    }
}
