using lstoneCrud.Models;
using lstoneCrud.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lstoneCrud.Controllers
{
    public class customerController : Controller
    {
        customerDAL cstmDAL = new customerDAL();
        // GET: customer
        public ActionResult List()
        {
            var data = cstmDAL.GetCustomers();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(customermodel customer)
        {

            if (cstmDAL.InsertCustomer(customer))
            {
                TempData["InsertMsg"] = "<script>Data Saved Successfully.......</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["ErrorErrorMsg"] = "Data not saved.......";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = cstmDAL.GetCustomers().Find(item => item.id == id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = cstmDAL.GetCustomers().Find(item => item.id == id);
            return View(data);
        }
        
        [HttpPost]
        public ActionResult Edit(customermodel customer)
        {

            if (cstmDAL.UpdateCustomer(customer))
            {
                TempData["UpdateMsg"] = "<script>alert('Data Updated Successfully .......')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["UpdateErrorMsg"] = "<script>alert('Data not updated.......')</script>";
            }
            return View();
        }

        //[HttpPost]
        public ActionResult Delete(int id)
        {
            int r = cstmDAL.DeleteCustomer(id);
            if (r>0)
            {
                TempData["DeleteMsg"] = "<script>alert('Data deleted Successfully.......')</script>";
                return RedirectToAction("List");
            }
            else
            {
                TempData["DeleteErrorMsg"] = "<script>alert('Data not deleted.......')</script>";
            }
            return View();
        }
    }
}