using HotelMangementSystem.Models;
using HotelMangementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace HotelMangementSystem.Controllers
{
    public class RepairController : Controller
    {
        private HotelDBEntities objHotelDBEntities;

        public RepairController()
        {
            objHotelDBEntities = new HotelDBEntities();
        }

        public ActionResult Index()
        {
            RepairViewModel objrepairViewModel = new RepairViewModel();
            objrepairViewModel.ListOfRoom = (from objRoom in objHotelDBEntities.Rooms
                                                 select new SelectListItem()
                                                 {
                                                     Text = objRoom.RoomNumber,
                                                     Value = objRoom.RoomId.ToString()
                                                 }).ToList();
            return View(objrepairViewModel);
        }
        [HttpPost]
        public ActionResult Index(RepairViewModel objRepairViewModel)
        {
            if (objRepairViewModel.repairID == 0)
            {
                Repair objRepair = new Repair()
                {
                    repairDate = objRepairViewModel.repairDate,
                    repairText = objRepairViewModel.repairText,
                    repairType = objRepairViewModel.repairType,
                    RoomId = objRepairViewModel.RoomId
                };

                objHotelDBEntities.Repair.Add(objRepair);
            }
            else
            {
                Repair objRepair = objHotelDBEntities.Repair.Single(model => model.repairID == objRepairViewModel.repairID);

                objRepair.repairDate = objRepairViewModel.repairDate;
                objRepair.repairText = objRepairViewModel.repairText;
                objRepair.repairType = objRepairViewModel.repairType;
                objRepair.RoomId = objRepairViewModel.RoomId;
               

            }
            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetAllRepair()
        {
            IEnumerable<RepairViewModel> ListOfRepairDetails =
                (from objRepair in objHotelDBEntities.Repair
                 join objRoom in objHotelDBEntities.Rooms on objRepair.RoomId equals objRoom.RoomId
                 select new RepairViewModel()
                 {
                     roomNumber = objRoom.RoomNumber,
                     repairText= objRepair.repairText,
                     repairDate = objRepair.repairDate,
                     RoomId = objRoom.RoomId,
                     repairType = objRepair.repairType

                 }).ToList();
            return PartialView("_ReapairDetailsPartial", ListOfRepairDetails);
        }
        [HttpGet]
        public JsonResult EditRepairDetails(int RepairId)
        {
            var result = objHotelDBEntities.Repair.Single(model => model.repairID == RepairId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteRepairDetails(int RepairId)
        {
            Repair objRepair = objHotelDBEntities.Repair.Single(model => model.repairID == RepairId);
            objHotelDBEntities.Repair.Remove(objRepair);
            objHotelDBEntities.SaveChanges();
            return Json(data: new { message = "işlem başarılı", success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}