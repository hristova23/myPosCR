namespace MyPosCR.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        public int Credits { get; set; }

        public ICollection<Transaction> SendedTransactions { get; set; } = new List<Transaction>();

        public ICollection<Transaction> RecievedTransactions { get; set; } = new List<Transaction>();
    }
}
