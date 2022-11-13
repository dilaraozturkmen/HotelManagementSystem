using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangementSystem.Controllers
{
    public class CustomerController : Controller
    {
        private HotelDBEntities objHotelDBEntities;
        public CustomerController()
        {
            objHotelDBEntities = new HotelDBEntities();
        }
 
        // GET: Customer
        public ActionResult Index()
        {
            CustomerViewModel objCustomerViewModel = new CustomerViewModel();
            objCustomerViewModel.ListOfCustomer = (from objCustomer in objHotelDBEntities.Customer
                                                   select new SelectListItem()
                                                   {
                                                       Text = objCustomer.CustomerFirstName + objCustomer.CustomerLastName,
                                                       Value = objCustomer.CustomerId.ToString()
                                                   }).ToList();


            return View(objCustomerViewModel);
        }
        [HttpPost]
        public ActionResult Index(CustomerViewModel objCustomerViewModel)
        {
            string message = String.Empty;
            if (objCustomerViewModel.CustomerId == 0)
            {
                Customer customer = new Customer()
                {
                    CustomerAddress = objCustomerViewModel.CustomerAddress,
                    CustomerFirstName = objCustomerViewModel.CustomerFirstName,
                    CustomerLastName = objCustomerViewModel.CustomerLastName,
                    CustomerPhone = objCustomerViewModel.CustomerPhone,
                    CustomerTC = objCustomerViewModel.CustomerTC,
                    CustomerGender = objCustomerViewModel.CustomerGender

                };
                objHotelDBEntities.Customer.Add(customer);
            }
            else
            {
                Customer objCustomer = objHotelDBEntities.Customer.Single(model => model.CustomerId == objCustomerViewModel.CustomerId);
                objCustomer.CustomerFirstName = objCustomerViewModel.CustomerFirstName;
                objCustomer.CustomerAddress = objCustomerViewModel.CustomerAddress;
                objCustomer.CustomerLastName = objCustomerViewModel.CustomerLastName;
                objCustomer.CustomerPhone = objCustomerViewModel.CustomerPhone;
                objCustomer.CustomerTC = objCustomerViewModel.CustomerTC;
                objCustomer.CustomerGender = objCustomerViewModel.CustomerGender;
            }
            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "İşlem Başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult EditCustomerDetails(int customerId)
        {
            var result = objHotelDBEntities.Customer.Single(model => model.CustomerId == customerId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllCustomerHistory()
        {
            List<CustomerViewModel> listOfCustomerViewModels = new List<CustomerViewModel>();
            listOfCustomerViewModels = (from objHotelCustomer in objHotelDBEntities.Customer
                                        select new CustomerViewModel()
                                        {
                                            CustomerPhone = objHotelCustomer.CustomerPhone,
                                            CustomerFirstName = objHotelCustomer.CustomerFirstName,
                                            CustomerLastName = objHotelCustomer.CustomerLastName,
                                            CustomerAddress = objHotelCustomer.CustomerAddress,
                                            CustomerTC = objHotelCustomer.CustomerTC,
                                            CustomerGender = objHotelCustomer.CustomerGender,
                                            CustomerId = objHotelCustomer.CustomerId
                                        }).ToList();
            return PartialView("_CustomerDetailsPartial", listOfCustomerViewModels);
        }
        [HttpGet]
        public JsonResult DeleteCustomerDetails(int customerId)
        {
            Customer objCustomer = objHotelDBEntities.Customer.Single(model => model.CustomerId == customerId);
            objHotelDBEntities.Customer.Remove(objCustomer);
            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}