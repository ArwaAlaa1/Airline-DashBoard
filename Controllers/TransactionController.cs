using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirLine.Controllers
{
	public class TransactionController : Controller
	{
		private readonly DBContext _dBContext;

		public TransactionController(DBContext dBContext)
		{
			_dBContext = dBContext;
		}


		// GET: TransactionController
		public ActionResult Index()
		{
			var transctions = _dBContext.Transactions.ToList();
            var TransModel = new List<TransactionModel>();
			foreach (var trans in transctions)
			{
				var viewModel = new TransactionModel()
				{
					Id= trans.Id,
					Description = trans.Description,
					Date = trans.Date,
					Amount_Money = trans.Amount_Money,
				    AirlineId=trans.AirlineId,
				    CreatedDate = trans.CreatedDate,
					UpdatedDate = trans.UpdatedDate,
					IsDeleted = trans.IsDeleted,
					IsVisable = trans.IsVisable,
				};
				TransModel.Add(viewModel);
			
			}

			 return View(TransModel);
			
			
		}

		// GET: TransactionController/Details/5
		public ActionResult Details(long id)
		{
			var tansDE = _dBContext.Transactions.Where(r => r.Id == id).FirstOrDefault();

			return View(tansDE);
		}

		// GET: TransactionController/Create
		public ActionResult Create()
		{

           TransactionModel TranModel = new TransactionModel();
            var airline = _dBContext.AirLine_Companies.ToList();
            TranModel.AirLines = airline;
            return View(TranModel);
		}

		// POST: TransactionController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(TransactionModel transactionModel)
		{
			try
			{
				Transaction transaction = new Transaction()
				{
					Id = transactionModel.Id,
					Description = transactionModel.Description,
					Date= transactionModel.Date,
					Amount_Money = transactionModel.Amount_Money,
					AirlineId = transactionModel.AirlineId,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now,
					IsDeleted = false,
					IsVisable = true,


				};
				_dBContext.Add(transaction);
				
				_dBContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TransactionController/Edit/5
		public ActionResult Edit(long id)
		{
            TransactionModel TranModel = new TransactionModel();
            var airline = _dBContext.AirLine_Companies.ToList();
            var transE = _dBContext.Transactions.Where(r => r.Id == id).FirstOrDefault();
			var viewModel = new TransactionModel
			{
				Id = transE.Id,
				Description = transE.Description,
				Date = transE.Date,
				Amount_Money = transE.Amount_Money,
				AirlineId=transE.AirlineId,
				IsDeleted= transE.IsDeleted,
				IsVisable= transE.IsVisable,
				CreatedDate= transE.CreatedDate,
				UpdatedDate= transE.UpdatedDate,
			};
			viewModel.AirLines = airline;
			return View(viewModel);
		}

		// POST: TransactionController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(TransactionModel transactionModel)
		{
			try
			{

				var originalRoad = _dBContext.Transactions.Where(r => r.Id == transactionModel.Id).FirstOrDefault();


				originalRoad.Id = transactionModel.Id;
				originalRoad.Description = transactionModel.Description;
				originalRoad.Date = transactionModel.Date;
				originalRoad.Amount_Money = transactionModel.Amount_Money;
                originalRoad.AirlineId = transactionModel.AirlineId;
				originalRoad.IsVisable = transactionModel.IsVisable;
				originalRoad.IsDeleted = transactionModel.IsDeleted;
				originalRoad.CreatedDate = transactionModel.CreatedDate;
				originalRoad.UpdatedDate = transactionModel.UpdatedDate;



				_dBContext.SaveChanges();
				return RedirectToAction(nameof(Index));
				
			}
			catch
			{
				return View();
			}
		}

		// GET: TransactionController/Delete/5
		public ActionResult Delete(long id)
		{
			var transD = _dBContext.Transactions.Where(r => r.Id == id).FirstOrDefault();
			return View(transD);
		}

		// POST: TransactionController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(Transaction transaction)
		{
			try
			{
				var TranDelete = _dBContext.Transactions.Where(r => r.Id == transaction.Id).FirstOrDefault();
				_dBContext.Transactions.Remove(TranDelete);

				_dBContext.SaveChanges();
				return RedirectToAction(nameof(Index));

				
			}
			catch
			{
				return View();
			}
		}
	}
}
