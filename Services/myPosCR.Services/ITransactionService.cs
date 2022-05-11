using myPosCR.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services
{
    public interface ITransactionService
    {
        void Create();
        void Get();
        //List<TransactionListingServiceModel> SearchById(int id);
    }
}
