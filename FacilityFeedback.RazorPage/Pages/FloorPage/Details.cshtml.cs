using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.FloorPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFloorService _service;

        public DetailsModel(IFloorService service)
        {
            _service = service;
        }

      public Floor Floor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var floor = await _service.GetById(id);
            if (floor == null) 
                return NotFound();
            Floor = floor;
            return Page();
        }
    }
}
