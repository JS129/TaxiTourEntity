using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiTour.Data;
using TaxiTour.Models;
using Microsoft.EntityFrameworkCore;

namespace TaxiTour.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public CreateModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        public IEnumerable<Taxi> taxis { get; set; }
        public async Task OnGet()
        {
            taxis = await _context.Taxi.ToListAsync();
        }


        [BindProperty]
        public BookedTaxis BookedTaxis { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookedTaxis.Add(BookedTaxis);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
