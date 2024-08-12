using Microsoft.EntityFrameworkCore;
using Payslip.Models;

namespace Payslip.Data
{
    public class SalarySlipContext : DbContext
    {
        public SalarySlipContext(DbContextOptions<SalarySlipContext> options)
        : base(options)
        {
        }

        public DbSet<SalarySlip> SalarySlips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalarySlip>().ToTable("SalarySlips");
        }
    }
}
