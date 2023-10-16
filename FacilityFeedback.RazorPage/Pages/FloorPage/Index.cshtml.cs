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
    public class IndexModel : PageModel
    {
        private readonly IFloorService _service;

        public IndexModel(IFloorService service)
        {
            _service = service;
        }

        public IList<Floor> Floor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Floor = await _service.GetAllNoPaging();
        }
    }
}
