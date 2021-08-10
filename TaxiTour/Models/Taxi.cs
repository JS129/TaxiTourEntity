﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxiTour.Models
{
    public class Taxi
    {
        public int Id { get; set; }

        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Display(Name = "From ")]
        public string From { get; set; }

        
        [Display(Name = "To ")]
        public string To { get; set; }


        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
