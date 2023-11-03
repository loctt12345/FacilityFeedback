using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;

namespace FacilityFeedback.RazorPage.Pages.DeviceTypePage
{
    public class DeleteModel : PageModel
    {
        private readonly FacilityFeedback.Data.Models.FacilityFeedbackContext _context;

        public DeleteModel(FacilityFeedback.Data.Models.FacilityFeedbackContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DeviceType DeviceType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeviceType == null)
            {
                return NotFound();
            }

            var devicetype = await _context.DeviceType.FirstOrDefaultAsync(m => m.Id == id);

            if (devicetype == null)
            {
                return NotFound();
            }
            else 
            {
                DeviceType = devicetype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DeviceType == null)
            {
                return NotFound();
            }
            var devicetype = await _context.DeviceType.FindAsync(id);

            if (devicetype != null)
            {
                DeviceType = devicetype;
                _context.DeviceType.Remove(DeviceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
