using Ganss.XSS;
using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Models
{
    public class NewTransactionServiceListingModel
    {
        public int TransactionId { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPhoneNumber { get; set; }

        public string RecieverEmail { get; set; }

        public string RecieverPhoneNumber { get; set; }

        public string? Message { get; set; }
        public string SanitizedMessage => new HtmlSanitizer().Sanitize(this.Message);

        public int Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
