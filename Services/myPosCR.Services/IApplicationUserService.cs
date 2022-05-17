using myPosCR.Services.Models;

namespace myPosCR.Services
{
    public interface IApplicationUserService
    {
        ApplicationUserListingServiceModel GetById(string id);

        ApplicationUserListingServiceModel GetByPhoneNumber(string phoneNumber);

        ApplicationUserListingServiceModel GetByEmail(string email);
    }
}
