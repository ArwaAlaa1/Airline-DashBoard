using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace AirLine.Controllers
{
    public class RoadController : Controller
    {
        private readonly DBContext _dBContext;

        public RoadController(DBContext dBContext)
        {
			_dBContext= dBContext;


		}
        // GET: RoadController
        public ActionResult Index()
        {
			var roads = _dBContext.Roads.ToList();

			var roadmodel = new List<RoadModel>();
			foreach (var road in roads)
			{
				var viewModel = new RoadModel()
				{
					Id = road.Id,
					Origin = road.Origin,
					Distance = road.Distance,
					Distination = road.Distination,
					Classification = road.Classification,
					CreatedDate = road.CreatedDate,
					UpdatedDate = road.UpdatedDate,
					IsDeleted = road.IsDeleted,
					IsVisable = road.IsVisable,
				};
				roadmodel.Add(viewModel);
			}
			return View(roadmodel);

        }

        // GET: RoadController/Details/5
        public ActionResult Details(int id)
        {
			var roadDE = _dBContext.Roads.Where(r => r.Id == id).FirstOrDefault();

			return View(roadDE);
        }

        // GET: RoadController/Create
        public ActionResult Create()
        { 
             var viewModel = new RoadModel();

			return View(viewModel);
        }

        // POST: RoadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoadModel roadModel)
        {
            try
            {
                Road road1=new Road() { 
                    Id= roadModel.Id,
                    Origin= roadModel.Origin,
                    Distance= roadModel.Distance,
                    Distination= roadModel.Distination,
                    Classification= roadModel.Classification,
                    CreatedDate=DateTime.Now,
                    UpdatedDate=DateTime.Now,
                    IsDeleted=false,
                    IsVisable=true,


                };
                _dBContext.Add(road1);
                //_dBContext.Roads.Add(road1);
                _dBContext.SaveChanges();

				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoadController/Edit/5
        public ActionResult Edit(int id)
        {
           var roadE= _dBContext.Roads.Where(r => r.Id == id).FirstOrDefault();
			var viewModel = new RoadModel
			{
				Id = roadE.Id,
				Origin = roadE.Origin,
				Distination = roadE.Distination,
				Distance = roadE.Distance,
				Classification = roadE.Classification,
                IsVisable= roadE.IsVisable,
                IsDeleted = roadE.IsDeleted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
			};

			return View(viewModel);
			
		}
       
		// POST: RoadController/Edit/5
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoadModel roadModel)
        {
            try
            {

				var originalRoad = _dBContext.Roads.Where(r => r.Id == roadModel.Id).FirstOrDefault();

				originalRoad.Id= roadModel.Id;
				originalRoad.Origin = roadModel.Origin;
				originalRoad.Distination = roadModel.Distination;
				originalRoad.Distance = roadModel.Distance;
				originalRoad.Classification = roadModel.Classification;
                originalRoad.IsVisable = roadModel.IsVisable;
                originalRoad.IsDeleted = roadModel.IsDeleted;
                originalRoad.CreatedDate = roadModel.CreatedDate;
                originalRoad.UpdatedDate = roadModel.UpdatedDate;


                
                _dBContext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: RoadController/Delete/5
        public ActionResult Delete(int id)
        {
			var roadD = _dBContext.Roads.Where(r => r.Id == id).FirstOrDefault();
			
			return View(roadD);
			
        }

        // POST: RoadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Road road)
        {
            try
            {
				var RoadDelete = _dBContext.Roads.Where(r => r.Id == road.Id).FirstOrDefault();
				_dBContext.Roads.Remove(RoadDelete);
			
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
