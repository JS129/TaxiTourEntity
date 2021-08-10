using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxiTour.Data;
using TaxiTour.Models;

namespace TaxiTour.Pages.Taxis
{
    public class DeleteModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public DeleteModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Taxi Taxi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Taxi = await _context.Taxi.FirstOrDefaultAsync(m => m.Id == id);

            if (Taxi == null)
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

            Taxi = await _context.Taxi.FindAsync(id);

            if (Taxi != null)
            {
                _context.Taxi.Remove(Taxi);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
