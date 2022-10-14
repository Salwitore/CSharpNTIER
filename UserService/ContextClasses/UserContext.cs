using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextClasses
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=127.0.0.1;Port=3306;Database=EFCore;Uid=root;Pwd=root;CharSet=utf8;"
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=UserService;Uid=root;Pwd=root;CharSet=utf8;", ServerVersion.AutoDetect("Server=127.0.0.1;Port=3306;Database=EFCore;Uid=root;Pwd=root;CharSet=utf8;"));
        }
    }
}
