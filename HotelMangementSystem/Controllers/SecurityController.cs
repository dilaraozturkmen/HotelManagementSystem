using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HotelMangementSystem.Controllers
{
    public class SecurityController : Controller
    {
        private HotelDBEntities objHotelDBEntities;
        public SecurityController()
        {
            objHotelDBEntities = new HotelDBEntities();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(EmployeeViewModel objEmployeeViewModel)
        {
            var bilgiler = objHotelDBEntities.Employee.FirstOrDefault(model => model.EmployeeUserName == objEmployeeViewModel.EmployeeUserName && model.EmployeePassword == objEmployeeViewModel.EmployeePassword);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.EmployeeUserName, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}