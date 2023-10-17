using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.RoomTypePage
{
    public class EditModel : PageModel
    {
        private readonly IRoomTypeService _service;

        public EditModel(IRoomTypeService service)
        {
            _service = service;
        }

        [BindProperty]
        public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var roomType = await _service.GetById(id);
            if (roomType == null)
            {
                return NotFound();
            }
            RoomType = roomType;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _service.Update(RoomType);
            return RedirectToPage("./Index");
        }
    }
}
