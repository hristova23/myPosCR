using myPosCR.Services.Models;
using Newtonsoft.Json;

namespace MyPosCR.Web.Models.Home
{
    public class IndexViewModel
    {
        public List<IndexTransactionViewModel> Transactions { get; set; }

        public string SerializzeData => JsonConvert.SerializeObject(Transactions);
    }
}
