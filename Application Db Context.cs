using ConsoleApp5.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Application_Db_Context:DbContext
    {   public DbSet <Task_entity> task_Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EfCore503;Integrated Security=True;TrustServerCertificate=True");
                             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task_entity>().Property(e=>e.Date).IsRequired();

            modelBuilder.Entity<Task_entity>().Property(b => b.Date).HasColumnName("Deadline");

            modelBuilder.Entity<Task_entity>().ToTable("NewTask");
        }
    }
}
