using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaxiTour.Data;
using TaxiTour.Models;

namespace TaxiTour.Pages.Taxis
{
    public class IndexModel : PageModel
    {
        private readonly TaxiTourContext _context;

        public IndexModel(TaxiTourContext context)
        {
            _context = context;
        }

        public IList<Taxi> Taxi { get;set; }

        public async Task OnGetAsync()
        {
            Taxi = await _context.Taxi.ToListAsync();
        }
    }
}
