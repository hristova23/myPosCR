using MyPosCR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly MyPosCRDbContext data;

        public TransactionService(MyPosCRDbContext data)
        {
            this.data = data;
        }
    }
}
