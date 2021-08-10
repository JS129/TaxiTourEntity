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
    public class EditModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public EditModel(TaxiTour.Data.TaxiTourContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Taxi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiExists(Taxi.Id))
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

        private bool TaxiExists(int id)
        {
            return _context.Taxi.Any(e => e.Id == id);
        }
    }
}
