using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelMangementSystem.ViewModel
{
    public class PaymentsViewModel
    {
        public string PaymentId { get; set; }
        public string BookingId { get; set; }

        [Display(Name = "Ödeme Türü")]
        [Required(ErrorMessage = "Ödeme türü gerekli.")]
        public string PaymentTypeId { get; set; }

        [Display(Name = "Tutar")]
        [Required(ErrorMessage = "Tutar gerekli.")]
        public string PaymentAmount { get; set; }
        public string IsActive { get; set; }

    }
}