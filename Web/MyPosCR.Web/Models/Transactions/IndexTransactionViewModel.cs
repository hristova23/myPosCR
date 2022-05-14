using MyPosCR.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MyPosCR.Web.Models.Transactions
{
    public class IndexTransactionViewModel
    {
        public int TransactionId { get; set; }

        [Required]
        public ApplicationUser Sender { get; set; }

        [Required]
        public ApplicationUser Reciever { get; set; }

        public string? Message { get; set; }

        [Required]
        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}