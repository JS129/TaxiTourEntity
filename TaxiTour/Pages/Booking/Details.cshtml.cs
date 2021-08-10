using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxiTour.Data;
using TaxiTour.Models;

namespace TaxiTour.Pages.Booking
{
    public class DetailsModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public DetailsModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        public BookedTaxis BookedTaxis { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookedTaxis = await _context.BookedTaxis.FirstOrDefaultAsync(m => m.id == id);

            if (BookedTaxis == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
