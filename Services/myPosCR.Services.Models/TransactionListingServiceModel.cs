using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Models
{
    public class TransactionListingServiceModel
    {
        public string SenderUsername { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        [Phone]
        public string RecieverPhone { get; set; }

        [Required]
        public int Amount { get; set; }

        public string? Message { get; set; }

        public DateTime Date { get; set; }
    }
}
