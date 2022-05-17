using myPosCR.Services.Models;
using System.Text.Json;

namespace MyPosCR.Web.Models.Home
{
    public class IndexViewModel
    {
        public int IncomingTransactionsCount { get; set; }
        public int OutgoingTransactionsCount { get; set; }
    }
}
