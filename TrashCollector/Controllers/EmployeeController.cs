using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DateTime.Today.DayOfWeek).ToList();
            return View(customerZipCode);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var employeeDetails = context.Employees.Where(c => c.Id == id).FirstOrDefault();
            return View(employeeDetails);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                employee.ApplicationId = id;
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var editEmployee = context.Employees.Where(c => c.Id == id).FirstOrDefault();
            return View(editEmployee);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                // TODO: Add update logic here
                var editEmployee = context.Employees.Where(c => c.Id == id).FirstOrDefault();
                editEmployee.ZipCode = employee.ZipCode;
                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteEmployee = context.Employees.Where(c => c.Id == id).FirstOrDefault();
            return View(deleteEmployee);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                if (employee == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var deletedEmployee = context.Employees.Where(c => c.Id == id).FirstOrDefault();
                    context.Employees.Remove(deletedEmployee);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ConfirmPickupCustomerCharge(int id)
        {

            var editCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(editCustomer);
        }

        [HttpPost]
        public ActionResult ConfirmPickupCustomerCharge(int id, Customer customer)
        {
            try
            {
                var editCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                editCustomer.PickupConfirmed = customer.PickupConfirmed;
                editCustomer.MonthlyCharge = customer.MonthlyCharge;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MondayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Monday).ToList();
            return View(customerZipCode);
        }

        public ActionResult TuesdayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Tuesday).ToList();
            return View(customerZipCode);
        }

        public ActionResult WednesdayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Wednesday).ToList();
            return View(customerZipCode);
        }

        public ActionResult ThursdayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Thursday).ToList();
            return View(customerZipCode);
        }

        public ActionResult FridayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Friday).ToList();
            return View(customerZipCode);
        }

        public ActionResult SaturdayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Saturday).ToList();
            return View(customerZipCode);
        }

        public ActionResult SundayPickup()
        {
            var employeeId = User.Identity.GetUserId();
            var employee = context.Employees.Where(e => e.ApplicationId == employeeId).FirstOrDefault();
            var customerZipCode = context.Customers.Where(c => c.ZipCode == employee.ZipCode && c.WeeklyPickupDay == DayOfWeek.Sunday).ToList();
            return View(customerZipCode);
        }

        public ActionResult Pickups()
        {
            return View();
        }
    }
}