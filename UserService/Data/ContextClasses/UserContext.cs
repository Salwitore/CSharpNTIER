using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

            //User entitymize CreatedDate ve UpdatedDate shadow propertylerini tanımladık.
            modelBuilder.Entity<User>().Property<DateTime>("CreatedDate");
            modelBuilder.Entity<User>().Property<DateTime>("UpdatedDate");
        }
        //Her bir entity nesnesinde shadow propertylere manuel olarak erişmemek için 
        //SaveChanges() metodunu override ederek bu shadow propertylerine değeri otomatik olarak
        //ayarlayabiliriz.
        public override int SaveChanges()
        {
            var entries = ChangeTracker //herhangi bir entity'de değişiklik veya ekleme olduğunda entryleri ChangeTracker'la tespit edip enrties'e atıyoruz.
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now; //entity'de değişiklik olduğunda UpdateDate shadow property'si güncellenicek

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;//entity'de ekleme olduğunda CreatedDate shadow property'si güncellenicek
                }
            }


            return base.SaveChanges();
        }
    }
}
