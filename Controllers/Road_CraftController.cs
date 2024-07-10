using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirLine.Controllers
{
    public class Road_CraftController : Controller
    {
        private readonly DBContext _dBContext;

        public Road_CraftController(DBContext dBContext)
        {
            _dBContext = dBContext;
        }
        // GET: Road_CraftController1
        public ActionResult Index()
        {
           // var roadCrafts1 = _dBContext.Road_Crafts
           //.Include(rc => rc.RouteId )
           //.Include(rc => rc.AirCraftId)
           //.ToList();

            var roadCrafts = _dBContext.Road_Crafts.ToList();
            var RoCrafModel = new List<Road_CraftModel>();
            foreach (var road in roadCrafts)
            {



                var viewModel = new Road_CraftModel()
                {

                    RouteId = road.RouteId,
                    AirCraftId = road.AirCraftId,
                    DepatureTime = road.DepatureTime,
                    ArrivalTime = road.ArrivalTime,
                    NumPassenger = road.NumPassenger,
                    Price = road.Price,
                    CreatedDate = road.CreatedDate,
                    UpdatedDate = road.UpdatedDate,
                    IsDeleted = road.IsDeleted,
                    IsVisable = road.IsVisable,
                };
                RoCrafModel.Add(viewModel);

            }

            return View(RoCrafModel);

        }

        // GET: Road_CraftController1/Details/5
        public ActionResult Details(int id)
        {
            var RoCraftDE = _dBContext.Road_Crafts.Where(r => r.Id == id).FirstOrDefault();

            return View(RoCraftDE);
        }

        // GET: Road_CraftController1/Create
        public ActionResult Create()
        {
            Road_CraftModel CraftModel = new Road_CraftModel();
            var airline = _dBContext.AirCrafts.ToList();
            var roads = _dBContext.Roads.ToList();
            CraftModel.AirCRS= airline;
            CraftModel.RDs = roads;
            return View(CraftModel);
        }

        // POST: Road_CraftController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Road_CraftModel road_CraftModel)
        {
            try
            {
                Road_Craft craftR = new Road_Craft()
                {
                   RouteId= road_CraftModel.RouteId,
                   AirCraftId= road_CraftModel.AirCraftId,
                    DepatureTime = road_CraftModel.DepatureTime,
                    ArrivalTime = road_CraftModel.ArrivalTime,
                    NumPassenger = road_CraftModel.NumPassenger,
                    Price = road_CraftModel.Price,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    IsVisable = true,


                };
                craftR.IsDeleted = false;
                craftR.IsVisable = true;
                _dBContext.Add(craftR);

                _dBContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Road_CraftController1/Edit/5
        public ActionResult Edit(int id)
        {
            //Road_CraftModel TranModel = new Road_CraftModel();
            var craft = _dBContext.AirCrafts.ToList();
            //TransactionModel TranModel = new TransactionModel();
            var road = _dBContext.Roads.ToList();

            var CraftE = _dBContext.Road_Crafts.Where(r => r.Id == id).FirstOrDefault();
            var viewModel = new Road_CraftModel
            {
                RouteId= CraftE.RouteId,
                AirCraftId= CraftE.AirCraftId,
                DepatureTime = CraftE.DepatureTime,
                ArrivalTime = CraftE.ArrivalTime,
                NumPassenger = CraftE.NumPassenger,
                Price = CraftE.Price,

                IsDeleted = CraftE.IsDeleted,
                IsVisable = CraftE.IsVisable,
                CreatedDate = CraftE.CreatedDate,
                UpdatedDate = CraftE.UpdatedDate,
            };
            viewModel.AirCRS = craft;
            viewModel.RDs = road;
            return View(viewModel);
        }

        // POST: Road_CraftController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Road_CraftModel road_CraftModel)
        {
            try
            {

                var originalRoad = _dBContext.Road_Crafts.Where(r => r.Id == road_CraftModel.RouteId).FirstOrDefault();


                originalRoad.RouteId = road_CraftModel.RouteId;
                originalRoad.AirCraftId = road_CraftModel.AirCraftId;
                originalRoad.DepatureTime = road_CraftModel.DepatureTime;
                originalRoad.ArrivalTime = road_CraftModel.ArrivalTime;
                originalRoad.NumPassenger = road_CraftModel.NumPassenger;
                originalRoad.Price = road_CraftModel.Price;

                originalRoad.IsVisable = road_CraftModel.IsVisable;
                originalRoad.IsDeleted = road_CraftModel.IsDeleted;
                originalRoad.CreatedDate = road_CraftModel.CreatedDate;
                originalRoad.UpdatedDate = road_CraftModel.UpdatedDate;



                _dBContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Road_CraftController1/Delete/5
        public ActionResult Delete(int id)
        {
            var ROCD = _dBContext.Road_Crafts.Where(r => r.Id == id).FirstOrDefault();
            return View(ROCD);
        }

        // POST: Road_CraftController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Road_Craft road_Craft)
        {
            try
            {

                var RCDelete = _dBContext.Road_Crafts.Where(r => r.Id == road_Craft.Id).FirstOrDefault();
                _dBContext.Road_Crafts.Remove(RCDelete);

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
