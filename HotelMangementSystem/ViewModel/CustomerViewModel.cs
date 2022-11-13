using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangementSystem.ViewModel
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "Müşteri İsim")]
        [Required(ErrorMessage = "Müşteri İsimi gerekli.")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Müşteri Soyisim")]
        [Required(ErrorMessage = "Müşteri soyisimi gerekli.")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Müşteri Adres")]
        [Required(ErrorMessage = "Müşteri Adres gerekli.")]
        public string CustomerAddress { get; set; }
        [Display(Name = "Müşteri Telefon Numarası")]
        [Required(ErrorMessage = "Müşteri telefon numarası gerekli.")]
        public string CustomerPhone { get; set; }
        [Display(Name = "Müşteri T.C.")]
        [Required(ErrorMessage = "Müşteri T.C. gerekli.")]
        public string CustomerTC { get; set; }
        [Display(Name = "Müşteri Cinsiyet")]
        public string CustomerGender { get; set; }
        public IEnumerable<SelectListItem> ListOfCustomer { get; set; }
    }
}