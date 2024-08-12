using System;
using System.Data;
using LogInProject.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LogInProject.Service
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserDbContext _context;

        public AuthenticationService(UserDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            
            var sql = "SELECT Id, Username, Password FROM Users WHERE Username = @Username AND Password = @Password";

            
            var result = await _context.Users
                                       .FromSqlRaw(sql,
                                           new SqlParameter("@Username", username),
                                           new SqlParameter("@Password", password))
                                       .ToListAsync();

            return result.Count > 0;
        }

    }

}

