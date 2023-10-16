using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FacilityFeedback.RazorPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFloorService _floorService;

        public IndexModel(ILogger<IndexModel> logger, IFloorService floorService)
        {
            _logger = logger;
            _floorService = floorService;
        }

        public List<Floor> Floor { get; set; }

        public async Task OnGet()
        {
            Floor = await _floorService.GetAllNoPaging();
        }
    }
}