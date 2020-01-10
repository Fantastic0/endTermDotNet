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

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<AcctPos>().HasOne(ap => ap.Acct).WithMany(a => a.AcctPos).HasForeignKey(ap => ap.AcctId);

            modelBuilder.Entity<Loan>().HasOne(l => l.Acct).WithOne(a => a.Loan).HasForeignKey<Loan>(l => l.AcctId);

            modelBuilder.Entity<OpEntry>().HasOne(opE => opE.Op).WithMany(op => op.OpEntries).HasForeignKey(opE => opE.OpId);*/

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = -1,
                Inn = "990317350064",
                NameLast = "Kantarbay",
                FirstName = "Yerbolat",
                OpenDate = new DateTime(2019, 10, 3)
            },
            new Person
            {
                PersonId = -2,
                Inn = "123456789012",
                NameLast = "Kadirbekov",
                FirstName = "Yeren",
                OpenDate = new DateTime(2019, 8, 2)
            },
            new Person
            {
                PersonId = -3,
                Inn = "987654321098",
                NameLast = "Tynyshbay",
                FirstName = "Nurzhan",
                OpenDate = new DateTime(2019, 7, 19)
            },
            new Person
            {
                PersonId = -4,
                Inn = "312456798879",
                NameLast = "Surname",
                FirstName = "Name",
                OpenDate = new DateTime(2019, 10, 18)
            });
        }
    }
}
