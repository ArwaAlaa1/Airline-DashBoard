using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirLine.Controllers
{
	public class AirLine_CompanyController : Controller
	{
		private readonly DBContext _dbContext;
		public AirLine_CompanyController(DBContext dbContext)
		{
			_dbContext = dbContext;
		}

		// GET: AirLine_CompanyController
		public ActionResult Index()
		{
			var airs = _dbContext.AirLine_Companies.ToList();

			var viewModelList = new List<AirLineCompanyModel>();
			foreach (var airline in airs)
			{
				var viewModel = new AirLineCompanyModel()
				{
					Id = airline.Id,
					Name = airline.Name,
					Contact_Name = airline.Contact_Name,
					Address = airline.Address,
					IsVisable= airline.IsVisable,
					IsDeleted= airline.IsDeleted,
					CreatedDate = airline.CreatedDate,
					UpdatedDate= airline.UpdatedDate
				};
				viewModelList.Add(viewModel);
			}
			return View(viewModelList);

		}

		// GET: AirLine_CompanyController/Details/5
		public ActionResult Details(int id)
		{
			var airDe = _dbContext.AirLine_Companies.Where(e => e.Id == id).FirstOrDefault();

			return View(airDe);

		}

		// GET: AirLine_CompanyController/Create
		public ActionResult Create()
		{
			var viewModel = new AirLineCompanyModel();
			return View(viewModel);

		}

		// POST: AirLine_CompanyController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AirLineCompanyModel airLineCompanyModel)
		{
			try
			{
				AirLine_Company air = new AirLine_Company()
				{

					Id = airLineCompanyModel.Id,
					Name = airLineCompanyModel.Name,
					Contact_Name = airLineCompanyModel.Contact_Name,
					Address = airLineCompanyModel.Address,
					IsVisable = airLineCompanyModel.IsVisable,
					CreatedDate = DateTime.Now,
					UpdatedDate = DateTime.Now


				};
				air.IsVisable = true;
				air.IsDeleted = false;
				_dbContext.Add(air);
				_dbContext.SaveChanges();
				return RedirectToAction(nameof(Index));

			}
			catch
			{
				return View();
			}
		}

		// GET: AirLine_CompanyController/Edit/5
		public ActionResult Edit(int id)
		{
			var airE = _dbContext.AirLine_Companies.Where(r => r.Id == id).FirstOrDefault();
			var viewModel = new AirLineCompanyModel
			{
				Id = airE.Id,
				Name = airE.Name,
				Contact_Name = airE.Contact_Name,
				Address = airE.Address,

			};
			return View(viewModel);

		}

		// POST: AirLine_CompanyController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(AirLineCompanyModel airLineCompanyModel)
		{
			try
			{
				var originalAir = _dbContext.AirLine_Companies.Where(r => r.Id == airLineCompanyModel.Id).FirstOrDefault();
				// Update the Road entity with data from the viewModel
				originalAir.Id = airLineCompanyModel.Id;
				originalAir.Name = airLineCompanyModel.Name;
				originalAir.Contact_Name = airLineCompanyModel.Contact_Name;
				originalAir.Address = airLineCompanyModel.Address;

				_dbContext.SaveChanges();

				return RedirectToAction(nameof(Index));

			}
			catch
			{
				return View();
			}
		}

		// GET: AirLine_CompanyController/Delete/5
		public ActionResult Delete(int id)
		{
			var airD = _dbContext.AirLine_Companies.Where(r => r.Id == id).FirstOrDefault();

			return View(airD);

		}

		// POST: AirLine_CompanyController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(AirLine_Company airLine_Company)
		{
			try
			{
				var airDelete = _dbContext.AirLine_Companies.Where(r => r.Id == airLine_Company.Id).FirstOrDefault();



				_dbContext.Remove(airDelete);
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
