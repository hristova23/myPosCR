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
        private readonly ApplicationDbContext data;

        public TransactionService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Get()
        {
            throw new NotImplementedException();
        }
    }
}
