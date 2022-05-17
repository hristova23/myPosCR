using Ganss.XSS;
using System.ComponentModel.DataAnnotations;

namespace myPosCR.Services.Models
{
    public class TransactionListingServiceModel
    {
        public int TransactionId { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPhoneNumber { get; set; }

        public string RecieverEmail { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string RecieverPhoneNumber { get; set; }

        public string? Message { get; set; }
        public string SanitizedMessage => new HtmlSanitizer().Sanitize(this.Message);

        [Range(1, 1000, ErrorMessage = "Please enter a number between 0 and 1000.")]
        [Required(ErrorMessage = "Please enter a valid number.")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
