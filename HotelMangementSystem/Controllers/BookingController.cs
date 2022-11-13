using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;

namespace HotelMangementSystem.Controllers
{
    public class BookingController : Controller
    {
        private HotelDBEntities objHotelDBEntities;
        public BookingController()
        {
            objHotelDBEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            BookingViewModel objBookingViewModel = new BookingViewModel();
            objBookingViewModel.ListOfRooms = (from objRoom in objHotelDBEntities.Rooms
                                               where objRoom.BookingStatusId == 2
                                               select new SelectListItem()
                                               {
                                                   Text = objRoom.RoomNumber,
                                                   Value = objRoom.RoomId.ToString()
                                               }).ToList();
            objBookingViewModel.ListOfCustomer = (from objCustomer in objHotelDBEntities.Customer
                                                   select new SelectListItem()
                                                   {
                                                       Text = objCustomer.CustomerFirstName + objCustomer.CustomerLastName,
                                                       Value = objCustomer.CustomerId.ToString()
                                                   }).ToList();

            objBookingViewModel.BookingFrom = DateTime.Now;
            objBookingViewModel.BookingTo = DateTime.Now.AddDays(1);

            return View(objBookingViewModel);

        }
        [HttpPost]
        public ActionResult Index(BookingViewModel objBookingViewModel)
        {
            var control = objHotelDBEntities.Customer.Where(model => model.CustomerTC == objBookingViewModel.CustomerTC);
         
            int numberOfDays = Convert.ToInt32((objBookingViewModel.BookingTo - objBookingViewModel.BookingFrom).TotalDays);
            Rooms objRoom = objHotelDBEntities.Rooms.Single(model => model.RoomId == objBookingViewModel.AssignRoomId);

            decimal roomPrice = objRoom.RoomPrice;
            decimal totalAmount = roomPrice * numberOfDays;
            string message = String.Empty;
            int lastCustomerId;
            if (objBookingViewModel.BookingId == 0)
            {
                if (control != null)
                {
                    Customer objCustomer = objHotelDBEntities.Customer.Single(model => model.CustomerTC == objBookingViewModel.CustomerTC);

                    RoomBookings roomBooking = new RoomBookings()
                    {
                        BookingFrom = objBookingViewModel.BookingFrom,
                        BookingTo = objBookingViewModel.BookingTo,
                        AssignRoomId = objBookingViewModel.AssignRoomId,
                        NoOfMember = objBookingViewModel.NoOfMember,
                        TotalAmount = totalAmount,
                        CustomerId = objCustomer.CustomerId

                    };
                    objHotelDBEntities.RoomBookings.Add(roomBooking);
                }
                else
                {
                    Customer customer = new Customer()
                    {
                        CustomerFirstName = objBookingViewModel.CustomerFirstName,
                        CustomerLastName = objBookingViewModel.CustomerLastName,
                        CustomerAddress = objBookingViewModel.CustomerAddress,
                        CustomerGender = objBookingViewModel.CustomerGender,
                        CustomerPhone = objBookingViewModel.CustomerPhone,
                        CustomerTC = objBookingViewModel.CustomerTC
                    };

                    objHotelDBEntities.Customer.Add(customer);
                    objHotelDBEntities.SaveChanges();
                    lastCustomerId = objHotelDBEntities.Customer.Max(item => item.CustomerId);
                    RoomBookings roomBookings = new RoomBookings()
                    {
                        BookingFrom = objBookingViewModel.BookingFrom,
                        BookingTo = objBookingViewModel.BookingTo,
                        AssignRoomId = objBookingViewModel.AssignRoomId,
                        NoOfMember = objBookingViewModel.NoOfMember,
                        TotalAmount = totalAmount,
                        CustomerId = lastCustomerId

                    };

                    objHotelDBEntities.RoomBookings.Add(roomBookings);


                }
            }
            else
            {
                RoomBookings objBooking = objHotelDBEntities.RoomBookings.Single(model => model.BookingId == objBookingViewModel.BookingId);
                Customer objcustomer = objHotelDBEntities.Customer.Single(model => model.CustomerId == objBookingViewModel.CustomerId);
                objBooking.BookingFrom = objBookingViewModel.BookingFrom;
                objBooking.BookingTo = objBookingViewModel.BookingTo;
                objBooking.AssignRoomId = objBookingViewModel.AssignRoomId;
                objBooking.NoOfMember = objBookingViewModel.NoOfMember;
                objBooking.TotalAmount = objBookingViewModel.TotalAmount;
                objcustomer.CustomerFirstName = objBookingViewModel.CustomerFirstName;
                objcustomer.CustomerLastName = objBookingViewModel.CustomerLastName;
                objcustomer.CustomerAddress = objBookingViewModel.CustomerAddress;
                objcustomer.CustomerGender = objBookingViewModel.CustomerGender;
                objcustomer.CustomerPhone = objBookingViewModel.CustomerPhone;
                objcustomer.CustomerTC = objBookingViewModel.CustomerTC;


                message = "Güncellendi";


                
            }

            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "İşlem Başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult EditBookingDetails(int bookingId)
        {
            var result = objHotelDBEntities.RoomBookings.Single(model => model.BookingId == bookingId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllBookingHistory()
        {
          
           
            List<RoomBookingViewModel> listOfBookingViewModels = new List<RoomBookingViewModel>();
            listOfBookingViewModels = (from objHotelBooking in objHotelDBEntities.RoomBookings
                                       join objRoom in objHotelDBEntities.Rooms on objHotelBooking.AssignRoomId equals objRoom.RoomId join
                                       objCustomer in objHotelDBEntities.Customer on objHotelBooking.CustomerId equals objCustomer.CustomerId
                                       select new RoomBookingViewModel()
                                       {
                                           BookingFrom = objHotelBooking.BookingFrom,
                                           BookingTo = objHotelBooking.BookingTo,
                                           RoomPrice = objRoom.RoomPrice,
                                           TotalAmount = objHotelBooking.TotalAmount,
                                           CustomerId = objHotelBooking.CustomerId,
                                           NoOfMember = objHotelBooking.NoOfMember,
                                           BookingId = objHotelBooking.BookingId,
                                           RoomNumber = objRoom.RoomNumber,
                                           CustomerName = objCustomer.CustomerFirstName +" "+ objCustomer.CustomerLastName,
                                           NumberOfDays = System.Data.Entity.DbFunctions.DiffDays(objHotelBooking.BookingFrom,objHotelBooking.BookingTo).Value

                                       }).ToList();
            return PartialView("_BookingHistoryPartial",listOfBookingViewModels);
        }
        [HttpGet]
        public JsonResult DeleteBookingDetails(int bookingId)
        {
            RoomBookings objBooking = objHotelDBEntities.RoomBookings.Single(model => model.BookingId == bookingId);
            objHotelDBEntities.RoomBookings.Remove(objBooking);
            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}