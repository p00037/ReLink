using Microsoft.EntityFrameworkCore;
using ReLink.Server.Entiy.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReLink.Server.DB
{
    public class AppDbContext : DbContext
    {
        //public DbSet<AnswerNumberEntity> AnswerNumberEntitys { get; set; }
        public DbSet<D_MessageEntity> CellEntitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source='data.db'");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<D_MessageEntity>().ToTable("D_Message").HasKey(c => new { c.MessageId });
            //modelBuilder.Entity<CellEntity>().ToTable("D_Cell").HasKey(c => new { c.Name, c.No });
        }
    }
}
