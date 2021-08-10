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
    public class DeleteModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public DeleteModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BookedTaxis = await _context.BookedTaxis.FindAsync(id);

            if (BookedTaxis != null)
            {
                _context.BookedTaxis.Remove(BookedTaxis);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
