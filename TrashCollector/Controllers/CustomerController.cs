using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;
        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(context.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customerDetails = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(customerDetails);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var customer = new Customer();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                string id = User.Identity.GetUserId();
                customer.ApplicationId = id;
                context.Customers.Add(customer);
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
            var editCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(editCustomer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var editCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                editCustomer.FirstName = customer.FirstName;
                editCustomer.LastName = customer.LastName;
                editCustomer.StreetAdress = customer.StreetAdress;
                editCustomer.City = customer.City;
                editCustomer.State = customer.State;
                editCustomer.ZipCode = customer.ZipCode;
                editCustomer.PickupDay = customer.PickupDay;
                editCustomer.Balance = customer.Balance;
                editCustomer.MonthlyCharge = customer.MonthlyCharge;
                editCustomer.PickupConfirmed = customer.PickupConfirmed;
                editCustomer.StartDate = customer.StartDate;
                editCustomer.EndDate = customer.EndDate;

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
            var deleteCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(deleteCustomer);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                if(customer == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var deletedCustomer = context.Customers.Where(c => c.Id == id).FirstOrDefault();
                    context.Customers.Remove(deletedCustomer);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
