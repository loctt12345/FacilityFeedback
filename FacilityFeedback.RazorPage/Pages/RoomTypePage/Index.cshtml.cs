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

namespace FacilityFeedback.RazorPage.Pages.RoomTypePage
{
    public class IndexModel : PageModel
    {
        private readonly IRoomTypeService _service;
        private readonly IConfiguration _config;

        public IndexModel(IRoomTypeService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        public IPagedList<RoomType>? RoomTypePaging { get; set; }

        public async Task OnGetAsync(int pageIndex)
        {
            var pageSize = Int32.Parse(_config["BaseConfig:PageSize"] ?? "10");
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            var RoomType = await _service.GetAllNoPaging();
            RoomTypePaging = await RoomType.ToPagedListAsync(pageIndex, pageSize);
            HttpContext.Session.SetString("PAGE", "RoomTypePage");
        }
    }
}
