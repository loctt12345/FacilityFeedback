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
    public class DetailsModel : PageModel
    {
        private readonly FacilityFeedback.Data.Models.FacilityFeedbackContext _context;

        public DetailsModel(FacilityFeedback.Data.Models.FacilityFeedbackContext context)
        {
            _context = context;
        }

      public Floor Floor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Floor == null)
            {
                return NotFound();
            }

            var floor = await _context.Floor.FirstOrDefaultAsync(m => m.Id == id);
            if (floor == null)
            {
                return NotFound();
            }
            else 
            {
                Floor = floor;
            }
            return Page();
        }
    }
}
