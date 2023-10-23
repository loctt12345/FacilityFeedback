using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;

namespace FacilityFeedback.RazorPage.Pages.DevicePage
{
    public class DeleteModel : PageModel
    {
        private readonly FacilityFeedback.Data.Models.FacilityFeedbackContext _context;

        public DeleteModel(FacilityFeedback.Data.Models.FacilityFeedbackContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Device Device { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FirstOrDefaultAsync(m => m.Id == id);

            if (device == null)
            {
                return NotFound();
            }
            else 
            {
                Device = device;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Device == null)
            {
                return NotFound();
            }
            var device = await _context.Device.FindAsync(id);

            if (device != null)
            {
                Device = device;
                _context.Device.Remove(Device);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
