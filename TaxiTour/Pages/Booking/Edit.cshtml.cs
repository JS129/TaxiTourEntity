using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaxiTour.Data;
using TaxiTour.Models;

namespace TaxiTour.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public EditModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookedTaxis BookedTaxis { get; set; }
        public IEnumerable<Taxi> taxis { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            taxis = await _context.Taxi.ToListAsync();
        
        BookedTaxis = await _context.BookedTaxis.FirstOrDefaultAsync(m => m.id == id);

            if (BookedTaxis == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookedTaxis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookedTaxisExists(BookedTaxis.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookedTaxisExists(int id)
        {
            return _context.BookedTaxis.Any(e => e.id == id);
        }
    }
}
