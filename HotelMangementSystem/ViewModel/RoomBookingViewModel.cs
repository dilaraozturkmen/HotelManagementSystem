using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelMangementSystem.ViewModel
{
    public class RoomBookingViewModel
    {
        public int BookingId  { get; set; }

        public int NoOfMember { get; set; }
  
        public DateTime BookingFrom { get; set; }
        public decimal RoomPrice { get; set; }
        public DateTime BookingTo { get; set; }
        public string RoomNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int AssignRoomId { get; set; }
        public int NumberOfDays { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        

    }
}