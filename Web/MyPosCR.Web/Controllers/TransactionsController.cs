using MyPosCR.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myPosCR.Services;
using myPosCR.Services.Implementations;
using myPosCR.Services.Models;
using MyPosCR.Data;
using MyPosCR.Web.Models.Transactions;

namespace MyPosCR.Web.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsService TransactionsService;
        private readonly ApplicationDbContext db;

        public TransactionsController(ITransactionsService sendService, ApplicationDbContext db)
        {
            this.TransactionsService = sendService;
            this.db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var users = this.db.Transactions.Where(t=>t.Sender.Email == User.Identity.Name || t.Reciever.Email == User.Identity.Name).Select(t => new IndexTransactionViewModel
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

        public IActionResult Details(int id)
        {
            var transaction = this.TransactionsService.GetById(id);

            if (transaction == null)
            {
                return this.NotFound();
            }

            return View(transaction);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionListingServiceModel input)
        {
            input.Date = DateTime.UtcNow;
            input.SenderUsername = HttpContext.User.Identity.Name;

            if (ModelState.IsValid)
            {
                int transactionId = await this.TransactionsService.CreateAsync(new TransactionListingServiceModel
                {
                    SenderUsername = input.SenderUsername,
                    RecieverPhone = input.RecieverPhone,
                    Message = input.Message,
                    Amount = input.Amount,
                    Date = input.Date
                });

                return this.RedirectToAction(nameof(this.Details), new { id = transactionId });
            }
            else
            {
                return View(input);
            }
        }
    }
}


//var transaction = new Transaction
//{
//    Sender = transactionData.Sender,
//    Reciever = transactionData.Reciever,
//    Amount = transactionData.Amount,
//    Message = transactionData.Message,
//    Date = transactionData.Date
//};
////firstName,
////middleName,
////lastName,
////(int)clas,
////(int)numberInClass,
////$"{DateTime.UtcNow.Year}/{DateTime.UtcNow.Year + 1}",
////enrollmentDate,
////status.ToString(),
////DateTime.UtcNow);

//this.data.Transactions.Add(transaction);

//this.data.SaveChanges();