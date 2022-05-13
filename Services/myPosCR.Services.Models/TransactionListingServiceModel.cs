using MyPosCR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Models
{
    public class TransactionListingServiceModel
    {
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Reciever { get; set; }
        public int Amount { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
