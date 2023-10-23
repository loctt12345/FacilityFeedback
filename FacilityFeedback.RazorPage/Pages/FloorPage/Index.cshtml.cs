using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FacilityFeedback.Data.Models;
using FacilityFeedback.Service.IServices;
using X.PagedList;
using System.Configuration;

namespace FacilityFeedback.RazorPage.Pages.FloorPage
{
    public class IndexModel : PageModel
    {
        private readonly IFloorService _service;
        private readonly IConfiguration _config;

        public IndexModel(IFloorService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<Floor>? FloorPaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var Floor = await _service.GetAllNoPaging();
            FloorPaging = await Floor.ToPagedListAsync(pageIndex, pageSize);
        }
    }
}
