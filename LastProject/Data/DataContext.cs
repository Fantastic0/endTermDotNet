using LastProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastProject.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext() { }
        

        public DbSet<Acct> Acct { get; set; }
        public DbSet<AcctPos> AcctPos { get; set; }
        public DbSet<Cust> Cust { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Op> Op { get; set; }
        public DbSet<OpEntry> OpEntry { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AcctPos>().HasOne(ap => ap.Acct).WithMany(a => a.AcctPos).HasForeignKey(ap => ap.AcctId);

            modelBuilder.Entity<Loan>().HasOne(l => l.Acct).WithOne(a => a.Loan).HasForeignKey<Loan>(l => l.AcctId);

            modelBuilder.Entity<OpEntry>().HasOne(opE => opE.Op).WithMany(op => op.OpEntries).HasForeignKey(opE => opE.OpId);
        }
    }
}
