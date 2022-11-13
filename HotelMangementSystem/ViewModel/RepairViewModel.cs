using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelMangementSystem.ViewModel
{
    public class RepairViewModel
    {
        public string roomNumber { get; set; }
        public int repairID { get; set; }
        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "Oda Numarası gerekli.")]
        public int RoomId { get; set; }
        [Display(Name = "Arıza Tarihi")]
        [Required(ErrorMessage = "Arıza Tarihi gerekli.")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime repairDate { get; set; }
        [Display(Name = "Arıza Türü")]
        [Required(ErrorMessage = "Arıza türü gerekli.")]
        public string repairType { get; set; }
        [Display(Name = "Arıza Not  ")]
        public string repairText { get; set; }
        public IEnumerable<SelectListItem> ListOfRoom { get; set; }
    }
}