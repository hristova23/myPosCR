using Microsoft.AspNetCore.Mvc;
using MyPosCR.Data;
using MyPosCR.Web.Models.Transactions;

namespace MyPosCR.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext db;
        public TransactionsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var users = this.db.Transactions.Select(t => new IndexTransactionViewModel
            {
                TransactionId = t.TransactionId,
                Sender = t.Sender,
                Reciever = t.Reciever,
                Amount = t.Amount,
                Message = t.Message,
                Date = t.Date
            }).ToList();
            viewModel.Transactions = users;

            return View(viewModel);
        }

        public IActionResult Details(IndexTransactionViewModel transaction)
        {
            //var transaction = this.db.Transactions
            //    .Where(t => t.TransactionId == transactionId)
            //    .FirstOrDefault();
            //pass it to the view
            return View();
        }
    }
}
