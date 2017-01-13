using CRUDWebApi_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWebApi_Client.ViewModels;

namespace CRUDWebApi_Client.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            EmployeeClient pc = new EmployeeClient();
            ViewBag.listEmployee = pc.findAll();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModels evm)
        {
            EmployeeClient pc = new EmployeeClient();
            pc.Create(evm.Employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(decimal id)
        {
            EmployeeClient pc = new EmployeeClient();
            pc.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(decimal id)
        {
            EmployeeClient pc = new EmployeeClient();
            EmployeeViewModels evm = new EmployeeViewModels();
            int eID = Convert.ToInt16(id);
            evm.Employee = pc.find(eID);
            return View("Edit",evm);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModels evm)
        {
            EmployeeClient pc = new EmployeeClient();
            pc.Edit(evm.Employee);
            return RedirectToAction("Index");
        }
    }
}