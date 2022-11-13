using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMangementSystem.ViewModel
{
    public class EmployeeViewModel
    {
        public string EmployeeId { get; set; }
        [Display(Name = "Personel İsim")]
        [Required(ErrorMessage = "Personel İsimi gerekli.")]
        public string EmployeeFirstName { get; set; }
        [Display(Name = "Personel İsim")]
        [Required(ErrorMessage = "Personel İsimi gerekli.")]
        public string EmployeeLastName { get; set; }
        [Display(Name = "Personel Adres")]
        [Required(ErrorMessage = "Personel adres gerekli.")]
        public string EmployeeAddress { get; set; }
        [Display(Name = "Personel Telefon")]
        [Required(ErrorMessage = "Personel telefon gerekli.")]
        public string EmployeePhone { get; set; }
        [Display(Name = "Personel Meslek")]
        [Required(ErrorMessage = "Personel Meslek gerekli.")]
        public string EmployeeJob { get; set; }
        [Display(Name = "Personel Kulanıcı Adı")]
        [Required(ErrorMessage = "Personel kulanıcı adı gerekli.")]
        public string EmployeeUserName { get; set; }
        [Display(Name = "Personel Şifre")]
        [Required(ErrorMessage = "Personel şifre gerekli.")]
        public string EmployeePassword { get; set; }



    }
}