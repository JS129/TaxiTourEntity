using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxiTour.Data;
using TaxiTour.Models;

namespace TaxiTour.Pages.Taxis
{
    public class CreateModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public CreateModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Taxi Taxi { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Taxi.Add(Taxi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
