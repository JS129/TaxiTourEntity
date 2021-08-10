using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TaxiTour.Models
{
    public class BookedTaxis
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }


        [Display(Name = "Taxi Id")]
        public int TaxiId { get; set; }

        [Display(Name = "Booking Date")]
        public string BookingDate { get; set; }
    }
}
