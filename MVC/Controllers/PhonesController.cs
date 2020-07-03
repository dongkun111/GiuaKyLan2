using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PhonesController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            IEnumerable<mvcPhonesModel> empList;
            HttpResponseMessage response = Bientoancuc.WebApiClient.GetAsync("Phones").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcPhonesModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id ==0 )
            return View(new mvcPhonesModel());
            else
            {
                HttpResponseMessage response = Bientoancuc.WebApiClient.GetAsync("Phones/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPhonesModel>().Result);
            }

        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcPhonesModel emp)
        {
            if (emp.ID == 0)
            {
                HttpResponseMessage response = Bientoancuc.WebApiClient.PostAsJsonAsync("Phones", emp).Result;
                TempData["SuccessMessage"] = "Save Successfully!";
            }
            else
            {
                HttpResponseMessage response = Bientoancuc.WebApiClient.PutAsJsonAsync("Phones/"+emp.ID, emp).Result;
                TempData["SuccessMessage"] = "Update Successfully!";

            }
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = Bientoancuc.WebApiClient.DeleteAsync("Phones/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Dekete Successfully!";
            return RedirectToAction("Index");

        }
    }
}