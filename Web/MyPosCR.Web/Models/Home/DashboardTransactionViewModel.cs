namespace MyPosCR.Web.Models.NewFolder
{
    public class DashboardTransactionViewModel
    {
        public string TransactionId { get; set; }

        public string Sender { get; set; } //name ? phone?

        public string Reciever { get; set; } //name ? phone?

        public int Amount { get; set; }

        public string Url => $"/Dashboard/Detail/{this.TransactionId}";
    }
}