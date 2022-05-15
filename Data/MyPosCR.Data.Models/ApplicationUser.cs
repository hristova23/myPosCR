namespace MyPosCR.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;//
    using System.ComponentModel.DataAnnotations;

    [Index(nameof(PhoneNumber), IsUnique = true)]//
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int Credits { get; set; }

        [Phone]
        [DataType(DataType.PhoneNumber)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

        public ICollection<Transaction> SendedTransactions { get; set; } = new List<Transaction>();

        public ICollection<Transaction> RecievedTransactions { get; set; } = new List<Transaction>();
    }
}
