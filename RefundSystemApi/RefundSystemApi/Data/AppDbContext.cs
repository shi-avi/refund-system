using Microsoft.EntityFrameworkCore;
using RefundSystemApi.Models.DTO;
using RefundSystemApi.Models.Entities;

namespace RefundSystemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        
        public DbSet<Citizens> Citizens { get; set; }
        public DbSet<Incomes> Incomes { get; set; }
        public DbSet<RefundRequests> RefundRequests { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<SystemBudget> SystemBudget { get; set; }
        public DbSet<RefundAmountResult> RefundAmountResult { get; set; }
        public DbSet<ProcessRefundResult> ProcessRefundResult { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefundAmountResult>().HasNoKey();
            modelBuilder.Entity<ProcessRefundResult>().HasNoKey();
            //    modelBuilder.Entity<RefundCalculationResultDto>().HasNoKey();
            //    modelBuilder.Entity<RefundRequests>().Property(r => r.Status).HasConversion<string>();
        }

}
}
