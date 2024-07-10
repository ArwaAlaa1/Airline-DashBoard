using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AirLine.Controllers
{
	public class PhonesController : Controller
	{
		private readonly DBContext _dbContext;
		public PhonesController(DBContext dbContext)
		{
			_dbContext = dbContext;
		}
		// GET: PhoneController
		public ActionResult Index()
		{
			var phones = _dbContext.AirLinesPhones.ToList();
			var viewModelList = new List<PhonesModel>();
			foreach (var ph in phones)
			{
				var viewModel = new PhonesModel()
				{
					AirLineId = ph.AirLineId,
					Phones = ph.Phones,

				};
				viewModelList.Add(viewModel);
			}

			return View(viewModelList);

		}

		// GET: PhoneController/Details/5
		public ActionResult Details(int id)
		{
			var PhoneDE = _dbContext.AirLinesPhones.Where(p => p.AirLineId == id).ToList();
			return View(PhoneDE);
		}

		// GET: PhoneController/Create
		public ActionResult Create()
		{
			PhonesModel phone = new PhonesModel();
			var phs = _dbContext.AirLine_Companies.ToList();
			phone.AirLines_List = phs;
			return View(phone);


		}

		// POST: PhoneController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(PhonesModel phon)
		{
			try
			{
				Airline_Phones airline = new Airline_Phones()
				{
					AirLineId = phon.AirLineId,
					Phones = phon.Phones,


				};
				_dbContext.Add(airline);
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));

			}
			catch
			{
				return View();
			}
		}


	}
}
