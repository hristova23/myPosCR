using myPosCR.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services
{
    public interface IUserService
    {
        void Create();
        void Get();
        void Update();
        void Delete();
        string HashPassword(string password);
        //List<UserListingServiceModel> SearchByEmail(string email);
    }
}
