using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HotelMangementSystem.ViewModel
{
    public class HousekeepingViewModel
    {
        public int HousekeepingId { get; set; }
        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "Oda Numarası gerekli.")]
        public string RoomNumber { get; set; }
        [Display(Name = "Personel Adı ")]
        [Required(ErrorMessage = "Personel Adı gerekli.")]
        public int EmployeeId { get; set; }
        [Display(Name = "Housekeeping Durumu ")]
        [Required(ErrorMessage = "Housekeeping durumu  gerekli.")]
        public int HousekeepingStatusId { get; set; }
        [Display(Name = "Housekeeping Not  ")]
        public string HousekeepingNote { get; set; }
        public IEnumerable<SelectListItem> ListOfHousekeepingStatus { get; set; }
        public string HousekeepingStatus { get; set; }
        public HousekeepingViewModel()
        {
            ListOfHousekeepingStatus = new List<SelectListItem>();
        }
    }
}