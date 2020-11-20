using DomainModels;
using DomainModels.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        IUnitOfWork uow;
        public EmployeeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = uow.EmployeeRepo.GetAll();
            return View(employees);
        }

        public ActionResult Create()
        {
            BindDepartments();
            return View();
        }

        private void BindDepartments()
        {
            ViewBag.Departments = (from Enums.Designation e in Enum.GetValues(typeof(Enums.Designation))
                                   select new
                                   {
                                       ID = (int)e,
                                       Name = e.ToString()
                                   });
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                uow.EmployeeRepo.Add(employee);
                uow.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Model");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            if (Id == 0)
                ModelState.AddModelError("Id", "Id Parameter is null!");

            BindDepartments();
            Employee employee = uow.EmployeeRepo.GetById(Id);

            return View("Create", employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                uow.EmployeeRepo.Update(employee);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                BindDepartments();
                ModelState.AddModelError("", "Invalid Model");
            }
            BindDepartments();
            return View("Create", employee);
        }
    }
}