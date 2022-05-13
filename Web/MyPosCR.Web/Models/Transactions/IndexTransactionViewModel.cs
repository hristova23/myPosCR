using MyPosCR.Data.Models;

namespace MyPosCR.Web.Models.Transactions
{
    public class IndexTransactionViewModel
    {
        public int TransactionId { get; set; }
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Reciever { get; set; }
        public string Message { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}