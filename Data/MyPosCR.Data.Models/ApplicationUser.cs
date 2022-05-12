namespace MyPosCR.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
    //    public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Email { get; set; }

        //[Required]
        //[StringLength(20)]
        //public string PhoneNumber { get; set; }

        //[Required]
        //public string PasswordHash { get; set; }

        [Required]
        public int Credits { get; set; }

        public ICollection<Transaction> SendedTransactions { get; set; } = new List<Transaction>();

        public ICollection<Transaction> RecievedTransactions { get; set; } = new List<Transaction>();
    }
}
