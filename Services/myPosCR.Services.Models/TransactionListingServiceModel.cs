using Ganss.XSS;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Models
{
    public class TransactionListingServiceModel
    {
        public string SenderUsername { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Display(Name = "Phone Number")]
        public string RecieverPhone { get; set; }


        [Range(1, 100)]
        [Required(ErrorMessage = "Please enter a valid number.")]
        [DataType(DataType.Currency)]
        public int Amount { get; set; }

        public string? Message { get; set; }

        public DateTime Date { get; set; }
    }
}
