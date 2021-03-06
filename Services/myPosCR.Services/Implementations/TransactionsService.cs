using myPosCR.Services.Models;
using MyPosCR.Data;
using MyPosCR.Data.Models;

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
            var sender = this.db.Users.Where(u => u.Email == input.SenderEmail).FirstOrDefault();
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
                RecieverEmail = reciever.Email,
                RecieverPhoneNumber = reciever.PhoneNumber,
                Amount = transaction.Amount,
                Message = transaction.Message,
                Date = transaction.Date
            };
        }

        public List<TransactionListingServiceModel> GetAllTransactionsByUserId(string id)
        {
            return this.db.Transactions
                .Where(t => t.SenderId == id || t.RecieverId == id)
                .Select(t => new TransactionListingServiceModel
                {
                    TransactionId = t.TransactionId,
                    Amount = t.Amount,
                    Message = t.Message,
                    Date = t.Date
                })
                .ToList();
        }
    }
}
