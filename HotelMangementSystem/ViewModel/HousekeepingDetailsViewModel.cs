using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMangementSystem.ViewModel
{
    public class HousekeepingDetailsViewModel
    {
        public string HousekeepingStatus { get; set; }
        public int HousekeepingStatusId { get; set; }
        public int HousekeepingId { get; set; }
        public string HousekeepingStatusNote { get; set; }
        public string RoomNumber { get; set; }
        public int EmployeeFirstName { get; set; }
        public int EmployeeLastName { get; set; }
        public int EmployeeId { get; set; }


    }
}