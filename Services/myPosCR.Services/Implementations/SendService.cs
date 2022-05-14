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
    public class SendService : ISendService
    {
        private readonly ApplicationDbContext db;

        public SendService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(TransactionListingServiceModel input)
        {
            var recieverPhone = input.RecieverPhone;

            var sender = this.db.Users.Where(u=>u.UserName == input.SenderUsername).FirstOrDefault();
            var reciever = this.db.Users.Where(u => u.PhoneNumber == recieverPhone).FirstOrDefault();

            var transaction = new Transaction
            {
                SenderId = sender.Id,
                Reciever = reciever,
                Amount = input.Amount,
                Message = input.Message, //may be null
                Date = DateTime.UtcNow
            };

            await this.db.Transactions.AddAsync(transaction);
            await this.db.SaveChangesAsync();
            return transaction.TransactionId;
        }
    }
}
