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
        void Create(string email, string phoneNumber, string password, int credits);
        void Read();
        void Update();
        //void Delete(int id);
        string HashPassword(string password);
        //List<UserListingServiceModel> SearchByEmail(string email);
    }
}
