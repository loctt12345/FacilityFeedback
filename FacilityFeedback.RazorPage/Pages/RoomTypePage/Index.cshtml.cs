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
    public class IndexModel : PageModel
    {
        private readonly IRoomTypeService _service;

        public IndexModel(IRoomTypeService service)
        {
            _service = service;
        }

        public IList<RoomType> RoomType { get; set; } = default!;

        public async Task OnGetAsync()
        {
            RoomType = await _service.GetAllNoPaging();
        }
    }
}
