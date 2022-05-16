using myPosCR.Services.Models;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services
{
    public interface IApplicationUserService
    {
        ApplicationUserListingServiceModel GetById(string id);

        ApplicationUserListingServiceModel GetByPhoneNumber(string phoneNumber);

        ApplicationUserListingServiceModel GetByEmail(string email);
    }
}
