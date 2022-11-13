using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangementSystem.Controllers
{
    public class HousekeepingController : Controller
    {
        private HotelDBEntities objhotelDbEntities;
        public HousekeepingController()
        {
            objhotelDbEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            HousekeepingViewModel objHousekeepingViewModel = new HousekeepingViewModel();
            objHousekeepingViewModel.ListOfHousekeepingStatus = (from obj in objhotelDbEntities.HousekeepingStatus
                                                                
                                                                 select new SelectListItem()
                                                                 {
                                                                     Text = obj.HousekeepingStatus1,
                                                                     Value = obj.HousekeepingStatusId.ToString()
                                                                 }).ToList();

            
            return View(objHousekeepingViewModel);
        }
        [HttpPost]

        public ActionResult Index(HousekeepingViewModel objHousekeepingViewModel)
        {
            if(objHousekeepingViewModel.HousekeepingId== 0)
            {
                Housekeeping objHousekeeping = new Housekeeping()
                {
                    RoomNumber = objHousekeepingViewModel.RoomNumber,
                    HousekeepingStatusId = objHousekeepingViewModel.HousekeepingStatusId,
                    HousekeepingNote = objHousekeepingViewModel.HousekeepingNote
                };
                objhotelDbEntities.Housekeeping.Add(objHousekeeping);

            }
            else
            {
                Housekeeping objHousekeeping = objhotelDbEntities.Housekeeping.Single(model => model.HousekeepingId == objHousekeepingViewModel.HousekeepingId);
                objHousekeeping.HousekeepingNote = objHousekeepingViewModel.HousekeepingNote;
                objHousekeeping.HousekeepingStatusId = objHousekeepingViewModel.HousekeepingStatusId;
                objHousekeeping.EmployeeId = objHousekeepingViewModel.EmployeeId;


            }
            objhotelDbEntities.SaveChanges();
            return Json(data: new { message = "İşlem Başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult EditHousekeepingDetails(int HousekeepingId)
        {
            var result = objhotelDbEntities.Housekeeping.Single(model => model.HousekeepingId == HousekeepingId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllHousekeeping()
        {
            IEnumerable<HousekeepingDetailsViewModel> ListOfHousekeepingDetailsViewModels =
                (from objHousekeeping in objhotelDbEntities.Housekeeping
                 join objHousekeepingStatus in objhotelDbEntities.HousekeepingStatus on objHousekeeping.HousekeepingStatusId equals objHousekeepingStatus.HousekeepingStatusId

                 select new HousekeepingDetailsViewModel()
                 {
                     HousekeepingStatus = objHousekeepingStatus.HousekeepingStatus1,
                     RoomNumber = objHousekeeping.RoomNumber,

                 }).ToList();

            return PartialView("_HousekeepingDetailsPartial", ListOfHousekeepingDetailsViewModels);
        }
        [HttpGet]
        public JsonResult DeleteHousekeepingDetails(int HousekeepingId)
        {
            Housekeeping objHousekeeping = objhotelDbEntities.Housekeeping.Single(model => model.HousekeepingId == HousekeepingId);
      
            objhotelDbEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}