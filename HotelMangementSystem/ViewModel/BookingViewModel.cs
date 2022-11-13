using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangementSystem.ViewModel
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
       
        [Display(Name = "Başlangıç Tarihi")]
        [Required(ErrorMessage = "Başlangıç tarihi gerekli.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingFrom { get; set; }
       [Display(Name = "Bitiş Tarihi")]
        [Required(ErrorMessage = "Bitiş Tarihi gerekli.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BookingTo { get; set; }
        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "Oda Numarası gerekli.")]
        public int AssignRoomId { get; set; }
        [Display(Name = "Kişi Sayısı")]
        [Required(ErrorMessage = "Kişi sayısı gerekli.")]
        public int NoOfMember { get; set; }
        [Display(Name = "Tutar")]
        [Required(ErrorMessage = "Tutar gerekli.")]
        public decimal TotalAmount { get; set; }
        public IEnumerable<SelectListItem> ListOfRooms { get; set; }
        public string RoomNumber { get; set; }
        public IEnumerable<SelectListItem> ListOfCustomer { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Müşteri T.C.")]
        public string CustomerTC { get; set; }

        public string CustomerName { get; set; }
        [Display(Name = "Müşteri Ad")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Müşteri Soyad")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Müşteri Adres")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Müşteri Telefon")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Müşteri Cinsiyet")]
        public string CustomerGender { get; set; }
    }
}