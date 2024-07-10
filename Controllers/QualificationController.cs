using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AirLine.Controllers
{
	public class QualificationController : Controller
	{
		private readonly DBContext _dbContext;
		public QualificationController(DBContext dbContext)
		{
			_dbContext = dbContext;
		}
		// GET: QualificationController
		public ActionResult Index()
		{
			var Qs = _dbContext.EmpQualifications.ToList();

			var viewModelList = new List<QualificationsModel>();
			foreach (var q in Qs)
			{
				var viewModel = new QualificationsModel()
				{
					EmployeeId = q.EmployeeId,
					Qualification = q.Qualification
				};
				viewModelList.Add(viewModel);
			}
			return View(viewModelList);

		}

		// GET: QualificationController/Details/5
		public ActionResult Details(int id)
		{

			return View();
		}

		// GET: QualificationController/Create
		public ActionResult Create()
		{
			QualificationsModel qual = new QualificationsModel();
			var qualification = _dbContext.Employees.ToList();
			qual.Employees = qualification;
			return View(qual);
		}

		// POST: QualificationController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(QualificationsModel qualifcationsModel)
		{
			try
			{
				Emp_Qualification _Qualification = new Emp_Qualification()
				{
					EmployeeId = qualifcationsModel.EmployeeId,
					Qualification = qualifcationsModel.Qualification
				};

				_dbContext.Add(_Qualification);
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
