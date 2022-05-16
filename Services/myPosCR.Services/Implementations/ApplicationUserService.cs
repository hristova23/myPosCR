using myPosCR.Services.Models;
using MyPosCR.Data;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext db;

        public ApplicationUserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ApplicationUserListingServiceModel GetById(string id)
        {
            var user = this.db.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();

            return new ApplicationUserListingServiceModel
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Credits = user.Credits
            }; //or null? default?
        }

        public ApplicationUserListingServiceModel GetByPhoneNumber(string phoneNumber)
        {
            var user = this.db.Users
                .Where(u => u.PhoneNumber == phoneNumber)
                .FirstOrDefault();

            return new ApplicationUserListingServiceModel
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Credits = user.Credits
            }; //or null? default?
        }

        public ApplicationUserListingServiceModel GetByEmail(string email)
        {
            var user = this.db.Users
                .Where(u => u.Email == email)
                .FirstOrDefault();

            return new ApplicationUserListingServiceModel
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Credits = user.Credits
            }; //or null? default?
        }
    }
}
