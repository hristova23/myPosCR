namespace MyPosCR.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }
        
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        
        public string RecieverId { get; set; }
        public ApplicationUser Reciever { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
