using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace HotelMangementSystem.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        [Display(Name ="Oda Numarası")]
        [Required(ErrorMessage ="Oda Numarası gerekli.")]
        public string RoomNumber { get; set; }
        [Display(Name = "Oda Fiyatı")]
        public decimal RoomPrice { get; set; }
        [Required(ErrorMessage = "Oda Fiyatı gerekli.")]
        [Display(Name = "Oda Fotoğrafı")]
        public string RoomImage { get; set; }
        [Display(Name = "Oda Tipi")]
        [Required(ErrorMessage = "Oda tipi gerekli.")]
        public int RoomTypeId { get; set; }
        [Display(Name = "Oda Kapasitesi")]
        [Required(ErrorMessage = "Oda kapasitesi gerekli.")]
                
        public int RoomCapacity{ get; set; }
        [Display(Name = "Oda Tanımı")]
        [Required(ErrorMessage = "Oda tanımı gerekli.")]
        public string RoomDescription { get; set; }
        [Display(Name = "Randevu Durumu")]
        [Required(ErrorMessage = "Randevu durumu gerekli.")]
        public int BookingStatusId { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public List<SelectListItem> ListOfBookingStatus { get; set; }
        public List <SelectListItem> ListOfRoomType { get; set; }
        public RoomViewModel()
        {
            ListOfBookingStatus = new List<SelectListItem>();
            ListOfRoomType = new List<SelectListItem>();
        }
    }
}