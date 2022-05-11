using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myPosCR.Services.Models
{
    public class TransactionListingServiceModel
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
