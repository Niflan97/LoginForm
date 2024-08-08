using System;
using LogInProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LogInProject.Data
{
	public class UserDbContext :DbContext
	{
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Admin", Password = "admin123" },
                new User { Id = 2, Username = "User", Password = "user123" }
            );
        }

    }
}

