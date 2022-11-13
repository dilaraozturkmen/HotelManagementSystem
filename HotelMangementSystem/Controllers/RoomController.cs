using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace HotelMangementSystem.Controllers
{
    public class RoomController : Controller
    {
        private HotelDBEntities objhotelDbEntities;

        public RoomController()
        {

            objhotelDbEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            RoomViewModel objRoomViewModel = new RoomViewModel();
            objRoomViewModel.ListOfBookingStatus = (from obj in objhotelDbEntities.BookingStatus
                                                    select new SelectListItem()
                                                    {
                                                        Text = obj.Bookingstatus,
                                                        Value = obj.BookingStatusId.ToString()
                                                    }).ToList();
            objRoomViewModel.ListOfRoomType = (from obj in objhotelDbEntities.RoomType
                                               select new SelectListItem()
                                               {
                                                   Text = obj.RooomTypeName,
                                                   Value = obj.RoomTypeId.ToString()
                                               }).ToList();
            ViewBag.listOfBookingStatus = objRoomViewModel.ListOfBookingStatus;
            ViewBag.listOfRoomType = objRoomViewModel.ListOfRoomType;

            return View();
        }
        [HttpPost]

        public ActionResult Index(RoomViewModel objRoomViewModel)
        {
            string message = String.Empty;
            string ImageUniqueName = String.Empty;
            string ActualImageName = String.Empty;
            if (objRoomViewModel.RoomId == 0)
            {
                ImageUniqueName = Guid.NewGuid().ToString();
                ActualImageName = ImageUniqueName + Path.GetExtension(objRoomViewModel.Image.FileName);
                objRoomViewModel.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));

                //obsHotelDbEntities
                Rooms objRoom = new Rooms()
                {
                    RoomNumber = objRoomViewModel.RoomNumber,
                    RoomDescription = objRoomViewModel.RoomDescription,
                    RoomPrice = objRoomViewModel.RoomPrice,
                    BookingStatusId = objRoomViewModel.BookingStatusId,
                    IsActive = true,
                    RoomImage = ActualImageName,
                    RoomCapacity = objRoomViewModel.RoomCapacity,
                    RoomTypeId = objRoomViewModel.RoomTypeId

                };

                objhotelDbEntities.Rooms.Add(objRoom);
                message = "Eklendi";
            }
            else
            {
                Rooms objRoom = objhotelDbEntities.Rooms.Single(model => model.RoomId == objRoomViewModel.RoomId);
                if (objRoomViewModel.Image != null)
                {
                    ImageUniqueName = Guid.NewGuid().ToString();
                    ActualImageName = ImageUniqueName + Path.GetExtension(objRoomViewModel.Image.FileName);
                    objRoomViewModel.Image.SaveAs(filename: Server.MapPath("~/RoomImages/" + ActualImageName));
                    objRoom.RoomImage = ActualImageName;
                }


                objRoom.RoomNumber = objRoomViewModel.RoomNumber;
                objRoom.RoomDescription = objRoomViewModel.RoomDescription;
                objRoom.RoomPrice = objRoomViewModel.RoomPrice;
                objRoom.BookingStatusId = objRoomViewModel.BookingStatusId;
                objRoom.IsActive = true;

                objRoom.RoomCapacity = objRoomViewModel.RoomCapacity;
                objRoom.RoomTypeId = objRoomViewModel.RoomTypeId;
                message = "Güncellendi";
            }
            objhotelDbEntities.SaveChanges();

            return Json(data: new { message = "İşlem Başarılı" + message, success = true }, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetAllRooms()
        {
            IEnumerable<RoomDetailsViewModel> ListOfRoomDetailsViewModels =
                (from objRoom in objhotelDbEntities.Rooms
                 join objBooking in objhotelDbEntities.BookingStatus on objRoom.BookingStatusId equals objBooking.BookingStatusId
                 join objRoomType in objhotelDbEntities.RoomType on objRoom.RoomTypeId equals objRoomType.RoomTypeId
                 where objRoom.IsActive == true
                 select new RoomDetailsViewModel()
                 {
                     RoomNumber = objRoom.RoomNumber,
                     RoomDescription = objRoom.RoomDescription,
                     RoomCapacity = objRoom.RoomCapacity,
                     RoomPrice = objRoom.RoomPrice,
                     BookingStatus = objBooking.Bookingstatus,
                     RoomType = objRoomType.RooomTypeName,
                     RoomImage = objRoom.RoomImage,
                     RoomId = objRoom.RoomId
                 }).ToList();
            return PartialView("_RoomDetailsPartial", ListOfRoomDetailsViewModels);
        }
        [HttpGet]
        public JsonResult EditRoomDetails(int roomId)
        {
            var result = objhotelDbEntities.Rooms.Single(model => model.RoomId == roomId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteRoomDetails(int roomId)
        {
            Rooms objRoom = objhotelDbEntities.Rooms.Single(model => model.RoomId == roomId);
            objRoom.IsActive = false;
            objhotelDbEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }



    }
}