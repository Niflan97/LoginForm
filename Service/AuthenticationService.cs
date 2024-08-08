using System;
using LogInProject.Data;

namespace LogInProject.Service
{
    public interface IAuthenticationService
    {
        bool Authenticate(string username, string password);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserDbContext _context;

        public AuthenticationService(UserDbContext context)
        {
            _context = context;
        }

        public bool Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }
    }

    
}

