using myPosCR.Services.Models;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services
{
    public interface ITransactionsService
    {
        Task<int> CreateAsync(TransactionListingServiceModel transaction);
        TransactionListingServiceModel GetById(int id);
        List<TransactionListingServiceModel> GetAllTransactionsByUserId(string id);
    }
}
