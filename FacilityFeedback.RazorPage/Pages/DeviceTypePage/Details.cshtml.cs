using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;

namespace FacilityFeedback.RazorPage.Pages.DeviceTypePage
{
    public class DetailsModel : PageModel
    {
        private readonly IDeviceTypeService _service;

        public DetailsModel(IDeviceTypeService service)
        {
            _service = service;
        }

        public DeviceType DeviceType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var deviceType = await _service.GetById(id);
            if (deviceType == null)
                return NotFound();
            DeviceType = deviceType;
            return Page();
        }
    }
}
