using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;

namespace FacilityFeedback.RazorPage.Pages.FloorPage
{
    public class IndexModel : PageModel
    {
        private readonly FacilityFeedback.Data.Models.FacilityFeedbackContext _context;

        public IndexModel(FacilityFeedback.Data.Models.FacilityFeedbackContext context)
        {
            _context = context;
        }

        public IList<Floor> Floor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Floor != null)
            {
                Floor = await _context.Floor.ToListAsync();
            }
        }
    }
}
