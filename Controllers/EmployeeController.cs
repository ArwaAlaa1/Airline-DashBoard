using AirLine.Models;
using AirLine.MyDBContext;
using AirLine.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirLine.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DBContext _dbContext;
        public EmployeeController(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var emps = _dbContext.Employees.ToList();

            var viewModelList = new List<EmployeeModel>();
            foreach (var employee in emps)
            {
                var viewModel = new EmployeeModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address,
                    BDDay = employee.BDDay,
                    BDMonth = employee.BDMonth,
                    BDYear = employee.BDYear,
                    Gender = employee.Gender,
                    Position = employee.Position,
                    AirLineId = employee.AirLineId,
                    IsVisible = employee.IsVisable,

                    CreatedDate = employee.CreatedDate,
                    UpdatedDate = employee.UpdatedDate
                };
                viewModelList.Add(viewModel);
            }
            return View(viewModelList);
        }

        public ActionResult Details(int id)
        {

            var empDE = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

            return View(empDE);

        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            EmployeeModel employee = new EmployeeModel();
            var airs = _dbContext.AirLine_Companies.ToList();
            employee.AirLines_list = airs;
            return View(employee);
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel empmodel)
        {
            try
            {
                Employee emp = new Employee()
                {
                    Id = empmodel.Id,
                    Name = empmodel.Name,
                    Address = empmodel.Address,
                    BDDay = empmodel.BDDay,
                    BDMonth = empmodel.BDMonth,
                    BDYear = empmodel.BDYear,
                    Gender = empmodel.Gender,
                    Position = empmodel.Position,
                    AirLineId = empmodel.AirLineId,
                    IsVisable = empmodel.IsVisible,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                emp.IsVisable = true;
                emp.IsDeleted = false;
                _dbContext.Add(emp);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            TransactionModel TranModel = new TransactionModel();
            var airline = _dbContext.AirLine_Companies.ToList();
            var empE = _dbContext.Employees.Where(r => r.Id == id).FirstOrDefault();
            var viewModel = new EmployeeModel
            {
                Id = empE.Id,
                Name = empE.Name,
                Address = empE.Address,
                BDDay = empE.BDDay,
                BDMonth = empE.BDMonth,
                BDYear = empE.BDYear,
                Gender = empE.Gender,
                Position = empE.Position,
                AirLineId = empE.AirLineId,

            };
            viewModel.AirLines_list = airline;
            return View(viewModel);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {

                var originalEmp = _dbContext.Employees.Where(r => r.Id == employeeModel.Id).FirstOrDefault();
                // Update the Road entity with data from the viewModel
                originalEmp.Id = employeeModel.Id;
                originalEmp.Name = employeeModel.Name;
                originalEmp.Address = employeeModel.Address;
                originalEmp.BDDay = employeeModel.BDDay;
                originalEmp.BDMonth = employeeModel.BDMonth;
                originalEmp.BDYear = employeeModel.BDYear;
                originalEmp.Gender = employeeModel.Gender;
                originalEmp.Position = employeeModel.Position;
                originalEmp.AirLineId = employeeModel.AirLineId;

                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var empD = _dbContext.Employees.Where(r => r.Id == id).FirstOrDefault();
            return View(empD);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                var empDelete = _dbContext.Employees.Where(r => r.Id == employee.Id).FirstOrDefault();



                _dbContext.Remove(empDelete);
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
