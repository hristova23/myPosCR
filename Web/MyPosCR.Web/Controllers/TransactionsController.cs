using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myPosCR.Services;
using myPosCR.Services.Models;
using MyPosCR.Data;
using MyPosCR.Web.Models.Transactions;

namespace MyPosCR.Web.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsService TransactionsService;
        private readonly IApplicationUserService ApplicationUserService;
        private readonly ApplicationDbContext db;

        public TransactionsController(ITransactionsService transactionsService, IApplicationUserService applicationUserService, ApplicationDbContext db)
        {
            this.TransactionsService = transactionsService;
            this.ApplicationUserService = applicationUserService;
            this.db = db;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var users = new List<IndexTransactionViewModel>();

            if (this.User.IsInRole("Administrator"))
            {
                users = this.db.Transactions.Select(t => new IndexTransactionViewModel
                {
                    TransactionId = t.TransactionId,
                    Sender = t.Sender,
                    Reciever = t.Reciever,
                    Amount = t.Amount,
                    Message = t.Message,
                    Date = t.Date
                }).ToList();
            }
            else
            {
                users = this.db.Transactions.Where(t => t.Sender.Email == User.Identity.Name || t.Reciever.Email == User.Identity.Name).Select(t => new IndexTransactionViewModel
                {
                    TransactionId = t.TransactionId,
                    Sender = t.Sender,
                    Reciever = t.Reciever,
                    Amount = t.Amount,
                    Message = t.Message,
                    Date = t.Date
                }).ToList();
            }
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
            input.SenderEmail = HttpContext.User.Identity.Name;

            var sender = this.ApplicationUserService.GetByEmail(input.SenderEmail);

            ModelState.Remove("SenderEmail");
            ModelState.Remove("RecieverEmail");
            ModelState.Remove("SenderPhoneNumber");

            if (ModelState.IsValid)
            {
                try
                {
                    if (sender.PhoneNumber == input.RecieverPhoneNumber)
                    {
                        throw new Exception("You cannot make transactions to your account.");
                    }
                    if (sender.Credits < input.Amount)
                    {
                        throw new Exception("You do not have enough credits.");
                    }
                    int transactionId = await this.TransactionsService.CreateAsync(input);

                    return this.RedirectToAction(nameof(this.Details), new { id = transactionId });
                }
                catch (Exception err)
                {
                    //return view and display err.Message
                    return View(input);
                    throw;
                }
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