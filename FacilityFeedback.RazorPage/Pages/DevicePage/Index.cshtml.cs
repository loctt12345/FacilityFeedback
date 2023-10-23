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

namespace FacilityFeedback.RazorPage.Pages.DevicePage
{
    public class IndexModel : PageModel
    {

        private readonly IDeviceService _service;
        private readonly IConfiguration _config;

        public IndexModel(IDeviceService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<Device>? DevicePaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var Device = await _service.GetAllNoPaging();
            DevicePaging = await Device.ToPagedListAsync(pageIndex, pageSize);

        }
    }
}
