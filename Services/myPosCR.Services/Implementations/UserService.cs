using MyPosCR.Data;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext data;

        public UserService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create(string email, string phoneNumber, string password, int credits = 100)
        {
            //VALIDATIONS!

            ApplicationUser user = new ApplicationUser
            {
                Email = email,
                PhoneNumber = phoneNumber,
                PasswordHash = HashPassword(password),//
                Credits = credits
            };

            this.data.Users.Add(user);
            this.data.SaveChanges();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var asBytes = Encoding.Default.GetBytes(password);
            var passwordHash = sha.ComputeHash(asBytes);
            return Convert.ToBase64String(passwordHash);
        }
    }
}
