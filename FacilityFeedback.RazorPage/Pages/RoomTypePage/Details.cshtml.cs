using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.RoomTypePage
{
    public class DetailsModel : PageModel
    {
        private readonly IRoomTypeService _service;

        public DetailsModel(IRoomTypeService service)
        {
            _service = service;
        }

        public RoomType RoomType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var roomType = await _service.GetById(id);
            if (roomType == null)
                return NotFound();
            RoomType = roomType;
            return Page();
        }
    }
}
