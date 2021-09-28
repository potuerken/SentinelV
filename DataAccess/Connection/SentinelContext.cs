using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Connection
{
    public class SentinelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KVJU9I3\MSSQLSERVER01;Database=Sentinel; Trusted_Connection=true");
        }

        public DbSet<HardKod> HardKod { get; set; }
        public DbSet<Kod> Kod { get; set; }
        public DbSet<KodTip> KodTip { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Personel> Personel { get; set; }
    }
}
