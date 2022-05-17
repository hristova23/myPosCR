using myPosCR.Services.Models;

namespace myPosCR.Services
{
    public interface ITransactionsService
    {
        Task<int> CreateAsync(TransactionListingServiceModel transaction);
        TransactionListingServiceModel GetById(int id);
        List<TransactionListingServiceModel> GetAllTransactionsByUserId(string id);
    }
}
