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
    public class TransactionsService : ITransactionsService
    {
        private readonly ApplicationDbContext db;

        public TransactionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> CreateAsync(TransactionListingServiceModel input)
        {
            var sender = this.db.Users.Where(u=> u.Email == input.SenderEmail).FirstOrDefault();
            var reciever = this.db.Users.Where(u => u.PhoneNumber == input.RecieverPhoneNumber).FirstOrDefault();

            var transaction = new Transaction
            {
                SenderId = sender.Id,
                RecieverId = reciever.Id,
                Amount = input.Amount,
                Message = input.SanitizedMessage, //may be null
                Date = DateTime.UtcNow
            };

            await this.db.Transactions.AddAsync(transaction);
            //Exeption Handling?!!
            reciever.Credits += transaction.Amount;
            sender.Credits -= transaction.Amount;
            //
            await this.db.SaveChangesAsync();

            return transaction.TransactionId;
        }

        public TransactionListingServiceModel GetById(int id)
        {
            var transaction = this.db.Transactions
                .Where(t => t.TransactionId == id)
                .FirstOrDefault();

            var sender = this.db.Users.Where(u => u.Id == transaction.SenderId).FirstOrDefault();
            var reciever = this.db.Users.Where(u => u.Id == transaction.RecieverId).FirstOrDefault();

            return new TransactionListingServiceModel
            {
                TransactionId = transaction.TransactionId,
                SenderEmail = sender.Email,
                SenderPhoneNumber = sender.PhoneNumber,
                RecieverEmail= reciever.Email,
                RecieverPhoneNumber= reciever.PhoneNumber,
                Amount = transaction.Amount,
                Message = transaction.Message,
                Date = transaction.Date
            };
        }
    }
}
