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
    public class IndexModel : PageModel
    {
        private readonly TaxiTour.Data.TaxiTourContext _context;

        public IndexModel(TaxiTour.Data.TaxiTourContext context)
        {
            _context = context;
        }

        public IList<BookedTaxis> BookedTaxis { get;set; }

        public async Task OnGetAsync()
        {
            BookedTaxis = await _context.BookedTaxis.ToListAsync();
        }
    }
}
