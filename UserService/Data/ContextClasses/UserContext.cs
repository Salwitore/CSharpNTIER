using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=127.0.0.1;Port=3306;Database=UserService;Uid=root;Pwd=root;CharSet=utf8;"
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=UserService;Uid=root;Pwd=root;CharSet=utf8;", ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=UserService;Uid=root;Pwd=root;CharSet=utf8;"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            //Her User'ın bir departmanı var , Her departmanın birden çok userı olabilir , Users'daki departmentId Foreign key
            modelBuilder.Entity<User>().HasOne<Department>(u => u.Department).WithMany(d => d.Users).HasForeignKey(u => u.DepartmentId);
        }
    }
}
