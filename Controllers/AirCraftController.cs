using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirLine.Controllers
{
    public class AirCraftController : Controller
    {
        private readonly DBContext _dBContext;
        public AirCraftController(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        // GET: AirCraftController
        public ActionResult Index()
        {
			var airCrafts = _dBContext.AirCrafts.ToList();

			var AirCrafmodel = new List<AirCraftModel>();
			foreach (var craft in airCrafts)
			{
				var viewModel = new AirCraftModel()
				{
					Id = craft.Id,
					Model = craft.Model,
					Capacity = craft.Capacity,
					Major_Poilot = craft.Major_Poilot,
					Assistant_Pilot = craft.Assistant_Pilot,
					Host1 = craft.Host1,
					Host2 = craft.Host2,
					AirlineId = craft.AirlineId,
					UpdatedDate = craft.UpdatedDate,
                    CreatedDate= craft.CreatedDate,
					IsDeleted = craft.IsDeleted,
					IsVisable = craft.IsVisable,
				};
				AirCrafmodel.Add(viewModel);
			}
			return View(AirCrafmodel);
			
        }

        // GET: AirCraftController/Details/5
        public ActionResult Details(int id)
        {
            var CraftDE = _dBContext.AirCrafts.Where(r => r.Id == id).FirstOrDefault();

            return View(CraftDE);
        }

        // GET: AirCraftController/Create
        public ActionResult Create()
        {
            AirCraftModel AirModel = new AirCraftModel();
            var airline = _dBContext.AirLine_Companies.ToList();
            AirModel.AirLines = airline;
            return View(AirModel);
        }

        // POST: AirCraftController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AirCraftModel airCraftModel)
        {
            try
            {
                AirCraft air = new AirCraft()
                {
                    Id = airCraftModel.Id,
                    Model = airCraftModel.Model,
                    Capacity = airCraftModel.Capacity,
                    Major_Poilot = airCraftModel.Major_Poilot,
                    Assistant_Pilot = airCraftModel.Assistant_Pilot,
                    Host1 = airCraftModel.Host1,
                    Host2 = airCraftModel.Host2,
                    AirlineId= airCraftModel.AirlineId,

					CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    IsVisable = true,


                };
                air.IsDeleted = false;
                air.IsVisable = true;
                _dBContext.Add(air);
                //_dBContext.AirCrafts.Add(air);
                _dBContext.SaveChanges();

               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirCraftController/Edit/5
        public ActionResult Edit(int id)
        {
            AirCraftModel AirModel = new AirCraftModel();
            var airline = _dBContext.AirLine_Companies.ToList();
           
            var CraftE = _dBContext.AirCrafts.Where(r => r.Id == id).FirstOrDefault();
            var viewModel = new AirCraftModel
            {
                Id = CraftE.Id,
                Model = CraftE.Model,
                Capacity = CraftE.Capacity,
                Major_Poilot = CraftE.Major_Poilot,
                Assistant_Pilot = CraftE.Assistant_Pilot,
                Host1 = CraftE.Host1,
                Host2 = CraftE.Host2,
               AirlineId=CraftE.AirlineId,
                IsDeleted = CraftE.IsDeleted,
                IsVisable = CraftE.IsVisable,
                CreatedDate = CraftE.CreatedDate,
                UpdatedDate = CraftE.UpdatedDate,
            };
            viewModel.AirLines = airline;
            return View(viewModel);
        }

        // POST: AirCraftController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AirCraftModel craftModel)
        {
            try
            {
                var originalRoad = _dBContext.AirCrafts.Where(r => r.Id == craftModel.Id).FirstOrDefault();


                originalRoad.Id = craftModel.Id;
                originalRoad.Model = craftModel.Model;
                originalRoad.Capacity = craftModel.Capacity;
                originalRoad.Major_Poilot = craftModel.Major_Poilot;
                originalRoad.Assistant_Pilot = craftModel.Assistant_Pilot;
                originalRoad.Host1 = craftModel.Host1;
                originalRoad.Host2 = craftModel.Host2;
                originalRoad.AirlineId = craftModel.AirlineId;


                originalRoad.IsVisable = craftModel.IsVisable;
                originalRoad.IsDeleted = craftModel.IsDeleted;
                originalRoad.CreatedDate = craftModel.CreatedDate;
                originalRoad.UpdatedDate = craftModel.UpdatedDate;



                _dBContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AirCraftController/Delete/5
        public ActionResult Delete(int id)
        {
            var CraftD = _dBContext.AirCrafts.Where(r => r.Id == id).FirstOrDefault();
            return View(CraftD);
        }

        // POST: AirCraftController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AirCraft airCraft)
        {
            try
            {

                var CraftDelete = _dBContext.AirCrafts.Where(r => r.Id == airCraft.Id).FirstOrDefault();
                _dBContext.AirCrafts.Remove(CraftDelete);

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
