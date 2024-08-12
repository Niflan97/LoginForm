using System;
using System.Data.Common;
using LogInProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogInProject.Data
{
	public class UserDbContext :DbContext
	{


        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public bool IsDatabaseConnected()
        {
            try
            {
                // Try to open the database connection
                this.Database.OpenConnection();
                this.Database.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Username = "Admin", Password = "admin123" },
        //        new User { Id = 2, Username = "User", Password = "user123" }
        //    );
        //}

    }
}

