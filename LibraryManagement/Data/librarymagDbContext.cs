using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Data
{
    public class librarymagDbContext : DbContext
    {
        public librarymagDbContext(DbContextOptions<librarymagDbContext> options) 
            : base(options)
        {
        }

        public DbSet<bookmasterModel> BookMaster { get; set; }
        public DbSet<usermasterModel> UserMaster { get; set; }
        public DbSet<returnModel> returnModel { get; set; }
    }
}
