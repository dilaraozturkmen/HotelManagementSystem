//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelMangementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoomBookings
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime BookingFrom { get; set; }
        public System.DateTime BookingTo { get; set; }
        public int AssignRoomId { get; set; }
        public int NoOfMember { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
